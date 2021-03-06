// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System.Reflection;

namespace TerraFX.Samples.Graphics
{
    public class HelloSierpinskiQuad : HelloSierpinski
    {
        public HelloSierpinskiQuad(string name, int recursionDepth, params Assembly[] compositionAssemblies)
            : base(name, recursionDepth, SierpinskiShape.Quad, compositionAssemblies)
        {
        }
    }
}
