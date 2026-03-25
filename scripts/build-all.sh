#!/bin/bash
# Master build script for manifoldc library - builds for all available platforms
# Usage: ./build-all.sh [build_type]
# Example: ./build-all.sh Release

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
BUILD_TYPE="${1:-Release}"

echo "=========================================="
echo "Building manifoldc for all platforms"
echo "Build Type: $BUILD_TYPE"
echo "=========================================="

PLATFORM="$(uname -s)"
case "$PLATFORM" in
    Darwin*)
        echo "Running on macOS"

        echo ""
        echo "Building for macOS (arm64 + x86_64)..."
        "$SCRIPT_DIR/build-manifoldc-macos.sh" "$BUILD_TYPE"

        echo ""
        echo "Building for iOS (device)..."
        "$SCRIPT_DIR/build-manifoldc-ios.sh" iphoneos "$BUILD_TYPE"

        echo ""
        echo "Building for iOS (simulator)..."
        "$SCRIPT_DIR/build-manifoldc-ios.sh" iphonesimulator "$BUILD_TYPE"
        ;;

    Linux*)
        echo "Running on Linux"

        echo ""
        echo "Building for Linux..."
        "$SCRIPT_DIR/build-manifoldc-linux.sh" "$BUILD_TYPE"
        ;;

    MINGW*|MSYS*|CYGWIN*)
        echo "Running on Windows"

        echo ""
        echo "Building for Windows (x64)..."
        powershell.exe -ExecutionPolicy Bypass -File "$SCRIPT_DIR/build-manifoldc-windows.ps1" -Architecture x64 -BuildType "$BUILD_TYPE"
        ;;

    *)
        echo "Unknown platform: $PLATFORM"
        exit 1
        ;;
esac

# Build for Web (if Emscripten is available)
if command -v emcc &> /dev/null; then
    echo ""
    echo "Building for Web/Emscripten..."
    "$SCRIPT_DIR/build-manifoldc-web.sh" "$BUILD_TYPE"
else
    echo ""
    echo "Skipping Web build (Emscripten not found)"
fi

# Build for Android (if Android NDK is available)
if [ -n "$ANDROID_NDK" ] || [ -n "$ANDROID_NDK_HOME" ]; then
    echo ""
    echo "Building for Android (all ABIs)..."
    "$SCRIPT_DIR/build-manifoldc-android-all.sh" "$BUILD_TYPE"
else
    echo ""
    echo "Skipping Android build (ANDROID_NDK not set)"
fi

echo ""
echo "=========================================="
echo "All builds complete!"
echo "=========================================="
