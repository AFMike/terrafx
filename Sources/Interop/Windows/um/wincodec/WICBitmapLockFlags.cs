// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um\wincodec.h in the Windows SDK for Windows 10.0.15063.0
// Original source is Copyright © Microsoft. All rights reserved.

using System;

namespace TerraFX.Interop
{
    [Flags]
    public enum WICBitmapLockFlags
    {
        WICBitmapLockRead = 0x1,

        WICBitmapLockWrite = 0x2,

        WICBITMAPLOCKFLAGS_FORCE_DWORD = 0x7FFFFFFF
    }
}
