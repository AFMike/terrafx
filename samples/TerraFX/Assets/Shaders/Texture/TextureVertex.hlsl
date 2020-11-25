// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

#include "TextureTypes.hlsl"

PSInput main(VSInput input)
{
    PSInput output;

    output.position = float4(input.position, 1.0f);
    output.uv = input.uv;

    return output;
}
