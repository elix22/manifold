#!/bin/bash
# Build script for manifoldc library on macOS
# Builds for both arm64 and x86_64 architectures
# Usage: ./build-manifoldc-macos.sh [build_type]
# Example: ./build-manifoldc-macos.sh Release
# Example: ./build-manifoldc-macos.sh Debug

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MANIFOLD_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"

BUILD_TYPE="${1:-Release}"

build_arch() {
    local ARCH="$1"

    # Normalize arch name for output directory
    if [ "$ARCH" = "x86_64" ]; then
        ARCH_DIR="X64"
    else
        ARCH_DIR="$ARCH"
    fi

    BUILD_DIR="$MANIFOLD_DIR/build-xcode-macos-$ARCH"

    echo "=========================================="
    echo "Building manifoldc for macOS ($ARCH)"
    echo "Build Type: $BUILD_TYPE"
    echo "=========================================="

    # Create build directory
    mkdir -p "$BUILD_DIR"
    cd "$BUILD_DIR"

    # Configure with CMake
    cmake "$MANIFOLD_DIR" \
        -G Xcode \
        -DCMAKE_OSX_ARCHITECTURES="$ARCH" \
        -DCMAKE_BUILD_TYPE="$BUILD_TYPE" \
        -DCMAKE_OSX_DEPLOYMENT_TARGET="11.0" \
        -DMANIFOLD_CBIND=ON \
        -DMANIFOLD_CROSS_SECTION=ON \
        -DMANIFOLD_PYBIND=OFF \
        -DMANIFOLD_JSBIND=OFF \
        -DMANIFOLD_TEST=OFF \
        -DMANIFOLD_PAR=OFF \
        -DBUILD_SHARED_LIBS=ON

    # Build only manifoldc target
    cmake --build . --config "$BUILD_TYPE" --target manifoldc

    echo "=========================================="
    echo "Build complete! ($ARCH)"
    echo "=========================================="

    # Find and copy the library
    DYLIB_PATH=$(find "$BUILD_DIR" -name "libmanifoldc.dylib" | head -1)
    if [ -n "$DYLIB_PATH" ]; then
        echo "✓ Successfully built libmanifoldc.dylib ($ARCH)"
        file "$DYLIB_PATH"

        if [ "$BUILD_TYPE" = "Debug" ]; then
            OUTPUT_DIR="$MANIFOLD_DIR/libs/macos/$ARCH_DIR/debug"
        else
            OUTPUT_DIR="$MANIFOLD_DIR/libs/macos/$ARCH_DIR/release"
        fi

        mkdir -p "$OUTPUT_DIR"
        cp "$DYLIB_PATH" "$OUTPUT_DIR/libmanifoldc.dylib"

        # Fix install name and code sign
        echo "Fixing install name and signing library..."
        install_name_tool -id "@loader_path/libmanifoldc.dylib" "$OUTPUT_DIR/libmanifoldc.dylib"
        codesign --remove-signature "$OUTPUT_DIR/libmanifoldc.dylib" 2>/dev/null || true
        TIMESTAMP=$(date +%s)
        codesign --force --sign - --identifier "libmanifoldc.${TIMESTAMP}" "$OUTPUT_DIR/libmanifoldc.dylib"

        echo "✓ Copied to $OUTPUT_DIR/libmanifoldc.dylib"
        echo "✓ Signed library with identifier libmanifoldc.${TIMESTAMP}"
    else
        echo "✗ Failed to build libmanifoldc.dylib ($ARCH)"
        exit 1
    fi
}

build_arch arm64
build_arch x86_64

echo ""
echo "=========================================="
echo "All macOS builds complete!"
echo "=========================================="
