using System;
using System.Runtime.InteropServices;
using TerraFX.Audio;
using TerraFX.Interop;

namespace TerraFX.Provider.PulseAudio.Audio
{
    /// <inhertidoc />
    public class PulseSourceAdapter : IAudioAdapter
    {
        internal unsafe PulseSourceAdapter(pa_source_info* i)
        {
            Name = Marshal.PtrToStringUTF8((IntPtr)i->name);
            Description = Marshal.PtrToStringUTF8((IntPtr)i->description);
            SampleRate = (int)i->sample_spec.rate;
            Channels = i->sample_spec.channels;

            var format = i->sample_spec.format;
            switch (format)
            {
                case pa_sample_format.PA_SAMPLE_U8:
                case pa_sample_format.PA_SAMPLE_ALAW:
                case pa_sample_format.PA_SAMPLE_ULAW:
                    IsUnsigned = true;
                    BitDepth = 8;
                    PackedSize = 8;
                    IsBigEndian = false;
                    break;
                case pa_sample_format.PA_SAMPLE_S16LE:
                case pa_sample_format.PA_SAMPLE_S16BE:
                    IsUnsigned = false;
                    BitDepth = 16;
                    PackedSize = 16;
                    IsBigEndian = format == pa_sample_format.PA_SAMPLE_S16BE;
                    break;
                case pa_sample_format.PA_SAMPLE_FLOAT32LE:
                case pa_sample_format.PA_SAMPLE_FLOAT32BE:
                    IsUnsigned = false;
                    BitDepth = 32;
                    PackedSize = 23;
                    IsBigEndian = format == pa_sample_format.PA_SAMPLE_FLOAT32BE;
                    IsFloatingPoint = true;
                    break;
                case pa_sample_format.PA_SAMPLE_S32LE:
                case pa_sample_format.PA_SAMPLE_S32BE:
                    IsUnsigned = false;
                    BitDepth = 32;
                    PackedSize = 32;
                    IsBigEndian = format == pa_sample_format.PA_SAMPLE_S32BE;
                    IsFloatingPoint = false;
                    break;
                case pa_sample_format.PA_SAMPLE_S24LE:
                case pa_sample_format.PA_SAMPLE_S24BE:
                    IsUnsigned = false;
                    BitDepth = 24;
                    PackedSize = 24;
                    IsBigEndian = format == pa_sample_format.PA_SAMPLE_S32BE;
                    IsFloatingPoint = false;
                    break;
                case pa_sample_format.PA_SAMPLE_S24_32LE:
                case pa_sample_format.PA_SAMPLE_S24_32BE:
                    IsUnsigned = false;
                    BitDepth = 24;
                    PackedSize = 32;
                    IsBigEndian = format == pa_sample_format.PA_SAMPLE_S24_32BE;
                    IsFloatingPoint = false;
                    break;
                case pa_sample_format.PA_SAMPLE_MAX:
                case pa_sample_format.PA_SAMPLE_INVALID:
                default:
                    // TODO: localize
                    throw new InvalidOperationException("Invalid sample format");
            }
        }

        /// <inhertidoc />
        public AudioDeviceType DeviceType { get; set; } = AudioDeviceType.Recording;

        /// <inhertidoc />
        public string Name { get; set; }

        /// <summary>Gets a string representing the description of this device.</summary>
        public string Description { get; set; }

        /// <inhertidoc />
        public int SampleRate { get; set; }

        /// <inhertidoc />
        public int BitDepth { get; set; }

        /// <inhertidoc />
        public int Channels { get; set; }

        /// <inhertidoc />
        public bool IsBigEndian { get; set; }

        /// <summary>Gets a value representing whether the adapter sample format is unsigned or not.</summary>
        public bool IsUnsigned { get; set; }

        /// <summary>Gets a value representing whether the adapter sample format uses floating point or not.</summary>
        public bool IsFloatingPoint { get; set; }

        /// <summary>Gets a value representing the packed sample size in bits.</summary>
        public int PackedSize { get; set; }
    }
}
