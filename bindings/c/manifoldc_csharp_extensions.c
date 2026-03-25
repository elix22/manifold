#include "manifold/manifoldc.h"
#include "manifold/types.h"
#include "manifoldc_csharp_internal_wrappers.h"

typedef void (*ManifoldWarpOutPtrCallback)(ManifoldVec3* out, double x, double y, double z, void* ctx);

typedef struct {
    ManifoldWarpOutPtrCallback fun;
    void* ctx;
} ManifoldWarpOutPtrCtx;

static ManifoldVec3 manifold_warp_outptr_trampoline(double x, double y, double z, void* ctx) {
    ManifoldWarpOutPtrCtx* c = (ManifoldWarpOutPtrCtx*)ctx;
    ManifoldVec3 result;
    c->fun(&result, x, y, z, c->ctx);
    return result;
}

MANIFOLDC_EXPORT ManifoldManifold* manifold_warp_internal(void* mem, ManifoldManifold* m, ManifoldWarpOutPtrCallback fun, void* ctx)
{
    ManifoldWarpOutPtrCtx wctx;
    wctx.fun = fun;
    wctx.ctx = ctx;
    return manifold_warp(mem, m, manifold_warp_outptr_trampoline, &wctx);
}
