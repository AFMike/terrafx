// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

#version 450 core

layout(binding = 2) uniform sampler3D input_textureSampler;

layout(location = 0) in float input_scale;
layout(location = 1) in vec3 input_uvw;
layout(location = 0) out vec4 output_color;

void main()
{
    float r = 0.0f;
    float g = 0.0f;
    float b = 0.0f;
    float a = 0.0f;
    for (int i = 0; i < 100; i++)
    {
        vec4 color = vec4(1.0f, 1.0f, 1.0f, 1.0f);
        vec3 uvw = vec3(input_uvw[0], input_uvw[1], (input_uvw[2] + i * 0.01f));
        color = color * texture(input_textureSampler, uvw)[0];
        color = color * input_scale * input_scale * 0.5f;
        r = r * a + color[0] * (1.0f - a);
        g = g * a + color[1] * (1.0f - a);
        b = b * a + color[2] * (1.0f - a);
        a = 1.0f - (1.0f - a) * (1.0f - color[3]);
    }
    vec4 accumulatedColor = vec4(r,g,b,a);
    output_color = accumulatedColor;
}
