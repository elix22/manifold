// MfManifold.cs — IDisposable wrapper around a Manifold geometry handle.
// Wraps the raw C P/Invoke bindings from Manifoldc.cs into a clean OOP API.

using System;
using static Manifold.Manifoldc;

namespace Manifold
{
    /// <summary>
    /// Managed wrapper for a Manifold solid geometry object.
    /// Takes ownership of the handle and frees it on Dispose.
    /// </summary>
    public sealed unsafe class MfManifold : IDisposable
    {
        public IntPtr Handle { get; private set; }
        bool _disposed;

        /// <summary>Take ownership of an already-allocated handle.</summary>
        public MfManifold(IntPtr handle) => Handle = handle;

        static IntPtr A() => manifold_alloc_manifold();

        // ── Primitive factories ───────────────────────────────────────────────

        public static MfManifold Empty()
            => new(manifold_empty((void*)A()));

        public static MfManifold Tetrahedron()
            => new(manifold_tetrahedron((void*)A()));

        public static MfManifold Cube(double x, double y, double z, bool center = false)
            => new(manifold_cube((void*)A(), x, y, z, center ? 1 : 0));

        public static MfManifold Sphere(double radius, int circularSegments = 0)
            => new(manifold_sphere((void*)A(), radius, circularSegments));

        public static MfManifold Cylinder(double height, double radiusLow, double radiusHigh = -1.0,
                                           int circularSegments = 0, bool center = false)
            => new(manifold_cylinder((void*)A(), height, radiusLow, radiusHigh, circularSegments, center ? 1 : 0));

        public static MfManifold Extrude(MfCrossSection cs, double height,
                                          int slices = 0, double twistDegrees = 0,
                                          double scaleX = 1.0, double scaleY = 1.0)
            => new(manifold_extrude((void*)A(), cs.Handle, height, slices, twistDegrees, scaleX, scaleY));

        public static MfManifold Revolve(MfCrossSection cs,
                                          int circularSegments = 0, double revolveDegrees = 360.0)
            => new(manifold_revolve((void*)A(), cs.Handle, circularSegments, revolveDegrees));

        public static MfManifold OfMeshGL(MfMeshGL mesh)
            => new(manifold_of_meshgl((void*)A(), mesh.Handle));

        // ── Boolean operations ────────────────────────────────────────────────

        public MfManifold Union(MfManifold b)
            => new(manifold_union((void*)A(), Handle, b.Handle));

        public MfManifold Difference(MfManifold b)
            => new(manifold_difference((void*)A(), Handle, b.Handle));

        public MfManifold Intersection(MfManifold b)
            => new(manifold_intersection((void*)A(), Handle, b.Handle));

        public MfManifold Boolean(MfManifold b, ManifoldOpType op)
            => new(manifold_boolean((void*)A(), Handle, b.Handle, op));

        public static MfManifold operator +(MfManifold a, MfManifold b) => a.Union(b);
        public static MfManifold operator -(MfManifold a, MfManifold b) => a.Difference(b);
        public static MfManifold operator ^(MfManifold a, MfManifold b) => a.Intersection(b);

        // ── Transforms (each returns a new MfManifold; this instance unchanged) ─

        public MfManifold Translate(double x, double y, double z)
            => new(manifold_translate((void*)A(), Handle, x, y, z));

        public MfManifold Rotate(double xDeg, double yDeg, double zDeg)
            => new(manifold_rotate((void*)A(), Handle, xDeg, yDeg, zDeg));

        public MfManifold Scale(double x, double y, double z)
            => new(manifold_scale((void*)A(), Handle, x, y, z));

        public MfManifold Mirror(double nx, double ny, double nz)
            => new(manifold_mirror((void*)A(), Handle, nx, ny, nz));

        /// <summary>Apply a 3×4 column-major affine transform (3 column vectors + translation).</summary>
        public MfManifold Transform(double x1, double y1, double z1,
                                     double x2, double y2, double z2,
                                     double x3, double y3, double z3,
                                     double x4, double y4, double z4)
            => new(manifold_transform((void*)A(), Handle,
                                       x1, y1, z1, x2, y2, z2, x3, y3, z3, x4, y4, z4));

        public MfManifold TrimByPlane(double nx, double ny, double nz, double offset)
            => new(manifold_trim_by_plane((void*)A(), Handle, nx, ny, nz, offset));

        // ── Smoothing & refinement ────────────────────────────────────────────

        public MfManifold SmoothOut(double minSharpAngle, double minSmoothness = 0.0)
            => new(manifold_smooth_out((void*)A(), Handle, minSharpAngle, minSmoothness));

        public MfManifold SmoothByNormals(int normalIdx)
            => new(manifold_smooth_by_normals((void*)A(), Handle, normalIdx));

        public MfManifold CalculateNormals(int normalIdx, double minSharpAngle = 60.0)
            => new(manifold_calculate_normals((void*)A(), Handle, normalIdx, minSharpAngle));

        public MfManifold CalculateCurvature(int gaussianIdx, int meanIdx)
            => new(manifold_calculate_curvature((void*)A(), Handle, gaussianIdx, meanIdx));

        public MfManifold Refine(int n)
            => new(manifold_refine((void*)A(), Handle, n));

        public MfManifold RefineToLength(double length)
            => new(manifold_refine_to_length((void*)A(), Handle, length));

        public MfManifold RefineToTolerance(double tolerance)
            => new(manifold_refine_to_tolerance((void*)A(), Handle, tolerance));

        // ── Misc operations ───────────────────────────────────────────────────

        public MfManifold Copy()
            => new(manifold_copy((void*)A(), Handle));

        public MfManifold AsOriginal()
            => new(manifold_as_original((void*)A(), Handle));

        public MfManifold Hull()
            => new(manifold_hull((void*)A(), Handle));

        public MfManifold Decompose()
            => new(manifold_decompose((void*)A(), Handle));

        public MfManifold MinkowskiSum(MfManifold b)
            => new(manifold_minkowski_sum((void*)A(), Handle, b.Handle));

        public MfManifold MinkowskiDifference(MfManifold b)
            => new(manifold_minkowski_difference((void*)A(), Handle, b.Handle));

        /// <summary>Cross-sectional polygon at the given Z height.</summary>
        public MfCrossSection Slice(double height)
            => new(manifold_slice((void*)manifold_alloc_cross_section(), Handle, height));

        /// <summary>Projection onto the XY plane.</summary>
        public MfCrossSection Project()
            => new(manifold_project((void*)manifold_alloc_cross_section(), Handle));

        // ── Mesh extraction ───────────────────────────────────────────────────

        public MfMeshGL GetMeshGL()
            => new(manifold_get_meshgl((void*)manifold_alloc_meshgl(), Handle));

        // ── Properties ───────────────────────────────────────────────────────

        public bool          IsEmpty     => manifold_is_empty(Handle) != 0;
        public ManifoldError Status      => manifold_status(Handle);
        public int           NumVert     => (int)manifold_num_vert(Handle);
        public int           NumEdge     => (int)manifold_num_edge(Handle);
        public int           NumTri      => (int)manifold_num_tri(Handle);
        public int           NumProp     => (int)manifold_num_prop(Handle);
        public int           Genus       => manifold_genus(Handle);
        public double        SurfaceArea => manifold_surface_area(Handle);
        public double        Volume      => manifold_volume(Handle);
        public double        Epsilon     => manifold_epsilon(Handle);
        public int           OriginalId  => manifold_original_id(Handle);

        public MfBox BoundingBox
            => new(manifold_bounding_box((void*)manifold_alloc_box(), Handle));

        public double MinGap(MfManifold other, double searchLength)
            => manifold_min_gap(Handle, other.Handle, searchLength);

        // ── Global (static) configuration ────────────────────────────────────

        public static int  GetCircularSegments(double radius)       => manifold_get_circular_segments(radius);
        public static uint ReserveIds(uint n)                        => manifold_reserve_ids(n);
        public static void SetMinCircularAngle(double degrees)       => manifold_set_min_circular_angle(degrees);
        public static void SetMinCircularEdgeLength(double length)   => manifold_set_min_circular_edge_length(length);
        public static void SetCircularSegments(int number)           => manifold_set_circular_segments(number);
        public static void ResetToCircularDefaults()                 => manifold_reset_to_circular_defaults();

        // ── Ownership transfer ────────────────────────────────────────────────

        /// <summary>
        /// Transfer the raw handle out of this wrapper.
        /// After this call the wrapper is considered disposed and will NOT free the handle.
        /// The caller becomes responsible for calling manifold_delete_manifold.
        /// </summary>
        public IntPtr Detach()
        {
            IntPtr h  = Handle;
            Handle    = IntPtr.Zero;
            _disposed = true;
            return h;
        }

        // ── IDisposable ───────────────────────────────────────────────────────

        public void Dispose()
        {
            if (!_disposed && Handle != IntPtr.Zero)
            {
                manifold_delete_manifold(Handle);
                Handle    = IntPtr.Zero;
                _disposed = true;
            }
        }

        ~MfManifold() => Dispose();
    }
}
