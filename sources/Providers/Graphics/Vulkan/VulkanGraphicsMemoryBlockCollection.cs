// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// This file includes code based on the VmaBlockVector struct from https://github.com/GPUOpen-LibrariesAndSDKs/VulkanMemoryAllocator
// The original code is Copyright © Advanced Micro Devices, Inc. All rights reserved. Licensed under the MIT License (MIT).

using System;
using System.Reflection;
using TerraFX.Interop;

namespace TerraFX.Graphics.Providers.Vulkan
{
    /// <inheritdoc />
    public sealed class VulkanGraphicsMemoryBlockCollection : GraphicsMemoryBlockCollection
    {
        private readonly uint _vulkanMemoryTypeIndex;

        internal VulkanGraphicsMemoryBlockCollection(VulkanGraphicsMemoryAllocator allocator, uint memoryTypeIndex)
            : base(allocator)
        {
            _vulkanMemoryTypeIndex = memoryTypeIndex;
        }

        /// <inheritdoc cref="GraphicsMemoryBlockCollection.Allocator" />
        public new VulkanGraphicsMemoryAllocator Allocator => (VulkanGraphicsMemoryAllocator)base.Allocator;

        /// <summary>Gets the memory type index used when creating the <see cref="VkDeviceMemory" /> instance for a memory block.</summary>
        public uint VulkanMemoryTypeIndex => _vulkanMemoryTypeIndex;

        /// <inheritdoc />
        protected override VulkanGraphicsMemoryBlock CreateBlock(ulong size) => (VulkanGraphicsMemoryBlock)Activator.CreateInstance(
            typeof(VulkanGraphicsMemoryBlock<>).MakeGenericType(Allocator.Settings.RegionCollectionMetadataType!),
            bindingAttr: BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.CreateInstance,
            binder: null,
            args: new object[] { this, size },
            culture: null,
            activationAttributes: null
        )!;
    }
}
