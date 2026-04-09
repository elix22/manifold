// MfMeshGL.cs — IDisposable wrapper around a MeshGL handle.

using System;
using static Manifold.Manifoldc;

namespace Manifold
{
    /// <summary>
    /// Managed wrapper for a MeshGL (triangle soup with per-vertex properties).
    /// Takes ownership of the handle and frees it on Dispose.
    /// </summary>
    public sealed unsafe class MfMeshGL : IDisposable
    {
        public IntPtr Handle { get; private set; }
        bool _disposed;

        /// <summary>Take ownership of an already-allocated handle.</summary>
        public MfMeshGL(IntPtr handle) => Handle = handle;

        // ── Factories ─────────────────────────────────────────────────────────

        /// <summary>
        /// Create from interleaved vertex properties and triangle index triplets.
        /// </summary>
        /// <param name="vertProps">Flat array of properties, length = numVerts × numProps.</param>
        /// <param name="numProps">Number of properties per vertex (e.g. 3 for xyz, 6 for xyz+normal).</param>
        /// <param name="triVerts">Flat array of vertex indices, length = numTris × 3.</param>
        public static MfMeshGL Create(float[] vertProps, uint numProps, uint[] triVerts)
        {
            IntPtr mem = manifold_alloc_meshgl();
            fixed (float* pV = vertProps)
            fixed (uint* pT = triVerts)
            {
                nuint nVerts = (nuint)(vertProps.Length / (int)numProps);
                nuint nTris  = (nuint)(triVerts.Length / 3);
                return new MfMeshGL(manifold_meshgl((void*)mem, ref *pV, nVerts, numProps, ref *pT, nTris));
            }
        }

        public MfMeshGL Copy()
            => new(manifold_meshgl_copy((void*)manifold_alloc_meshgl(), Handle));

        /// <summary>
        /// Returns a version of this mesh with duplicate vertices merged
        /// (reduces vertex count where positions are identical).
        /// </summary>
        public MfMeshGL Merge()
            => new(manifold_meshgl_merge((void*)manifold_alloc_meshgl(), Handle));

        // ── Properties ───────────────────────────────────────────────────────

        public int NumProp              => (int)manifold_meshgl_num_prop(Handle);
        public int NumVert              => (int)manifold_meshgl_num_vert(Handle);
        public int NumTri               => (int)manifold_meshgl_num_tri(Handle);
        public int VertPropertiesLength => (int)manifold_meshgl_vert_properties_length(Handle);
        public int TriLength            => (int)manifold_meshgl_tri_length(Handle);
        public int MergeLength          => (int)manifold_meshgl_merge_length(Handle);
        public int RunIndexLength       => (int)manifold_meshgl_run_index_length(Handle);
        public int RunOriginalIdLength  => (int)manifold_meshgl_run_original_id_length(Handle);
        public int RunTransformLength   => (int)manifold_meshgl_run_transform_length(Handle);
        public int FaceIdLength         => (int)manifold_meshgl_face_id_length(Handle);
        public int TangentLength        => (int)manifold_meshgl_tangent_length(Handle);

        // ── Data extraction ───────────────────────────────────────────────────

        /// <summary>Copy all vertex property data into a managed float array.</summary>
        public float[] GetVertProperties()
        {
            int len    = VertPropertiesLength;
            var result = new float[len];
            fixed (float* pR = result)
                manifold_meshgl_vert_properties((void*)pR, Handle);
            return result;
        }

        /// <summary>Copy all triangle vertex-index data into a managed uint array.</summary>
        public uint[] GetTriVerts()
        {
            int len    = TriLength;
            var result = new uint[len];
            fixed (uint* pR = result)
                manifold_meshgl_tri_verts((void*)pR, Handle);
            return result;
        }

        // ── IDisposable ───────────────────────────────────────────────────────

        public void Dispose()
        {
            if (!_disposed && Handle != IntPtr.Zero)
            {
                manifold_delete_meshgl(Handle);
                Handle    = IntPtr.Zero;
                _disposed = true;
            }
        }

        ~MfMeshGL() => Dispose();
    }
}
