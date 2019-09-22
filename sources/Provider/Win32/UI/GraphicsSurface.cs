// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using TerraFX.Graphics;
using TerraFX.Numerics;
using TerraFX.Utilities;
using static TerraFX.Utilities.AssertionUtilities;

namespace TerraFX.Provider.Win32.UI
{
    /// <summary>Represents a graphics surface.</summary>
    public sealed unsafe class GraphicsSurface : IGraphicsSurface
    {
        private readonly Window _window;
        private readonly int _bufferCount;

        internal GraphicsSurface(Window window, int bufferCount)
        {
            Assert(window != null, Resources.ArgumentNullExceptionMessage, nameof(bufferCount));
            Assert(bufferCount > 0, Resources.ArgumentOutOfRangeExceptionMessage, nameof(bufferCount), bufferCount);

            _window = window;
            _bufferCount = bufferCount;
        }

        /// <summary>Gets the number of buffers for the instance.</summary>
        public int BufferCount => _bufferCount;

        /// <summary>Gets the display handle for the instance.</summary>
        public IntPtr DisplayHandle => WindowProvider.EntryPointModule;

        /// <summary>Gets the kind of surface represented by the instance.</summary>
        public GraphicsSurfaceKind Kind => GraphicsSurfaceKind.Win32;

        /// <summary>Gets the size of the instance.</summary>
        public Vector2 Size => _window.Bounds.Size;

        /// <summary>Gets the window handle for the instance.</summary>
        public IntPtr WindowHandle => _window.Handle;
    }
}
