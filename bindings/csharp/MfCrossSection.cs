// MfCrossSection.cs — IDisposable wrapper around a 2D CrossSection handle.

using System;
using static Manifold.Manifoldc;

namespace Manifold
{
    /// <summary>
    /// Managed wrapper for a 2D CrossSection (planar polygon set).
    /// Takes ownership of the handle and frees it on Dispose.
    /// </summary>
    public sealed unsafe class MfCrossSection : IDisposable
    {
        public IntPtr Handle { get; private set; }
        bool _disposed;

        /// <summary>Take ownership of an already-allocated handle.</summary>
        public MfCrossSection(IntPtr handle) => Handle = handle;

        static IntPtr A() => manifold_alloc_cross_section();

        // ── Primitive factories ───────────────────────────────────────────────

        public static MfCrossSection Empty()
            => new(manifold_cross_section_empty((void*)A()));

        public static MfCrossSection Square(double x, double y, bool center = false)
            => new(manifold_cross_section_square((void*)A(), x, y, center ? 1 : 0));

        public static MfCrossSection Circle(double radius, int circularSegments = 0)
            => new(manifold_cross_section_circle((void*)A(), radius, circularSegments));

        // ── Boolean operations ────────────────────────────────────────────────

        public MfCrossSection Union(MfCrossSection b)
            => new(manifold_cross_section_union((void*)A(), Handle, b.Handle));

        public MfCrossSection Difference(MfCrossSection b)
            => new(manifold_cross_section_difference((void*)A(), Handle, b.Handle));

        public MfCrossSection Intersection(MfCrossSection b)
            => new(manifold_cross_section_intersection((void*)A(), Handle, b.Handle));

        public MfCrossSection Boolean(MfCrossSection b, ManifoldOpType op)
            => new(manifold_cross_section_boolean((void*)A(), Handle, b.Handle, op));

        public static MfCrossSection operator +(MfCrossSection a, MfCrossSection b) => a.Union(b);
        public static MfCrossSection operator -(MfCrossSection a, MfCrossSection b) => a.Difference(b);
        public static MfCrossSection operator ^(MfCrossSection a, MfCrossSection b) => a.Intersection(b);

        // ── Transforms (return new instances) ────────────────────────────────

        public MfCrossSection Translate(double x, double y)
            => new(manifold_cross_section_translate((void*)A(), Handle, x, y));

        public MfCrossSection Rotate(double degrees)
            => new(manifold_cross_section_rotate((void*)A(), Handle, degrees));

        public MfCrossSection Scale(double x, double y)
            => new(manifold_cross_section_scale((void*)A(), Handle, x, y));

        public MfCrossSection Mirror(double ax, double ay)
            => new(manifold_cross_section_mirror((void*)A(), Handle, ax, ay));

        public MfCrossSection Transform(double x1, double y1, double x2, double y2, double x3, double y3)
            => new(manifold_cross_section_transform((void*)A(), Handle, x1, y1, x2, y2, x3, y3));

        // ── Misc operations ───────────────────────────────────────────────────

        public MfCrossSection Offset(double delta,
                                      ManifoldJoinType joinType = ManifoldJoinType.MANIFOLD_JOIN_TYPE_ROUND,
                                      double miterLimit = 2.0, int circularSegments = 0)
            => new(manifold_cross_section_offset((void*)A(), Handle, delta, joinType, miterLimit, circularSegments));

        public MfCrossSection Simplify(double epsilon = 1e-6)
            => new(manifold_cross_section_simplify((void*)A(), Handle, epsilon));

        public MfCrossSection Hull()
            => new(manifold_cross_section_hull((void*)A(), Handle));

        public MfCrossSection Copy()
            => new(manifold_cross_section_copy((void*)A(), Handle));

        public MfCrossSection Decompose()
            => new(manifold_cross_section_decompose((void*)A(), Handle));

        // ── Properties ───────────────────────────────────────────────────────

        public bool   IsEmpty    => manifold_cross_section_is_empty(Handle) != 0;
        public double Area       => manifold_cross_section_area(Handle);
        public int    NumVert    => (int)manifold_cross_section_num_vert(Handle);
        public int    NumContour => (int)manifold_cross_section_num_contour(Handle);

        public MfRect Bounds
            => new(manifold_cross_section_bounds((void*)manifold_alloc_rect(), Handle));

        // ── 3D lift ───────────────────────────────────────────────────────────

        /// <summary>Extrude this cross-section into a 3D solid.</summary>
        public MfManifold Extrude(double height, int slices = 0, double twistDegrees = 0,
                                   double scaleX = 1.0, double scaleY = 1.0)
            => new(manifold_extrude((void*)manifold_alloc_manifold(), Handle,
                                     height, slices, twistDegrees, scaleX, scaleY));

        /// <summary>Revolve this cross-section around the Y-axis.</summary>
        public MfManifold Revolve(int circularSegments = 0, double revolveDegrees = 360.0)
            => new(manifold_revolve((void*)manifold_alloc_manifold(), Handle,
                                     circularSegments, revolveDegrees));

        // ── IDisposable ───────────────────────────────────────────────────────

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (Handle != IntPtr.Zero)
                {
                    manifold_delete_cross_section(Handle);
                    Handle = IntPtr.Zero;
                }
                _disposed = true;
            }
        }

        ~MfCrossSection() => Dispose(false);
    }
}
