// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using TerraFX.ApplicationModel;
using TerraFX.Graphics;
using TerraFX.Interop;
using TerraFX.Numerics;
using static TerraFX.Utilities.InteropUtilities;

namespace TerraFX.Samples.Graphics
{
    public class HelloSierpinski : HelloWindow
    {
        private GraphicsPrimitive _pyramid = null!;
        private float _texturePosition;
        private int _recursionDepth;

        public HelloSierpinski(string name, int recursionDepth, params Assembly[] compositionAssemblies)
            : base(name, compositionAssemblies)
        {
            _recursionDepth = recursionDepth;
        }

        public override void Cleanup()
        {
            _pyramid?.Dispose();
            base.Cleanup();
        }

        public override void Initialize(Application application)
        {
            base.Initialize(application);

            var graphicsDevice = GraphicsDevice;

            ulong vertices = 2 * 12 * (ulong)MathF.Pow(4, _recursionDepth);
            ulong vertexBufferSize = vertices * SizeOf<PosNormTex3DVertex>();
            ulong indexBufferSize = vertices * SizeOf<uint>(); // matches vertices count because vertices are replicated, three unique ones per triangle
            using (var vertexStagingBuffer = graphicsDevice.MemoryAllocator.CreateBuffer(GraphicsBufferKind.Default, GraphicsResourceCpuAccess.Write, vertexBufferSize))
            using (var indexStagingBuffer = graphicsDevice.MemoryAllocator.CreateBuffer(GraphicsBufferKind.Default, GraphicsResourceCpuAccess.Write, indexBufferSize))
            {
                var currentGraphicsContext = graphicsDevice.CurrentContext;

                currentGraphicsContext.BeginFrame();
                _pyramid = CreateGraphicsPrimitive(currentGraphicsContext, vertexStagingBuffer, indexStagingBuffer);
                currentGraphicsContext.EndFrame();

                graphicsDevice.Signal(currentGraphicsContext.Fence);
                graphicsDevice.WaitForIdle();
            }
        }

        protected override unsafe void Update(TimeSpan delta)
        {
            const float rotationSpeed = 0.5f;

            float radians = _texturePosition;
            {
                radians += (float)(rotationSpeed * delta.TotalSeconds);
                radians = radians % (2 * MathF.PI);
            }
            _texturePosition = radians;
            float sin = MathF.Sin(radians);
            float cos = MathF.Cos(radians);

            var constantBuffer = (GraphicsBuffer)_pyramid.InputResources[0];
            var pConstantBuffer = constantBuffer.Map<Matrix4x4>();

            // Shaders take transposed matrices, so we want to mirror along the diagonal

            bool isIdentity = false; if (isIdentity) pConstantBuffer[0] = new Matrix4x4(
                new Vector4(1.0f, 0.0f, 0.0f, 0.0f),
                new Vector4(0.0f, 1.0f, 0.0f, 0.0f),
                new Vector4(0.0f, 0.0f, 1.0f, 0.0f),
                new Vector4(0.0f, 0.0f, 0.0f, 1.0f)
            );

            bool isRotateAroundX = false; if (isRotateAroundX) pConstantBuffer[0] = new Matrix4x4(
                new Vector4(1.0f, 0.0f, 0.0f, 0.0f),
                new Vector4(0.0f, +cos, -sin, 0.0f),
                new Vector4(0.0f, +sin, +cos, 0.0f),
                new Vector4(0.0f, 0.0f, 0.0f, 1.0f)
            );

            bool isRotateAroundY = false; if (isRotateAroundY) pConstantBuffer[0] = new Matrix4x4(
                new Vector4(+cos, 0.0f, -sin, 0.0f),
                new Vector4(0.0f, 1.0f, 0.0f, 0.0f),
                new Vector4(+sin, 0.0f, +cos, 0.0f),
                new Vector4(0.0f, 0.0f, 0.0f, 1.0f)
            );

            bool isRotateAroundZ = true; if (isRotateAroundZ) pConstantBuffer[0] = new Matrix4x4(
                new Vector4(+cos, -sin, 0.0f, 0.0f),
                new Vector4(+sin, +cos, 0.0f, 0.0f),
                new Vector4(0.0f, 0.0f, 1.0f, 0.0f),
                new Vector4(0.0f, 0.0f, 0.0f, 1.0f)
            );

            constantBuffer.Unmap(0..sizeof(Matrix4x4));
        }

        protected override void Draw(GraphicsContext graphicsContext)
        {
            graphicsContext.Draw(_pyramid);
            base.Draw(graphicsContext);
        }

        private unsafe GraphicsPrimitive CreateGraphicsPrimitive(GraphicsContext graphicsContext, GraphicsBuffer vertexStagingBuffer, GraphicsBuffer indexStagingBuffer)
        {
            var graphicsDevice = GraphicsDevice;
            var graphicsSurface = graphicsDevice.Surface;

            var graphicsPipeline = CreateGraphicsPipeline(graphicsDevice, "Transform", "main", "main");
            (List<Vector3> vertices, List<uint> indices) = SierpinskiPyramid.CreateMeshQuad(_recursionDepth);
            List<Vector3> normals = SierpinskiPyramid.MeshNormals(vertices);

            var vertexBuffer = CreateVertexBuffer(vertices, normals, graphicsContext, vertexStagingBuffer, aspectRatio: graphicsSurface.Width / graphicsSurface.Height);
            var indexBuffer = CreateIndexBuffer(indices, graphicsContext, indexStagingBuffer);

            var inputResources = new GraphicsResource[2] {
                CreateConstantBuffer(graphicsContext),
                CreateConstantBuffer(graphicsContext),
                //CreateTexture3D(graphicsContext, textureStagingBuffer),
            };
            return graphicsDevice.CreatePrimitive(graphicsPipeline, new GraphicsBufferView(vertexBuffer, vertexBuffer.Size, SizeOf<IdentityVertex>()), new GraphicsBufferView(indexBuffer, indexBuffer.Size, sizeof(uint)), inputResources);

            static GraphicsBuffer CreateVertexBuffer(List<Vector3> vertices, List<Vector3> normals, GraphicsContext graphicsContext, GraphicsBuffer vertexStagingBuffer, float aspectRatio)
            {
                int size = sizeof(IdentityVertex) * vertices.Count;
                var vertexBuffer = graphicsContext.Device.MemoryAllocator.CreateBuffer(GraphicsBufferKind.Vertex, GraphicsResourceCpuAccess.None, (ulong)size);
                var pVertexBuffer = vertexStagingBuffer.Map<IdentityVertex>();

                for (int i = 0; i < vertices.Count; i++)
                {
                    var xyz = vertices[i];                // position
                    pVertexBuffer[i] = new IdentityVertex {
                        Position = xyz,
                        Color = new Vector4(xyz.X, xyz.Y, 0.5f, 1.0f),
                    };
                }

                vertexStagingBuffer.Unmap(0..size);
                graphicsContext.Copy(vertexBuffer, vertexStagingBuffer);

                return vertexBuffer;
            }

            static GraphicsBuffer CreateIndexBuffer(List<uint> indices, GraphicsContext graphicsContext, GraphicsBuffer indexStagingBuffer)
            {
                int size = sizeof(uint) * indices.Count;
                var indexBuffer = graphicsContext.Device.MemoryAllocator.CreateBuffer(GraphicsBufferKind.Index, GraphicsResourceCpuAccess.None, (ulong)size);
                var pIndexBuffer = indexStagingBuffer.Map<uint>();

                for (int i = 0; i < indices.Count; i++)
                {
                    pIndexBuffer[i] = indices[i];
                }

                indexStagingBuffer.Unmap(0..size);
                graphicsContext.Copy(indexBuffer, indexStagingBuffer);

                return indexBuffer;
            }

            static GraphicsBuffer CreateConstantBuffer(GraphicsContext graphicsContext)
            {
                var constantBuffer = graphicsContext.Device.MemoryAllocator.CreateBuffer(GraphicsBufferKind.Constant, GraphicsResourceCpuAccess.Write, 256);

                var pConstantBuffer = constantBuffer.Map<Matrix4x4>();
                pConstantBuffer[0] = Matrix4x4.Identity;
                constantBuffer.Unmap(0..sizeof(Matrix4x4));

                return constantBuffer;
            }


            GraphicsPipeline CreateGraphicsPipeline(GraphicsDevice graphicsDevice, string shaderName, string vertexShaderEntryPoint, string pixelShaderEntryPoint)
            {
                var signature = CreateGraphicsPipelineSignature(graphicsDevice);
                var vertexShader = CompileShader(graphicsDevice, GraphicsShaderKind.Vertex, shaderName, vertexShaderEntryPoint);
                var pixelShader = CompileShader(graphicsDevice, GraphicsShaderKind.Pixel, shaderName, pixelShaderEntryPoint);

                return graphicsDevice.CreatePipeline(signature, vertexShader, pixelShader);
            }

            GraphicsPipelineSignature CreateGraphicsPipelineSignature(GraphicsDevice graphicsDevice)
            {
                var inputs = new GraphicsPipelineInput[1] {
                    new GraphicsPipelineInput(
                        new GraphicsPipelineInputElement[2] {
                            new GraphicsPipelineInputElement(typeof(Vector3), GraphicsPipelineInputElementKind.Position, size: 12),
                            new GraphicsPipelineInputElement(typeof(Vector4), GraphicsPipelineInputElementKind.Color, size: 16),
                        }
                    ),
                };

                var resources = new GraphicsPipelineResource[2] {
                    new GraphicsPipelineResource(GraphicsPipelineResourceKind.ConstantBuffer, GraphicsShaderVisibility.Vertex),
                    new GraphicsPipelineResource(GraphicsPipelineResourceKind.ConstantBuffer, GraphicsShaderVisibility.Vertex),
                    //new GraphicsPipelineResource(GraphicsPipelineResourceKind.Texture, GraphicsShaderVisibility.Pixel),
                };

                return graphicsDevice.CreatePipelineSignature(inputs, resources);
            }
        }
    }
}
