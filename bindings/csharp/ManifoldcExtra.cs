using System;
using System.Runtime.InteropServices;
using M = System.Runtime.InteropServices.MarshalAsAttribute;
using U = System.Runtime.InteropServices.UnmanagedType;

namespace Manifold
{

    public static unsafe partial class Manifoldc
    {

        #if __IOS__
        [DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_warp_internal", CallingConvention = CallingConvention.Cdecl)]
        #else
        [DllImport("manifoldc", EntryPoint = "manifold_warp_internal", CallingConvention = CallingConvention.Cdecl)]
        #endif
        private static extern IntPtr manifold_warp_internal(void* mem, IntPtr m, IntPtr fun, void* ctx);
        public static IntPtr manifold_warp(void* mem, IntPtr m, delegate* unmanaged<ManifoldVec3*, double, double, double, void*, void> fun, void* ctx) => manifold_warp_internal(mem, m, (IntPtr)fun, ctx);


    }


}