// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um\synchapi.h in the Windows SDK for Windows 10.0.15063.0
// Original source is Copyright © Microsoft. All rights reserved.

using System.Runtime.InteropServices;
using System.Security;

namespace TerraFX.Interop
{
    public static partial class Kernel32
    {
        #region Extern Methods
        [DllImport("Kernel32", BestFitMapping = false, CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, EntryPoint = "CreateEventW", ExactSpelling = true, PreserveSig = true, SetLastError = true, ThrowOnUnmappableChar = false)]
        [SuppressUnmanagedCodeSecurity]
        public static extern HANDLE CreateEvent(
            [In, Optional] LPSECURITY_ATTRIBUTES lpEventAttributes,
            [In] BOOL bManualReset,
            [In] BOOL bInitialState,
            [In, Optional] LPCWSTR lpName
        );

        [DllImport("Kernel32", BestFitMapping = false, CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, EntryPoint = "WaitForSingleObject", ExactSpelling = true, PreserveSig = true, SetLastError = true, ThrowOnUnmappableChar = false)]
        [SuppressUnmanagedCodeSecurity]
        public static extern DWORD WaitForSingleObject(
            [In] HANDLE hHandle,
            [In] DWORD dwMilliseconds
        );
        #endregion
    }
}
