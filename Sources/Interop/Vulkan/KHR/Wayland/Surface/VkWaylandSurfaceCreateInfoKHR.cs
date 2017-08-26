// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from src\spec\vk.xml in the Vulkan-Docs repository for tag v1.0.51-core
// Original source is Copyright © 2015-2017 The Khronos Group Inc.

using System;
using System.Runtime.InteropServices;

namespace TerraFX.Interop
{
    unsafe public /* blittable */ struct VkWaylandSurfaceCreateInfoKHR
    {
        #region Fields
        public VkStructureType sType;

        public void* pNext;

        [ComAliasName("VkWaylandSurfaceCreateFlagsKHR")]
        public uint flags;

        [ComAliasName("wl_display")]
        public IntPtr display;

        [ComAliasName("wl_surface")]
        public IntPtr surface;
        #endregion
    }
}
