// MfBox.cs — IDisposable wrapper around a 3D axis-aligned bounding box handle.

using System;
using static Manifold.Manifoldc;

namespace Manifold
{
    /// <summary>
    /// Managed wrapper for a 3D axis-aligned bounding box (Box).
    /// </summary>
    public sealed unsafe class MfBox : IDisposable
    {
        public IntPtr Handle { get; private set; }
        bool _disposed;

        /// <summary>Take ownership of an already-allocated handle.</summary>
        public MfBox(IntPtr handle) => Handle = handle;

        /// <summary>Create a box from min/max corners.</summary>
        public MfBox(double x1, double y1, double z1, double x2, double y2, double z2)
            => Handle = manifold_box((void*)manifold_alloc_box(), x1, y1, z1, x2, y2, z2);

        // ── Properties ───────────────────────────────────────────────────────

        public ManifoldVec3 Min        => manifold_box_min(Handle);
        public ManifoldVec3 Max        => manifold_box_max(Handle);
        public ManifoldVec3 Center     => manifold_box_center(Handle);
        public ManifoldVec3 Dimensions => manifold_box_dimensions(Handle);
        public double       Scale      => manifold_box_scale(Handle);
        public bool         IsFinite   => manifold_box_is_finite(Handle) != 0;

        // ── Queries ───────────────────────────────────────────────────────────

        public bool ContainsPt(double x, double y, double z)
            => manifold_box_contains_pt(Handle, x, y, z) != 0;

        public bool ContainsBox(MfBox b)
            => manifold_box_contains_box(Handle, b.Handle) != 0;

        public bool OverlapsPt(double x, double y, double z)
            => manifold_box_does_overlap_pt(Handle, x, y, z) != 0;

        public bool OverlapsBox(MfBox b)
            => manifold_box_does_overlap_box(Handle, b.Handle) != 0;

        /// <summary>Expand the box to include the given point (mutates in-place).</summary>
        public void IncludePt(double x, double y, double z)
            => manifold_box_include_pt(Handle, x, y, z);

        // ── Operations (return new instances) ────────────────────────────────

        public MfBox Union(MfBox b)
            => new(manifold_box_union((void*)manifold_alloc_box(), Handle, b.Handle));

        public MfBox Translate(double x, double y, double z)
            => new(manifold_box_translate((void*)manifold_alloc_box(), Handle, x, y, z));

        /// <summary>Element-wise multiply the box extents by (x, y, z).</summary>
        public MfBox Mul(double x, double y, double z)
            => new(manifold_box_mul((void*)manifold_alloc_box(), Handle, x, y, z));

        public MfBox Transform(double x1, double y1, double z1,
                                double x2, double y2, double z2,
                                double x3, double y3, double z3,
                                double x4, double y4, double z4)
            => new(manifold_box_transform((void*)manifold_alloc_box(), Handle,
                                           x1, y1, z1, x2, y2, z2, x3, y3, z3, x4, y4, z4));

        // ── IDisposable ───────────────────────────────────────────────────────

        public void Dispose()
        {
            if (!_disposed && Handle != IntPtr.Zero)
            {
                manifold_delete_box(Handle);
                Handle    = IntPtr.Zero;
                _disposed = true;
            }
        }

        ~MfBox() => Dispose();
    }
}
