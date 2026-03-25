#!/bin/bash
# Build script for manifoldc library for all Android architectures
# Usage: ./build-manifoldc-android-all.sh [build_type]
# Example: ./build-manifoldc-android-all.sh Release

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
BUILD_TYPE="${1:-Release}"

echo "=========================================="
echo "Building manifoldc for all Android architectures"
echo "Build Type: $BUILD_TYPE"
echo "=========================================="

ANDROID_ABIS=("arm64-v8a" "armeabi-v7a" "x86_64")

for ABI in "${ANDROID_ABIS[@]}"; do
    echo ""
    echo "Building for Android $ABI..."
    "$SCRIPT_DIR/build-manifoldc-android.sh" "$ABI" "$BUILD_TYPE"
done

echo ""
echo "=========================================="
echo "All Android builds completed successfully!"
echo "=========================================="

MANIFOLD_DIR="$(cd "$SCRIPT_DIR/.." && pwd)"
echo ""
echo "Built libraries:"
find "$MANIFOLD_DIR" -name "libmanifoldc.so" -path "*/build-android-*/*" -type f | sort
