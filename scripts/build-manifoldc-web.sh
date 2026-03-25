#!/bin/bash
# Build script for manifoldc library for Web/Emscripten
# Usage: ./build-manifoldc-web.sh [build_type]
# Example: ./build-manifoldc-web.sh Release
# Example: ./build-manifoldc-web.sh Debug

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MANIFOLD_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"
SOKOL_NET_ROOT="$(cd "$MANIFOLD_DIR/../.." && pwd)"

BUILD_TYPE="${1:-Release}"
EMSCRIPTEN_VERSION="3.1.34"

echo "=========================================="
echo "Building manifoldc for Web/Emscripten"
echo "Build Type: $BUILD_TYPE"
echo "Emscripten Version: $EMSCRIPTEN_VERSION"
echo "=========================================="

# Path to local emsdk
EMSDK_PATH="$SOKOL_NET_ROOT/tools/emsdk/emsdk"

if [ ! -f "$EMSDK_PATH" ]; then
    echo "Error: Local emsdk not found at $EMSDK_PATH"
    echo "Please ensure the submodule is initialized: git submodule update --init --recursive"
    exit 1
fi

chmod +x "$EMSDK_PATH"

echo "Installing Emscripten SDK version $EMSCRIPTEN_VERSION..."
"$EMSDK_PATH" install "$EMSCRIPTEN_VERSION"

echo "Activating Emscripten SDK version $EMSCRIPTEN_VERSION..."
"$EMSDK_PATH" activate "$EMSCRIPTEN_VERSION"

echo "Setting up Emscripten environment..."
source "$SOKOL_NET_ROOT/tools/emsdk/emsdk_env.sh"

echo "Using Emscripten: $(emcc --version | head -n 1)"

BUILD_TYPE_LOWER=$(echo "$BUILD_TYPE" | tr '[:upper:]' '[:lower:]')
BUILD_DIR="$MANIFOLD_DIR/build-emscripten-$BUILD_TYPE_LOWER"

echo "Cleaning build directory: $BUILD_DIR"
rm -rf "$BUILD_DIR"
mkdir -p "$BUILD_DIR"
cd "$BUILD_DIR"

echo "Configuring CMake..."
emcmake cmake "$MANIFOLD_DIR" \
    -DCMAKE_BUILD_TYPE="$BUILD_TYPE" \
    -DMANIFOLD_CBIND=ON \
    -DMANIFOLD_CROSS_SECTION=ON \
    -DMANIFOLD_PYBIND=OFF \
    -DMANIFOLD_JSBIND=OFF \
    -DMANIFOLD_TEST=OFF \
    -DMANIFOLD_PAR=OFF \
    -DBUILD_SHARED_LIBS=OFF

echo "Building manifoldc..."
cmake --build . --config "$BUILD_TYPE" --target manifoldc

echo "=========================================="
echo "Build complete!"
echo "=========================================="

# Verify the library was created and copy to libs
LIB_PATH=$(find "$BUILD_DIR" -name "libmanifoldc.a" | head -1)
if [ -n "$LIB_PATH" ]; then
    echo "✓ Successfully built libmanifoldc.a"
    ls -lh "$LIB_PATH"

    if [ "$BUILD_TYPE" = "Debug" ]; then
        OUTPUT_DIR="$MANIFOLD_DIR/libs/emscripten/x86/debug"
    else
        OUTPUT_DIR="$MANIFOLD_DIR/libs/emscripten/x86/release"
    fi

    mkdir -p "$OUTPUT_DIR"
    cp "$LIB_PATH" "$OUTPUT_DIR/manifoldc.a"
    echo "✓ Copied to $OUTPUT_DIR/manifoldc.a"
else
    echo "✗ Failed to build manifoldc.a"
    exit 1
fi
