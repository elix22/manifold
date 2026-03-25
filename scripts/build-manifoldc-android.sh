#!/bin/bash
# Build script for manifoldc library for Android
# Usage: ./build-manifoldc-android.sh [abi] [build_type]
# Example: ./build-manifoldc-android.sh arm64-v8a Release
# Example: ./build-manifoldc-android.sh armeabi-v7a Debug
# Supported ABIs: arm64-v8a, armeabi-v7a, x86_64

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MANIFOLD_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"

# Parse arguments
ANDROID_ABI="${1:-arm64-v8a}"
BUILD_TYPE="${2:-Release}"
BUILD_DIR="$MANIFOLD_DIR/build-android-$ANDROID_ABI"

echo "=========================================="
echo "Building manifoldc for Android"
echo "ABI: $ANDROID_ABI"
echo "Build Type: $BUILD_TYPE"
echo "=========================================="

# Check for Android NDK
if [ -z "$ANDROID_NDK" ]; then
    if [ -z "$ANDROID_NDK_HOME" ]; then
        echo "Error: ANDROID_NDK or ANDROID_NDK_HOME environment variable not set"
        echo "Please set one of these to your Android NDK path"
        exit 1
    fi
    ANDROID_NDK="$ANDROID_NDK_HOME"
fi

if [ ! -d "$ANDROID_NDK" ]; then
    echo "Error: Android NDK not found at: $ANDROID_NDK"
    exit 1
fi

echo "Using Android NDK: $ANDROID_NDK"

ANDROID_NATIVE_API_LEVEL="${ANDROID_NATIVE_API_LEVEL:-21}"
echo "API Level: $ANDROID_NATIVE_API_LEVEL"

# Create build directory
mkdir -p "$BUILD_DIR"
cd "$BUILD_DIR"

# Configure with CMake
cmake "$MANIFOLD_DIR" \
    -DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK/build/cmake/android.toolchain.cmake" \
    -DANDROID_ABI="$ANDROID_ABI" \
    -DANDROID_NATIVE_API_LEVEL="$ANDROID_NATIVE_API_LEVEL" \
    -DANDROID_STL=c++_shared \
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

# Verify the library was created and copy to libs
LIB_PATH=$(find "$BUILD_DIR" -name "libmanifoldc.so" | head -1)
if [ -n "$LIB_PATH" ]; then
    echo "✓ Successfully built libmanifoldc.so for $ANDROID_ABI"
    ls -lh "$LIB_PATH"

    if [ "$BUILD_TYPE" = "Debug" ]; then
        OUTPUT_DIR="$MANIFOLD_DIR/libs/android/$ANDROID_ABI/debug"
    else
        OUTPUT_DIR="$MANIFOLD_DIR/libs/android/$ANDROID_ABI/release"
    fi

    mkdir -p "$OUTPUT_DIR"
    cp "$LIB_PATH" "$OUTPUT_DIR/libmanifoldc.so"
    echo "✓ Copied to $OUTPUT_DIR/libmanifoldc.so"
else
    echo "✗ Failed to build libmanifoldc.so"
    exit 1
fi
