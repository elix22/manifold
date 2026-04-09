// MfRect.cs — IDisposable wrapper around a 2D axis-aligned rectangle handle.

using System;
using static Manifold.Manifoldc;

namespace Manifold
{
    /// <summary>
    /// Managed wrapper for a 2D axis-aligned rectangle (Rect).
    /// </summary>
    public sealed unsafe class MfRect : IDisposable
    {
        public IntPtr Handle { get; private set; }
        bool _disposed;

        /// <summary>Take ownership of an already-allocated handle.</summary>
        public MfRect(IntPtr handle) => Handle = handle;

        /// <summary>Create a rect from two corners (x1,y1) and (x2,y2).</summary>
        public MfRect(double x1, double y1, double x2, double y2)
            => Handle = manifold_rect((void*)manifold_alloc_rect(), x1, y1, x2, y2);

        // ── Properties ───────────────────────────────────────────────────────

        public ManifoldVec2 Min        => manifold_rect_min(Handle);
        public ManifoldVec2 Max        => manifold_rect_max(Handle);
        public ManifoldVec2 Center     => manifold_rect_center(Handle);
        public ManifoldVec2 Dimensions => manifold_rect_dimensions(Handle);
        public double       Scale      => manifold_rect_scale(Handle);
        public bool         IsEmpty    => manifold_rect_is_empty(Handle) != 0;
        public bool         IsFinite   => manifold_rect_is_finite(Handle) != 0;

        // ── Queries ───────────────────────────────────────────────────────────

        public bool ContainsPt(double x, double y)
            => manifold_rect_contains_pt(Handle, x, y) != 0;

        public bool ContainsRect(MfRect b)
            => manifold_rect_contains_rect(Handle, b.Handle) != 0;

        public bool OverlapsRect(MfRect r)
            => manifold_rect_does_overlap_rect(Handle, r.Handle) != 0;

        /// <summary>Expand the rect to include the given point (mutates in-place).</summary>
        public void IncludePt(double x, double y)
            => manifold_rect_include_pt(Handle, x, y);

        // ── Operations (return new instances) ────────────────────────────────

        public MfRect Union(MfRect b)
            => new(manifold_rect_union((void*)manifold_alloc_rect(), Handle, b.Handle));

        public MfRect Translate(double x, double y)
            => new(manifold_rect_translate((void*)manifold_alloc_rect(), Handle, x, y));

        /// <summary>Element-wise multiply the rect extents by (x, y).</summary>
        public MfRect Mul(double x, double y)
            => new(manifold_rect_mul((void*)manifold_alloc_rect(), Handle, x, y));

        public MfRect Transform(double x1, double y1, double x2, double y2, double x3, double y3)
            => new(manifold_rect_transform((void*)manifold_alloc_rect(), Handle,
                                            x1, y1, x2, y2, x3, y3));

        // ── IDisposable ───────────────────────────────────────────────────────

        public void Dispose()
        {
            if (!_disposed && Handle != IntPtr.Zero)
            {
                manifold_delete_rect(Handle);
                Handle    = IntPtr.Zero;
                _disposed = true;
            }
        }

        ~MfRect() => Dispose();
    }
}
