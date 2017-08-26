// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um\propidlbase.h in the Windows SDK for Windows 10.0.15063.0
// Original source is Copyright © Microsoft. All rights reserved.

using System.Runtime.InteropServices;

namespace TerraFX.Interop
{
    unsafe public /* blittable */ struct CAUL
    {
        #region Fields
        [ComAliasName("ULONG")]
        public uint cElems;

        [ComAliasName("ULONG")]
        public uint* pElems;
        #endregion
    }
}
