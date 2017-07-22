// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace TerraFX.Interop.UnitTests
{
    /// <summary>Provides validation of the <see cref="D3D12_RECT" /> struct.</summary>
    public static class D3D12_RECTTests
    {
        /// <summary>Validates that the layout of the <see cref="D3D12_RECT" /> struct is <see cref="LayoutKind.Explicit" />.</summary>
        [Test]
        public static void IsLayoutExplicitTest()
        {
            Assert.That(typeof(D3D12_RECT).IsExplicitLayout, Is.True);
        }

        /// <summary>Validates that the size of the <see cref="D3D12_RECT" /> struct is correct.</summary>
        [Test]
        public static void SizeOfTest()
        {
            Assert.That(Marshal.SizeOf<D3D12_RECT>(), Is.EqualTo(16));
        }
    }
}
