// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

#version 450 core

layout(binding = 2) uniform sampler3D input_textureSampler;

layout(location = 0) in vec3 input_uvw;
layout(location = 0) out vec4 output_color;

void main()
{
    output_color = texture(input_textureSampler, input_uvw);
}
