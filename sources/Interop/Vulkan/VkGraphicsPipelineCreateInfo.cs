// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from src\spec\vk.xml in the Vulkan-Docs repository for tag v1.0.51-core
// Original source is Copyright © 2015-2017 The Khronos Group Inc.

using System.Runtime.InteropServices;

namespace TerraFX.Interop
{
    public /* blittable */ unsafe struct VkGraphicsPipelineCreateInfo
    {
        #region Fields
        public VkStructureType sType;

        public void* pNext;

        [ComAliasName("VkPipelineCreateFlags")]
        public uint flags;

        public uint stageCount;

        [ComAliasName("VkPipelineShaderStageCreateInfo[]")]
        public VkPipelineShaderStageCreateInfo* pStages;

        public VkPipelineVertexInputStateCreateInfo* pVertexInputState;

        public VkPipelineInputAssemblyStateCreateInfo* pInputAssemblyState;

        public VkPipelineTessellationStateCreateInfo* pTessellationState;

        public VkPipelineViewportStateCreateInfo* pViewportState;

        public VkPipelineRasterizationStateCreateInfo* pRasterizationState;

        public VkPipelineMultisampleStateCreateInfo* pMultisampleState;

        public VkPipelineDepthStencilStateCreateInfo* pDepthStencilState;

        public VkPipelineColorBlendStateCreateInfo* pColorBlendState;

        public VkPipelineDynamicStateCreateInfo* pDynamicState;

        [ComAliasName("VkPipelineLayout")]
        public ulong layout;

        [ComAliasName("VkRenderPass")]
        public ulong renderPass;

        public uint subpass;

        [ComAliasName("VkPipeline")]
        public ulong basePipelineHandle;

        public int basePipelineIndex;
        #endregion
    }
}