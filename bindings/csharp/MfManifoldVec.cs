// MfManifoldVec.cs — IDisposable wrapper around a vector-of-manifolds handle.
// Used for batch boolean, compose, and hull operations.

using System;
using static Manifold.Manifoldc;

namespace Manifold
{
    /// <summary>
    /// Managed wrapper for a variable-length vector of Manifold handles.
    /// Used as input to batch boolean, compose, and convex-hull operations.
    /// </summary>
    public sealed unsafe class MfManifoldVec : IDisposable
    {
        public IntPtr Handle { get; private set; }
        bool _disposed;

        /// <summary>Create an empty vector.</summary>
        public MfManifoldVec()
            => Handle = manifold_manifold_empty_vec((void*)manifold_alloc_manifold_vec());

        /// <summary>Create a vector pre-sized to <paramref name="capacity"/> slots.</summary>
        public MfManifoldVec(int capacity)
            => Handle = manifold_manifold_vec((void*)manifold_alloc_manifold_vec(), (nuint)capacity);

        // ── Collection API ────────────────────────────────────────────────────

        public int Count => (int)manifold_manifold_vec_length(Handle);

        public void Reserve(int capacity)
            => manifold_manifold_vec_reserve(Handle, (nuint)capacity);

        public void Add(MfManifold m)
            => manifold_manifold_vec_push_back(Handle, m.Handle);

        public void Set(int idx, MfManifold m)
            => manifold_manifold_vec_set(Handle, (nuint)idx, m.Handle);

        /// <summary>
        /// Get the manifold at <paramref name="idx"/>.
        /// The returned <see cref="MfManifold"/> shares ownership with the vector —
        /// do not Dispose it independently if the vector is still alive.
        /// </summary>
        public MfManifold Get(int idx)
            => new(manifold_manifold_vec_get((void*)manifold_alloc_manifold(), Handle, (nuint)idx));

        // ── Batch operations ──────────────────────────────────────────────────

        public MfManifold BatchBoolean(ManifoldOpType op)
            => new(manifold_batch_boolean((void*)manifold_alloc_manifold(), Handle, op));

        /// <summary>Combine all manifolds in this vector into one composed solid.</summary>
        public MfManifold Compose()
            => new(manifold_compose((void*)manifold_alloc_manifold(), Handle));

        /// <summary>Compute the convex hull of all manifolds in this vector.</summary>
        public MfManifold BatchHull()
            => new(manifold_batch_hull((void*)manifold_alloc_manifold(), Handle));

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
                    manifold_delete_manifold_vec(Handle);
                    Handle = IntPtr.Zero;
                }
                _disposed = true;
            }
        }

        ~MfManifoldVec() => Dispose(false);
    }
}
