// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License MIT. See License.md in the repository root for more information.

// Ported from um\d3d12.h in the Windows SDK for Windows 10.0.15063.0
// Original source is Copyright © Microsoft. All rights reserved.

namespace TerraFX.Interop
{
    unsafe public /* blittable */ struct D3D12_ROOT_DESCRIPTOR_TABLE1
    {
        #region Fields
        public UINT NumDescriptorRanges;

        public /* readonly */ D3D12_DESCRIPTOR_RANGE1* pDescriptorRanges;
        #endregion
    }
}