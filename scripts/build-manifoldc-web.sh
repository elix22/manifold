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

# Use system emcc if already available (e.g. CI with setup-emsdk action),
# otherwise fall back to the local emsdk submodule.
if command -v emcc &>/dev/null; then
    echo "Using system Emscripten: $(emcc --version | head -n 1)"
else
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
fi

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

# Verify the library was created
LIB_PATH=$(find "$BUILD_DIR" -name "libmanifoldc.a" | head -1)
if [ -z "$LIB_PATH" ]; then
    echo "✗ Failed to build libmanifoldc.a"
    exit 1
fi
echo "✓ Successfully built libmanifoldc.a"
ls -lh "$LIB_PATH"

if [ "$BUILD_TYPE" = "Debug" ]; then
    OUTPUT_DIR="$MANIFOLD_DIR/libs/emscripten/x86/debug"
else
    OUTPUT_DIR="$MANIFOLD_DIR/libs/emscripten/x86/release"
fi
mkdir -p "$OUTPUT_DIR"

# Merge all dependency archives into a single self-contained fat archive.
# A static .a does not embed its transitive dependencies the way a .dylib/.so
# does, so we must combine libmanifoldc.a + libmanifold.a + libClipper2.a here.
echo "Merging all archives into a single fat manifoldc.a..."
MANIFOLDC_A=$(find "$BUILD_DIR" -name "libmanifoldc.a" | head -1)
MANIFOLD_A=$(find  "$BUILD_DIR" -name "libmanifold.a"  | head -1)
CLIPPER2_A=$(find  "$BUILD_DIR" -name "libClipper2.a" -o -name "libclipper2.a" 2>/dev/null | head -1)

echo "  manifoldc : $MANIFOLDC_A"
echo "  manifold  : $MANIFOLD_A"
echo "  Clipper2  : ${CLIPPER2_A:-(not found, optional)}"

FAT_OUTPUT="$OUTPUT_DIR/manifoldc.a"
MRI_SCRIPT=$(mktemp /tmp/manifold_merge_XXXXXX.mri)
{
    echo "CREATE $FAT_OUTPUT"
    echo "ADDLIB $MANIFOLDC_A"
    [ -n "$MANIFOLD_A"  ] && echo "ADDLIB $MANIFOLD_A"
    [ -n "$CLIPPER2_A"  ] && echo "ADDLIB $CLIPPER2_A"
    echo "SAVE"
    echo "END"
} > "$MRI_SCRIPT"

emar -M < "$MRI_SCRIPT"
rm -f "$MRI_SCRIPT"

echo "✓ Fat archive created at $FAT_OUTPUT"
ls -lh "$FAT_OUTPUT"
