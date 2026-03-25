#!/bin/bash
# Build script for manifoldc library on Linux
# Usage: ./build-manifoldc-linux.sh [build_type]
# Example: ./build-manifoldc-linux.sh Release
# Example: ./build-manifoldc-linux.sh Debug

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MANIFOLD_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"
BUILD_DIR="$MANIFOLD_DIR/build-linux"

BUILD_TYPE="${1:-Release}"

echo "=========================================="
echo "Building manifoldc for Linux"
echo "Build Type: $BUILD_TYPE"
echo "=========================================="

# Create build directory
mkdir -p "$BUILD_DIR"
cd "$BUILD_DIR"

# Configure with CMake
cmake "$MANIFOLD_DIR" \
    -DCMAKE_BUILD_TYPE="$BUILD_TYPE" \
    -DMANIFOLD_CBIND=ON \
    -DMANIFOLD_CROSS_SECTION=ON \
    -DMANIFOLD_PYBIND=OFF \
    -DMANIFOLD_JSBIND=OFF \
    -DMANIFOLD_TEST=OFF \
    -DMANIFOLD_PAR=OFF \
    -DBUILD_SHARED_LIBS=ON

# Build only manifoldc target
cmake --build . --config "$BUILD_TYPE" --target manifoldc -- -j$(nproc)

echo "=========================================="
echo "Build complete!"
echo "=========================================="

# Verify and copy the library
LIB_PATH=$(find "$BUILD_DIR" -name "libmanifoldc.so" | head -1)
if [ -n "$LIB_PATH" ]; then
    echo "✓ Successfully built libmanifoldc.so"
    file "$LIB_PATH"

    ARCH="X64"
    if [ "$BUILD_TYPE" = "Debug" ]; then
        OUTPUT_DIR="$MANIFOLD_DIR/libs/linux/$ARCH/debug"
    else
        OUTPUT_DIR="$MANIFOLD_DIR/libs/linux/$ARCH/release"
    fi
    mkdir -p "$OUTPUT_DIR"
    cp "$LIB_PATH" "$OUTPUT_DIR/"
    echo "✓ Copied to: $OUTPUT_DIR/libmanifoldc.so"
else
    echo "✗ Failed to build libmanifoldc.so"
    exit 1
fi
