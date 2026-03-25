// machine generated, do not edit
using System;
using System.Runtime.InteropServices;
using M = System.Runtime.InteropServices.MarshalAsAttribute;
using U = System.Runtime.InteropServices.UnmanagedType;

namespace Manifold
{
public static unsafe partial class Manifoldc
{
[StructLayout(LayoutKind.Sequential)]
public struct ManifoldManifoldPair
{
    public IntPtr first;
    public IntPtr second;
}
[StructLayout(LayoutKind.Sequential)]
public struct ManifoldVec2
{
    public double x;
    public double y;
}
[StructLayout(LayoutKind.Sequential)]
public struct ManifoldVec3
{
    public double x;
    public double y;
    public double z;
}
[StructLayout(LayoutKind.Sequential)]
public struct ManifoldIVec3
{
    public int x;
    public int y;
    public int z;
}
[StructLayout(LayoutKind.Sequential)]
public struct ManifoldVec4
{
    public double x;
    public double y;
    public double z;
    public double w;
}
[StructLayout(LayoutKind.Sequential)]
public struct ManifoldProperties
{
    public double surface_area;
    public double volume;
}
[StructLayout(LayoutKind.Sequential)]
public struct ManifoldMeshGLOptions
{
    public uint* run_indices;
    public nuint run_indices_length;
    public uint* run_original_ids;
    public nuint run_original_ids_length;
    public uint* merge_from_vert;
    public uint* merge_to_vert;
    public nuint merge_verts_length;
    public float* halfedge_tangents;
}
[StructLayout(LayoutKind.Sequential)]
public struct ManifoldMeshGL64Options
{
    public ulong* run_indices;
    public nuint run_indices_length;
    public uint* run_original_ids;
    public nuint run_original_ids_length;
    public ulong* merge_from_vert;
    public ulong* merge_to_vert;
    public nuint merge_verts_length;
    public double* halfedge_tangents;
}
public enum ManifoldOpType
{
    MANIFOLD_ADD,
    MANIFOLD_SUBTRACT,
    MANIFOLD_INTERSECT,
}
public enum ManifoldError
{
    MANIFOLD_NO_ERROR,
    MANIFOLD_NON_FINITE_VERTEX,
    MANIFOLD_NOT_MANIFOLD,
    MANIFOLD_VERTEX_INDEX_OUT_OF_BOUNDS,
    MANIFOLD_PROPERTIES_WRONG_LENGTH,
    MANIFOLD_MISSING_POSITION_PROPERTIES,
    MANIFOLD_MERGE_VECTORS_DIFFERENT_LENGTHS,
    MANIFOLD_MERGE_INDEX_OUT_OF_BOUNDS,
    MANIFOLD_TRANSFORM_WRONG_LENGTH,
    MANIFOLD_RUN_INDEX_WRONG_LENGTH,
    MANIFOLD_FACE_ID_WRONG_LENGTH,
    MANIFOLD_INVALID_CONSTRUCTION,
    MANIFOLD_RESULT_TOO_LARGE,
}
public enum ManifoldFillRule
{
    MANIFOLD_FILL_RULE_EVEN_ODD,
    MANIFOLD_FILL_RULE_NON_ZERO,
    MANIFOLD_FILL_RULE_POSITIVE,
    MANIFOLD_FILL_RULE_NEGATIVE,
}
public enum ManifoldJoinType
{
    MANIFOLD_JOIN_TYPE_SQUARE,
    MANIFOLD_JOIN_TYPE_ROUND,
    MANIFOLD_JOIN_TYPE_MITER,
    MANIFOLD_JOIN_TYPE_BEVEL,
}
#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_simple_polygon", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_simple_polygon", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_simple_polygon(void* mem, ManifoldVec2* ps, nuint length);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_polygons", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_polygons", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_polygons(void* mem, IntPtr ps, nuint length);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_simple_polygon_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_simple_polygon_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_simple_polygon_length(IntPtr p);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_polygons_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_polygons_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_polygons_length(IntPtr ps);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_polygons_simple_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_polygons_simple_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_polygons_simple_length(IntPtr ps, nuint idx);

#if WEB
public static ManifoldVec2 manifold_simple_polygon_get_point(IntPtr p, nuint idx)
{
    ManifoldVec2 result = default;
    manifold_simple_polygon_get_point_internal(ref result, p, idx);
    return result;
}
#else
#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_simple_polygon_get_point", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_simple_polygon_get_point", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern ManifoldVec2 manifold_simple_polygon_get_point(IntPtr p, nuint idx);
#endif

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_polygons_get_simple", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_polygons_get_simple", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_polygons_get_simple(void* mem, IntPtr ps, nuint idx);

#if WEB
public static ManifoldVec2 manifold_polygons_get_point(IntPtr ps, nuint simple_idx, nuint pt_idx)
{
    ManifoldVec2 result = default;
    manifold_polygons_get_point_internal(ref result, ps, simple_idx, pt_idx);
    return result;
}
#else
#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_polygons_get_point", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_polygons_get_point", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern ManifoldVec2 manifold_polygons_get_point(IntPtr ps, nuint simple_idx, nuint pt_idx);
#endif

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_meshgl(void* mem, ref float vert_props, nuint n_verts, nuint n_props, ref uint tri_verts, nuint n_tris);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_w_tangents", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_w_tangents", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_meshgl_w_tangents(void* mem, ref float vert_props, nuint n_verts, nuint n_props, ref uint tri_verts, nuint n_tris, ref float halfedge_tangent);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_w_options", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_w_options", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_meshgl_w_options(void* mem, ref float vert_props, nuint n_verts, nuint n_props, ref uint tri_verts, nuint n_tris, ManifoldMeshGLOptions* options);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_get_meshgl", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_get_meshgl", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_get_meshgl(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_get_meshgl_w_normals", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_get_meshgl_w_normals", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_get_meshgl_w_normals(void* mem, IntPtr m, int normalIdx);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_copy", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_copy", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_meshgl_copy(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_merge", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_merge", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_meshgl_merge(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_meshgl64(void* mem, ref double vert_props, nuint n_verts, nuint n_props, ref ulong tri_verts, nuint n_tris);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_w_tangents", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_w_tangents", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_meshgl64_w_tangents(void* mem, ref double vert_props, nuint n_verts, nuint n_props, ref ulong tri_verts, nuint n_tris, ref double halfedge_tangent);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_w_options", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_w_options", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_meshgl64_w_options(void* mem, ref double vert_props, nuint n_verts, nuint n_props, ref ulong tri_verts, nuint n_tris, ManifoldMeshGL64Options* options);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_get_meshgl64", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_get_meshgl64", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_get_meshgl64(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_get_meshgl64_w_normals", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_get_meshgl64_w_normals", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_get_meshgl64_w_normals(void* mem, IntPtr m, int normalIdx);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_copy", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_copy", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_meshgl64_copy(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_merge", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_merge", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_meshgl64_merge(void* mem, IntPtr m);

#if WEB
[DllImport("manifoldc", EntryPoint = "manifold_level_set", CallingConvention = CallingConvention.Cdecl)]
private static extern IntPtr manifold_level_set_native(void* mem, IntPtr sdf, IntPtr bounds, double edge_length, double level, double tolerance, void* ctx);
public static IntPtr manifold_level_set(void* mem, delegate* unmanaged<double, double, double, void*, double> sdf, IntPtr bounds, double edge_length, double level, double tolerance, void* ctx) => manifold_level_set_native(mem, (IntPtr)sdf, bounds, edge_length, level, tolerance, ctx);
#else
#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_level_set", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_level_set", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_level_set(void* mem, delegate* unmanaged<double, double, double, void*, double> sdf, IntPtr bounds, double edge_length, double level, double tolerance, void* ctx);
#endif

#if WEB
[DllImport("manifoldc", EntryPoint = "manifold_level_set_seq", CallingConvention = CallingConvention.Cdecl)]
private static extern IntPtr manifold_level_set_seq_native(void* mem, IntPtr sdf, IntPtr bounds, double edge_length, double level, double tolerance, void* ctx);
public static IntPtr manifold_level_set_seq(void* mem, delegate* unmanaged<double, double, double, void*, double> sdf, IntPtr bounds, double edge_length, double level, double tolerance, void* ctx) => manifold_level_set_seq_native(mem, (IntPtr)sdf, bounds, edge_length, level, tolerance, ctx);
#else
#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_level_set_seq", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_level_set_seq", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_level_set_seq(void* mem, delegate* unmanaged<double, double, double, void*, double> sdf, IntPtr bounds, double edge_length, double level, double tolerance, void* ctx);
#endif

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_manifold_empty_vec", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_manifold_empty_vec", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_manifold_empty_vec(void* mem);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_manifold_vec", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_manifold_vec", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_manifold_vec(void* mem, nuint sz);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_manifold_vec_reserve", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_manifold_vec_reserve", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_manifold_vec_reserve(IntPtr ms, nuint sz);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_manifold_vec_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_manifold_vec_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_manifold_vec_length(IntPtr ms);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_manifold_vec_get", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_manifold_vec_get", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_manifold_vec_get(void* mem, IntPtr ms, nuint idx);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_manifold_vec_set", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_manifold_vec_set", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_manifold_vec_set(IntPtr ms, nuint idx, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_manifold_vec_push_back", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_manifold_vec_push_back", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_manifold_vec_push_back(IntPtr ms, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_boolean", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_boolean", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_boolean(void* mem, IntPtr a, IntPtr b, ManifoldOpType op);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_batch_boolean", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_batch_boolean", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_batch_boolean(void* mem, IntPtr ms, ManifoldOpType op);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_union", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_union", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_union(void* mem, IntPtr a, IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_difference", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_difference", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_difference(void* mem, IntPtr a, IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_intersection", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_intersection", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_intersection(void* mem, IntPtr a, IntPtr b);

#if WEB
public static ManifoldManifoldPair manifold_split(void* mem_first, void* mem_second, IntPtr a, IntPtr b)
{
    ManifoldManifoldPair result = default;
    manifold_split_internal(ref result, mem_first, mem_second, a, b);
    return result;
}
#else
#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_split", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_split", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern ManifoldManifoldPair manifold_split(void* mem_first, void* mem_second, IntPtr a, IntPtr b);
#endif

#if WEB
public static ManifoldManifoldPair manifold_split_by_plane(void* mem_first, void* mem_second, IntPtr m, double normal_x, double normal_y, double normal_z, double offset)
{
    ManifoldManifoldPair result = default;
    manifold_split_by_plane_internal(ref result, mem_first, mem_second, m, normal_x, normal_y, normal_z, offset);
    return result;
}
#else
#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_split_by_plane", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_split_by_plane", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern ManifoldManifoldPair manifold_split_by_plane(void* mem_first, void* mem_second, IntPtr m, double normal_x, double normal_y, double normal_z, double offset);
#endif

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_trim_by_plane", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_trim_by_plane", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_trim_by_plane(void* mem, IntPtr m, double normal_x, double normal_y, double normal_z, double offset);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_minkowski_sum", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_minkowski_sum", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_minkowski_sum(void* mem, IntPtr a, IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_minkowski_difference", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_minkowski_difference", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_minkowski_difference(void* mem, IntPtr a, IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_slice", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_slice", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_slice(void* mem, IntPtr m, double height);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_project", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_project", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_project(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_hull", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_hull", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_hull(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_batch_hull", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_batch_hull", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_batch_hull(void* mem, IntPtr ms);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_hull_pts", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_hull_pts", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_hull_pts(void* mem, ManifoldVec3* ps, nuint length);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_translate", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_translate", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_translate(void* mem, IntPtr m, double x, double y, double z);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rotate", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rotate", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_rotate(void* mem, IntPtr m, double x, double y, double z);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_scale", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_scale", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_scale(void* mem, IntPtr m, double x, double y, double z);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_transform", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_transform", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_transform(void* mem, IntPtr m, double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3, double x4, double y4, double z4);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_mirror", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_mirror", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_mirror(void* mem, IntPtr m, double nx, double ny, double nz);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_smooth_by_normals", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_smooth_by_normals", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_smooth_by_normals(void* mem, IntPtr m, int normalIdx);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_smooth_out", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_smooth_out", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_smooth_out(void* mem, IntPtr m, double minSharpAngle, double minSmoothness);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_refine", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_refine", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_refine(void* mem, IntPtr m, int refine);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_refine_to_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_refine_to_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_refine_to_length(void* mem, IntPtr m, double length);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_refine_to_tolerance", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_refine_to_tolerance", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_refine_to_tolerance(void* mem, IntPtr m, double tolerance);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_empty", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_empty", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_empty(void* mem);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_copy", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_copy", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_copy(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_tetrahedron", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_tetrahedron", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_tetrahedron(void* mem);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cube", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cube", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cube(void* mem, double x, double y, double z, int center);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cylinder", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cylinder", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cylinder(void* mem, double height, double radius_low, double radius_high, int circular_segments, int center);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_sphere", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_sphere", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_sphere(void* mem, double radius, int circular_segments);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_of_meshgl", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_of_meshgl", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_of_meshgl(void* mem, IntPtr mesh);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_of_meshgl64", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_of_meshgl64", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_of_meshgl64(void* mem, IntPtr mesh);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_smooth", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_smooth", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_smooth(void* mem, IntPtr mesh, ref nuint half_edges, ref double smoothness, nuint n_idxs);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_smooth64", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_smooth64", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_smooth64(void* mem, IntPtr mesh, ref nuint half_edges, ref double smoothness, nuint n_idxs);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_extrude", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_extrude", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_extrude(void* mem, IntPtr cs, double height, int slices, double twist_degrees, double scale_x, double scale_y);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_revolve", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_revolve", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_revolve(void* mem, IntPtr cs, int circular_segments, double revolve_degrees);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_compose", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_compose", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_compose(void* mem, IntPtr ms);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_decompose", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_decompose", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_decompose(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_as_original", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_as_original", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_as_original(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_is_empty", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_is_empty", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int manifold_is_empty(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_status", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_status", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern ManifoldError manifold_status(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_num_vert", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_num_vert", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_num_vert(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_num_edge", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_num_edge", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_num_edge(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_num_tri", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_num_tri", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_num_tri(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_num_prop", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_num_prop", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_num_prop(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_bounding_box", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_bounding_box", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_bounding_box(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_epsilon", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_epsilon", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern double manifold_epsilon(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_genus", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_genus", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int manifold_genus(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_surface_area", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_surface_area", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern double manifold_surface_area(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_volume", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_volume", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern double manifold_volume(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_get_circular_segments", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_get_circular_segments", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int manifold_get_circular_segments(double radius);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_original_id", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_original_id", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int manifold_original_id(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_reserve_ids", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_reserve_ids", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern uint manifold_reserve_ids(uint n);

#if WEB
[DllImport("manifoldc", EntryPoint = "manifold_set_properties", CallingConvention = CallingConvention.Cdecl)]
private static extern IntPtr manifold_set_properties_native(void* mem, IntPtr m, int num_prop, IntPtr fun, void* ctx);
public static IntPtr manifold_set_properties(void* mem, IntPtr m, int num_prop, delegate* unmanaged<double*, ManifoldVec3, double*, void*, void> fun, void* ctx) => manifold_set_properties_native(mem, m, num_prop, (IntPtr)fun, ctx);
#else
#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_set_properties", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_set_properties", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_set_properties(void* mem, IntPtr m, int num_prop, delegate* unmanaged<double*, ManifoldVec3, double*, void*, void> fun, void* ctx);
#endif

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_calculate_curvature", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_calculate_curvature", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_calculate_curvature(void* mem, IntPtr m, int gaussian_idx, int mean_idx);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_min_gap", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_min_gap", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern double manifold_min_gap(IntPtr m, IntPtr other, double searchLength);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_calculate_normals", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_calculate_normals", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_calculate_normals(void* mem, IntPtr m, int normal_idx, double min_sharp_angle);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_empty", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_empty", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_empty(void* mem);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_copy", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_copy", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_copy(void* mem, IntPtr cs);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_of_simple_polygon", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_of_simple_polygon", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_of_simple_polygon(void* mem, IntPtr p, ManifoldFillRule fr);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_of_polygons", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_of_polygons", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_of_polygons(void* mem, IntPtr p, ManifoldFillRule fr);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_square", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_square", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_square(void* mem, double x, double y, int center);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_circle", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_circle", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_circle(void* mem, double radius, int circular_segments);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_compose", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_compose", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_compose(void* mem, IntPtr csv);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_decompose", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_decompose", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_decompose(void* mem, IntPtr cs);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_empty_vec", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_empty_vec", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_empty_vec(void* mem);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_vec", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_vec", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_vec(void* mem, nuint sz);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_vec_reserve", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_vec_reserve", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_cross_section_vec_reserve(IntPtr csv, nuint sz);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_vec_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_vec_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_cross_section_vec_length(IntPtr csv);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_vec_get", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_vec_get", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_vec_get(void* mem, IntPtr csv, nuint idx);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_vec_set", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_vec_set", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_cross_section_vec_set(IntPtr csv, nuint idx, IntPtr cs);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_vec_push_back", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_vec_push_back", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_cross_section_vec_push_back(IntPtr csv, IntPtr cs);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_boolean", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_boolean", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_boolean(void* mem, IntPtr a, IntPtr b, ManifoldOpType op);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_batch_boolean", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_batch_boolean", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_batch_boolean(void* mem, IntPtr csv, ManifoldOpType op);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_union", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_union", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_union(void* mem, IntPtr a, IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_difference", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_difference", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_difference(void* mem, IntPtr a, IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_intersection", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_intersection", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_intersection(void* mem, IntPtr a, IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_hull", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_hull", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_hull(void* mem, IntPtr cs);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_batch_hull", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_batch_hull", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_batch_hull(void* mem, IntPtr css);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_hull_simple_polygon", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_hull_simple_polygon", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_hull_simple_polygon(void* mem, IntPtr ps);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_hull_polygons", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_hull_polygons", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_hull_polygons(void* mem, IntPtr ps);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_translate", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_translate", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_translate(void* mem, IntPtr cs, double x, double y);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_rotate", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_rotate", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_rotate(void* mem, IntPtr cs, double deg);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_scale", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_scale", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_scale(void* mem, IntPtr cs, double x, double y);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_mirror", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_mirror", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_mirror(void* mem, IntPtr cs, double ax_x, double ax_y);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_transform", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_transform", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_transform(void* mem, IntPtr cs, double x1, double y1, double x2, double y2, double x3, double y3);

#if WEB
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_warp_context", CallingConvention = CallingConvention.Cdecl)]
private static extern IntPtr manifold_cross_section_warp_context_native(void* mem, IntPtr cs, IntPtr fun, void* ctx);
public static IntPtr manifold_cross_section_warp_context(void* mem, IntPtr cs, delegate* unmanaged<double, double, void*, ManifoldVec2> fun, void* ctx) => manifold_cross_section_warp_context_native(mem, cs, (IntPtr)fun, ctx);
#else
#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_warp_context", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_warp_context", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_warp_context(void* mem, IntPtr cs, delegate* unmanaged<double, double, void*, ManifoldVec2> fun, void* ctx);
#endif

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_simplify", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_simplify", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_simplify(void* mem, IntPtr cs, double epsilon);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_offset", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_offset", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_offset(void* mem, IntPtr cs, double delta, ManifoldJoinType jt, double miter_limit, int circular_segments);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_area", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_area", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern double manifold_cross_section_area(IntPtr cs);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_num_vert", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_num_vert", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_cross_section_num_vert(IntPtr cs);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_num_contour", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_num_contour", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_cross_section_num_contour(IntPtr cs);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_is_empty", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_is_empty", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int manifold_cross_section_is_empty(IntPtr cs);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_bounds", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_bounds", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_bounds(void* mem, IntPtr cs);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_to_polygons", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_to_polygons", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_cross_section_to_polygons(void* mem, IntPtr cs);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_rect(void* mem, double x1, double y1, double x2, double y2);

#if WEB
public static ManifoldVec2 manifold_rect_min(IntPtr r)
{
    ManifoldVec2 result = default;
    manifold_rect_min_internal(ref result, r);
    return result;
}
#else
#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect_min", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect_min", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern ManifoldVec2 manifold_rect_min(IntPtr r);
#endif

#if WEB
public static ManifoldVec2 manifold_rect_max(IntPtr r)
{
    ManifoldVec2 result = default;
    manifold_rect_max_internal(ref result, r);
    return result;
}
#else
#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect_max", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect_max", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern ManifoldVec2 manifold_rect_max(IntPtr r);
#endif

#if WEB
public static ManifoldVec2 manifold_rect_dimensions(IntPtr r)
{
    ManifoldVec2 result = default;
    manifold_rect_dimensions_internal(ref result, r);
    return result;
}
#else
#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect_dimensions", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect_dimensions", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern ManifoldVec2 manifold_rect_dimensions(IntPtr r);
#endif

#if WEB
public static ManifoldVec2 manifold_rect_center(IntPtr r)
{
    ManifoldVec2 result = default;
    manifold_rect_center_internal(ref result, r);
    return result;
}
#else
#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect_center", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect_center", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern ManifoldVec2 manifold_rect_center(IntPtr r);
#endif

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect_scale", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect_scale", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern double manifold_rect_scale(IntPtr r);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect_contains_pt", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect_contains_pt", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int manifold_rect_contains_pt(IntPtr r, double x, double y);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect_contains_rect", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect_contains_rect", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int manifold_rect_contains_rect(IntPtr a, IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect_include_pt", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect_include_pt", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_rect_include_pt(IntPtr r, double x, double y);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect_union", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect_union", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_rect_union(void* mem, IntPtr a, IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect_transform", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect_transform", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_rect_transform(void* mem, IntPtr r, double x1, double y1, double x2, double y2, double x3, double y3);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect_translate", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect_translate", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_rect_translate(void* mem, IntPtr r, double x, double y);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect_mul", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect_mul", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_rect_mul(void* mem, IntPtr r, double x, double y);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect_does_overlap_rect", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect_does_overlap_rect", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int manifold_rect_does_overlap_rect(IntPtr a, IntPtr r);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect_is_empty", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect_is_empty", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int manifold_rect_is_empty(IntPtr r);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect_is_finite", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect_is_finite", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int manifold_rect_is_finite(IntPtr r);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_box(void* mem, double x1, double y1, double z1, double x2, double y2, double z2);

#if WEB
public static ManifoldVec3 manifold_box_min(IntPtr b)
{
    ManifoldVec3 result = default;
    manifold_box_min_internal(ref result, b);
    return result;
}
#else
#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box_min", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box_min", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern ManifoldVec3 manifold_box_min(IntPtr b);
#endif

#if WEB
public static ManifoldVec3 manifold_box_max(IntPtr b)
{
    ManifoldVec3 result = default;
    manifold_box_max_internal(ref result, b);
    return result;
}
#else
#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box_max", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box_max", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern ManifoldVec3 manifold_box_max(IntPtr b);
#endif

#if WEB
public static ManifoldVec3 manifold_box_dimensions(IntPtr b)
{
    ManifoldVec3 result = default;
    manifold_box_dimensions_internal(ref result, b);
    return result;
}
#else
#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box_dimensions", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box_dimensions", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern ManifoldVec3 manifold_box_dimensions(IntPtr b);
#endif

#if WEB
public static ManifoldVec3 manifold_box_center(IntPtr b)
{
    ManifoldVec3 result = default;
    manifold_box_center_internal(ref result, b);
    return result;
}
#else
#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box_center", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box_center", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern ManifoldVec3 manifold_box_center(IntPtr b);
#endif

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box_scale", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box_scale", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern double manifold_box_scale(IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box_contains_pt", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box_contains_pt", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int manifold_box_contains_pt(IntPtr b, double x, double y, double z);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box_contains_box", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box_contains_box", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int manifold_box_contains_box(IntPtr a, IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box_include_pt", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box_include_pt", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_box_include_pt(IntPtr b, double x, double y, double z);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box_union", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box_union", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_box_union(void* mem, IntPtr a, IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box_transform", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box_transform", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_box_transform(void* mem, IntPtr b, double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3, double x4, double y4, double z4);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box_translate", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box_translate", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_box_translate(void* mem, IntPtr b, double x, double y, double z);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box_mul", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box_mul", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_box_mul(void* mem, IntPtr b, double x, double y, double z);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box_does_overlap_pt", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box_does_overlap_pt", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int manifold_box_does_overlap_pt(IntPtr b, double x, double y, double z);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box_does_overlap_box", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box_does_overlap_box", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int manifold_box_does_overlap_box(IntPtr a, IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box_is_finite", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box_is_finite", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int manifold_box_is_finite(IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_set_min_circular_angle", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_set_min_circular_angle", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_set_min_circular_angle(double degrees);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_set_min_circular_edge_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_set_min_circular_edge_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_set_min_circular_edge_length(double length);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_set_circular_segments", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_set_circular_segments", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_set_circular_segments(int number);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_reset_to_circular_defaults", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_reset_to_circular_defaults", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_reset_to_circular_defaults();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_num_prop", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_num_prop", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl_num_prop(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_num_vert", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_num_vert", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl_num_vert(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_num_tri", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_num_tri", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl_num_tri(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_vert_properties_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_vert_properties_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl_vert_properties_length(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_tri_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_tri_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl_tri_length(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_merge_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_merge_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl_merge_length(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_run_index_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_run_index_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl_run_index_length(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_run_original_id_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_run_original_id_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl_run_original_id_length(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_run_transform_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_run_transform_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl_run_transform_length(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_face_id_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_face_id_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl_face_id_length(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_tangent_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_tangent_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl_tangent_length(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_vert_properties", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_vert_properties", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern float* manifold_meshgl_vert_properties(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_tri_verts", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_tri_verts", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern uint* manifold_meshgl_tri_verts(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_merge_from_vert", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_merge_from_vert", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern uint* manifold_meshgl_merge_from_vert(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_merge_to_vert", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_merge_to_vert", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern uint* manifold_meshgl_merge_to_vert(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_run_index", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_run_index", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern uint* manifold_meshgl_run_index(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_run_original_id", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_run_original_id", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern uint* manifold_meshgl_run_original_id(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_run_transform", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_run_transform", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern float* manifold_meshgl_run_transform(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_face_id", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_face_id", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern uint* manifold_meshgl_face_id(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_halfedge_tangent", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_halfedge_tangent", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern float* manifold_meshgl_halfedge_tangent(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_num_prop", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_num_prop", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl64_num_prop(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_num_vert", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_num_vert", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl64_num_vert(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_num_tri", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_num_tri", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl64_num_tri(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_vert_properties_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_vert_properties_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl64_vert_properties_length(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_tri_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_tri_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl64_tri_length(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_merge_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_merge_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl64_merge_length(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_run_index_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_run_index_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl64_run_index_length(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_run_original_id_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_run_original_id_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl64_run_original_id_length(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_run_transform_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_run_transform_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl64_run_transform_length(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_face_id_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_face_id_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl64_face_id_length(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_tangent_length", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_tangent_length", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl64_tangent_length(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_vert_properties", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_vert_properties", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern double* manifold_meshgl64_vert_properties(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_tri_verts", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_tri_verts", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern ulong* manifold_meshgl64_tri_verts(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_merge_from_vert", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_merge_from_vert", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern ulong* manifold_meshgl64_merge_from_vert(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_merge_to_vert", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_merge_to_vert", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern ulong* manifold_meshgl64_merge_to_vert(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_run_index", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_run_index", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern ulong* manifold_meshgl64_run_index(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_run_original_id", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_run_original_id", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern uint* manifold_meshgl64_run_original_id(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_run_transform", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_run_transform", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern double* manifold_meshgl64_run_transform(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_face_id", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_face_id", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern ulong* manifold_meshgl64_face_id(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_halfedge_tangent", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_halfedge_tangent", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern double* manifold_meshgl64_halfedge_tangent(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_triangulate", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_triangulate", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_triangulate(void* mem, IntPtr ps, double epsilon);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_triangulation_num_tri", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_triangulation_num_tri", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_triangulation_num_tri(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_triangulation_tri_verts", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_triangulation_tri_verts", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern int* manifold_triangulation_tri_verts(void* mem, IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_manifold_size", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_manifold_size", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_manifold_size();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_manifold_vec_size", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_manifold_vec_size", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_manifold_vec_size();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_size", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_size", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_cross_section_size();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_cross_section_vec_size", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_cross_section_vec_size", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_cross_section_vec_size();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_simple_polygon_size", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_simple_polygon_size", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_simple_polygon_size();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_polygons_size", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_polygons_size", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_polygons_size();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_manifold_pair_size", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_manifold_pair_size", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_manifold_pair_size();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl_size", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl_size", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl_size();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_size", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_size", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_meshgl64_size();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box_size", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box_size", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_box_size();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect_size", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect_size", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_rect_size();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_triangulation_size", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_triangulation_size", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern nuint manifold_triangulation_size();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_alloc_manifold", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_alloc_manifold", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_alloc_manifold();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_alloc_manifold_vec", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_alloc_manifold_vec", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_alloc_manifold_vec();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_alloc_cross_section", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_alloc_cross_section", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_alloc_cross_section();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_alloc_cross_section_vec", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_alloc_cross_section_vec", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_alloc_cross_section_vec();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_alloc_simple_polygon", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_alloc_simple_polygon", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_alloc_simple_polygon();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_alloc_polygons", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_alloc_polygons", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_alloc_polygons();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_alloc_meshgl", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_alloc_meshgl", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_alloc_meshgl();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_alloc_meshgl64", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_alloc_meshgl64", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_alloc_meshgl64();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_alloc_box", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_alloc_box", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_alloc_box();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_alloc_rect", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_alloc_rect", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_alloc_rect();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_alloc_triangulation", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_alloc_triangulation", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_alloc_triangulation();

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_destruct_manifold", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_destruct_manifold", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_destruct_manifold(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_destruct_manifold_vec", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_destruct_manifold_vec", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_destruct_manifold_vec(IntPtr ms);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_destruct_cross_section", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_destruct_cross_section", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_destruct_cross_section(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_destruct_cross_section_vec", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_destruct_cross_section_vec", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_destruct_cross_section_vec(IntPtr csv);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_destruct_simple_polygon", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_destruct_simple_polygon", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_destruct_simple_polygon(IntPtr p);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_destruct_polygons", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_destruct_polygons", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_destruct_polygons(IntPtr p);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_destruct_meshgl", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_destruct_meshgl", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_destruct_meshgl(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_destruct_meshgl64", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_destruct_meshgl64", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_destruct_meshgl64(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_destruct_box", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_destruct_box", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_destruct_box(IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_destruct_rect", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_destruct_rect", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_destruct_rect(IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_destruct_triangulation", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_destruct_triangulation", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_destruct_triangulation(IntPtr M);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_delete_manifold", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_delete_manifold", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_delete_manifold(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_delete_manifold_vec", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_delete_manifold_vec", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_delete_manifold_vec(IntPtr ms);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_delete_cross_section", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_delete_cross_section", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_delete_cross_section(IntPtr cs);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_delete_cross_section_vec", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_delete_cross_section_vec", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_delete_cross_section_vec(IntPtr csv);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_delete_simple_polygon", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_delete_simple_polygon", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_delete_simple_polygon(IntPtr p);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_delete_polygons", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_delete_polygons", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_delete_polygons(IntPtr p);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_delete_meshgl", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_delete_meshgl", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_delete_meshgl(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_delete_meshgl64", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_delete_meshgl64", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_delete_meshgl64(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_delete_box", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_delete_box", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_delete_box(IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_delete_rect", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_delete_rect", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_delete_rect(IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_delete_triangulation", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_delete_triangulation", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_delete_triangulation(IntPtr m);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_read_obj", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_read_obj", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_read_obj(void* mem, IntPtr obj_file);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_read_obj", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_read_obj", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern IntPtr manifold_meshgl64_read_obj(void* mem, IntPtr obj_file);

#if WEB
[DllImport("manifoldc", EntryPoint = "manifold_write_obj", CallingConvention = CallingConvention.Cdecl)]
private static extern void manifold_write_obj_native(IntPtr manifold, IntPtr callback, void* args);
public static void manifold_write_obj(IntPtr manifold, delegate* unmanaged<byte*, void*, void> callback, void* args) => manifold_write_obj_native(manifold, (IntPtr)callback, args);
#else
#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_write_obj", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_write_obj", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_write_obj(IntPtr manifold, delegate* unmanaged<byte*, void*, void> callback, void* args);
#endif

#if WEB
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_write_obj", CallingConvention = CallingConvention.Cdecl)]
private static extern void manifold_meshgl64_write_obj_native(IntPtr mesh, IntPtr callback, void* args);
public static void manifold_meshgl64_write_obj(IntPtr mesh, delegate* unmanaged<byte*, void*, void> callback, void* args) => manifold_meshgl64_write_obj_native(mesh, (IntPtr)callback, args);
#else
#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_meshgl64_write_obj", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_meshgl64_write_obj", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_meshgl64_write_obj(IntPtr mesh, delegate* unmanaged<byte*, void*, void> callback, void* args);
#endif

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_simple_polygon_get_point_internal", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_simple_polygon_get_point_internal", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_simple_polygon_get_point_internal(ref ManifoldVec2 result, IntPtr p, nuint idx);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_polygons_get_point_internal", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_polygons_get_point_internal", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_polygons_get_point_internal(ref ManifoldVec2 result, IntPtr ps, nuint simple_idx, nuint pt_idx);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_split_internal", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_split_internal", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_split_internal(ref ManifoldManifoldPair result, void* mem_first, void* mem_second, IntPtr a, IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_split_by_plane_internal", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_split_by_plane_internal", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_split_by_plane_internal(ref ManifoldManifoldPair result, void* mem_first, void* mem_second, IntPtr m, double normal_x, double normal_y, double normal_z, double offset);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect_min_internal", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect_min_internal", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_rect_min_internal(ref ManifoldVec2 result, IntPtr r);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect_max_internal", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect_max_internal", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_rect_max_internal(ref ManifoldVec2 result, IntPtr r);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect_dimensions_internal", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect_dimensions_internal", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_rect_dimensions_internal(ref ManifoldVec2 result, IntPtr r);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_rect_center_internal", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_rect_center_internal", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_rect_center_internal(ref ManifoldVec2 result, IntPtr r);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box_min_internal", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box_min_internal", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_box_min_internal(ref ManifoldVec3 result, IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box_max_internal", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box_max_internal", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_box_max_internal(ref ManifoldVec3 result, IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box_dimensions_internal", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box_dimensions_internal", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_box_dimensions_internal(ref ManifoldVec3 result, IntPtr b);

#if __IOS__
[DllImport("@rpath/manifoldc.framework/manifoldc", EntryPoint = "manifold_box_center_internal", CallingConvention = CallingConvention.Cdecl)]
#else
[DllImport("manifoldc", EntryPoint = "manifold_box_center_internal", CallingConvention = CallingConvention.Cdecl)]
#endif
public static extern void manifold_box_center_internal(ref ManifoldVec3 result, IntPtr b);

}
}
