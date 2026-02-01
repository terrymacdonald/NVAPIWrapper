#pragma once

// ClangSharp doesn't handle SAL annotations like __success; override to a no-op.
#ifdef __success
#undef __success
#endif
#define __success(x)

// Provide no-op SAL annotations used by NVAPI headers so Clang can parse signatures.
#ifndef __in
#define __in
#endif
#ifndef __in_opt
#define __in_opt
#endif
#ifndef __in_bcount
#define __in_bcount(size)
#endif
#ifndef __in_ecount
#define __in_ecount(size)
#endif
#ifndef __inout
#define __inout
#endif
#ifndef __inout_opt
#define __inout_opt
#endif
#ifndef __inout_ecount_full
#define __inout_ecount_full(size)
#endif
#ifndef __inout_ecount_part_opt
#define __inout_ecount_part_opt(size, length)
#endif
#ifndef __out
#define __out
#endif
#ifndef __out_opt
#define __out_opt
#endif
#ifndef __out_ecount_opt
#define __out_ecount_opt(size)
#endif
#ifndef __out_ecount_full_opt
#define __out_ecount_full_opt(size)
#endif
#ifndef _WINNT_
#define _WINNT_ 1
#endif

#include <stdint.h>

#ifndef HANDLE
typedef void* HANDLE;
#endif

#ifndef _LUID_DEFINED
#define _LUID_DEFINED
typedef struct _LUID {
    uint32_t LowPart;
    int32_t HighPart;
} LUID;
#endif

#include "../nvapi/nvapi.h"
#include "../nvapi/nvapi_interface.h"
#include "../nvapi/NvApiDriverSettings.h"
