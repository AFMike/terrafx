// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um\d3dcommon.h in the Windows SDK for Windows 10.0.15063.0
// Original source is Copyright © Microsoft. All rights reserved.

namespace TerraFX.Interop
{
    public enum D3D_SHADER_INPUT_TYPE
    {
        D3D_SIT_CBUFFER = 0,

        D3D_SIT_TBUFFER = (D3D_SIT_CBUFFER + 1),

        D3D_SIT_TEXTURE = (D3D_SIT_TBUFFER + 1),

        D3D_SIT_SAMPLER = (D3D_SIT_TEXTURE + 1),

        D3D_SIT_UAV_RWTYPED = (D3D_SIT_SAMPLER + 1),

        D3D_SIT_STRUCTURED = (D3D_SIT_UAV_RWTYPED + 1),

        D3D_SIT_UAV_RWSTRUCTURED = (D3D_SIT_STRUCTURED + 1),

        D3D_SIT_BYTEADDRESS = (D3D_SIT_UAV_RWSTRUCTURED + 1),

        D3D_SIT_UAV_RWBYTEADDRESS = (D3D_SIT_BYTEADDRESS + 1),

        D3D_SIT_UAV_APPEND_STRUCTURED = (D3D_SIT_UAV_RWBYTEADDRESS + 1),

        D3D_SIT_UAV_CONSUME_STRUCTURED = (D3D_SIT_UAV_APPEND_STRUCTURED + 1),

        D3D_SIT_UAV_RWSTRUCTURED_WITH_COUNTER = (D3D_SIT_UAV_CONSUME_STRUCTURED + 1),

        D3D10_SIT_CBUFFER = D3D_SIT_CBUFFER,

        D3D10_SIT_TBUFFER = D3D_SIT_TBUFFER,

        D3D10_SIT_TEXTURE = D3D_SIT_TEXTURE,

        D3D10_SIT_SAMPLER = D3D_SIT_SAMPLER,

        D3D11_SIT_UAV_RWTYPED = D3D_SIT_UAV_RWTYPED,

        D3D11_SIT_STRUCTURED = D3D_SIT_STRUCTURED,

        D3D11_SIT_UAV_RWSTRUCTURED = D3D_SIT_UAV_RWSTRUCTURED,

        D3D11_SIT_BYTEADDRESS = D3D_SIT_BYTEADDRESS,

        D3D11_SIT_UAV_RWBYTEADDRESS = D3D_SIT_UAV_RWBYTEADDRESS,

        D3D11_SIT_UAV_APPEND_STRUCTURED = D3D_SIT_UAV_APPEND_STRUCTURED,

        D3D11_SIT_UAV_CONSUME_STRUCTURED = D3D_SIT_UAV_CONSUME_STRUCTURED,

        D3D11_SIT_UAV_RWSTRUCTURED_WITH_COUNTER = D3D_SIT_UAV_RWSTRUCTURED_WITH_COUNTER
    }
}
