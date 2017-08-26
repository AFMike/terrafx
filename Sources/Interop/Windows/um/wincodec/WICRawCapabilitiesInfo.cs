// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um\wincodec.h in the Windows SDK for Windows 10.0.15063.0
// Original source is Copyright © Microsoft. All rights reserved.

using System.Runtime.InteropServices;

namespace TerraFX.Interop
{
    public /* blittable */ struct WICRawCapabilitiesInfo
    {
        #region Fields
        [ComAliasName("UINT")]
        public uint cbSize;

        [ComAliasName("UINT")]
        public uint CodecMajorVersion;

        [ComAliasName("UINT")]
        public uint CodecMinorVersion;

        public WICRawCapabilities ExposureCompensationSupport;

        public WICRawCapabilities ContrastSupport;

        public WICRawCapabilities RGBWhitePointSupport;

        public WICRawCapabilities NamedWhitePointSupport;

        [ComAliasName("UINT")]
        public uint NamedWhitePointSupportMask;

        public WICRawCapabilities KelvinWhitePointSupport;

        public WICRawCapabilities GammaSupport;

        public WICRawCapabilities TintSupport;

        public WICRawCapabilities SaturationSupport;

        public WICRawCapabilities SharpnessSupport;

        public WICRawCapabilities NoiseReductionSupport;

        public WICRawCapabilities DestinationColorProfileSupport;

        public WICRawCapabilities ToneCurveSupport;

        public WICRawRotationCapabilities RotationSupport;

        public WICRawCapabilities RenderModeSupport;
        #endregion
    }
}
