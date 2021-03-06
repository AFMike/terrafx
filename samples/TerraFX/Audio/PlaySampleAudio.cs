// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.IO.Pipelines;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TerraFX.ApplicationModel;
using TerraFX.Audio;
using TerraFX.Audio.Providers.PulseAudio;
using TerraFX.Utilities;

namespace TerraFX.Samples.Audio
{
    public sealed class PlaySampleAudio : Sample
    {
        // Middle C is 261.626 Hz. Guess what note this is :)
        public const double SineWaveFrequency = 277.18;

        // Multiplication factor to generate the above frequency sine wave at a specified sample rate (CD Audio, 44.1KHz in this case)
        public const double SineWaveRate = SineWaveFrequency * 2 * Math.PI / WellKnownSampleRates.CdAudio;

        // Current position in sine wave, in samples
        private int _samplePosition;
        private IAudioProvider? _provider;

        public PlaySampleAudio(string name, params Assembly[] compositionAssemblies)
            : base(name, compositionAssemblies)
        {
            _provider = null;
        }

        public override void Initialize(Application application, TimeSpan timeout)
        {
            _provider = application.GetService<IAudioProvider>();

            var task = _provider.StartAsync();
            if (!task.IsCompleted)
            {
                task.AsTask().Wait();
            }

            base.Initialize(application, timeout);
        }

        public override void Cleanup()
        {
            ExceptionUtilities.ThrowIfNull(_provider, nameof(_provider));

            var task = _provider.StopAsync();
            if (!task.IsCompleted)
            {
                task.AsTask().Wait();
            }

            base.Cleanup();
        }

        protected override void OnIdle(object? sender, ApplicationIdleEventArgs eventArgs)
        {
            ExceptionUtilities.ThrowIfNull(sender, nameof(sender));

            var application = (Application)sender;
            RunAsync(application).Wait();
        }

        private async Task RunAsync(Application application)
        {
            ExceptionUtilities.ThrowIfNull(_provider, nameof(_provider));

            IAudioAdapter? preferredAdapter = null;
            await foreach (var audioAdapter in _provider.EnumerateAudioDevices())
            {
                if (audioAdapter is PulseSinkAdapter sinkAdapter)
                {
                    if (audioAdapter.BitDepth == 16 &&
                        audioAdapter.Channels == 2 &&
                        audioAdapter.SampleRate == WellKnownSampleRates.CdAudio &&
                        audioAdapter.IsBigEndian == false &&
                        sinkAdapter.IsUnsigned == false)
                    {
                        preferredAdapter = audioAdapter;
                        Console.WriteLine($"    Found possible audio adapter: {audioAdapter.Name}");
                    }
                }
            }

            if (preferredAdapter != null)
            {
                var device = await _provider.RequestAudioPlaybackDeviceAsync(preferredAdapter);

                Console.WriteLine($"    Playing a {SineWaveFrequency}Hz sine wave...");

                await Task.WhenAll(
                    ProduceAudioAsync(device.Writer),
                    RunDeviceAsync(device)
                );
            }

            application.RequestExit();
        }

        private Task ProduceAudioAsync(PipeWriter writer)
        {
            return Task.Run(ProduceInternalAsync);

            async Task ProduceInternalAsync()
            {
                FlushResult result = default;
                while (!result.IsCompleted)
                {
                    ComputeAudioWaveBlock(writer, ref _samplePosition);

                    result = await writer.FlushAsync();
                }
            }

            static void ComputeAudioWaveBlock(PipeWriter writer, ref int samplePosition)
            {
                var block = writer.GetSpan();
                var buffer = MemoryMarshal.Cast<byte, short>(block);

                for (var x = 0; x < buffer.Length; x += 2)
                {
                    var value = (short)(Math.Sin(samplePosition * SineWaveRate) * short.MaxValue);

                    buffer[x] = value;
                    buffer[x + 1] = value;
                    // Allow overflows to prevent exceptions. This may cause artifacting, but it's unlikely we'll be played for this long enough to matter
                    unchecked { samplePosition += 1; }
                }

                writer.Advance(block.Length);
            }
        }

        private Task RunDeviceAsync(IAudioPlaybackDevice device)
        {
            return Task.Run(RunInternalAsync);

            async Task RunInternalAsync()
            {
                await device.RunAsync();
            }
        }
    }
}
