// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um\wincodecsdk.h in the Windows SDK for Windows 10.0.15063.0
// Original source is Copyright © Microsoft. All rights reserved.

using System;
using System.Runtime.InteropServices;
using System.Security;
using static TerraFX.Utilities.InteropUtilities;

namespace TerraFX.Interop
{
    [Guid("F7836E16-3BE0-470B-86BB-160D0AECD7DE")]
    public /* blittable */ unsafe struct IWICMetadataWriter
    {
        #region Fields
        public readonly Vtbl* lpVtbl;
        #endregion

        #region IUnknown Delegates
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _QueryInterface(
            [In] IWICMetadataWriter* This,
            [In, ComAliasName("REFIID")] Guid* riid,
            [Out] void** ppvObject
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("ULONG")]
        public /* static */ delegate uint _AddRef(
            [In] IWICMetadataWriter* This
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("ULONG")]
        public /* static */ delegate uint _Release(
            [In] IWICMetadataWriter* This
        );
        #endregion

        #region IWICMetadataReader Delegates
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetMetadataFormat(
            [In] IWICMetadataWriter* This,
            [Out, ComAliasName("GUID")] Guid* pguidMetadataFormat
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetMetadataHandlerInfo(
            [In] IWICMetadataWriter* This,
            [Out] IWICMetadataHandlerInfo** ppIHandler = null
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetCount(
            [In] IWICMetadataWriter* This,
            [Out, ComAliasName("UINT")] uint* pcCount
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetValueByIndex(
            [In] IWICMetadataWriter* This,
            [In, ComAliasName("UINT")] uint nIndex,
            [In, Out] PROPVARIANT* pvarSchema = null,
            [In, Out] PROPVARIANT* pvarId = null,
            [In, Out] PROPVARIANT* pvarValue = null
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetValue(
            [In] IWICMetadataWriter* This,
            [In, Optional] PROPVARIANT* pvarSchema,
            [In] PROPVARIANT* pvarId,
            [In, Out] PROPVARIANT* pvarValue = null
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _GetEnumerator(
            [In] IWICMetadataWriter* This,
            [Out] IWICEnumMetadataItem** ppIEnumMetadata = null
        );
        #endregion

        #region Delegates
        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _SetValue(
            [In] IWICMetadataWriter* This,
            [In, Optional] PROPVARIANT* pvarSchema,
            [In] PROPVARIANT* pvarId,
            [In] PROPVARIANT* pvarValue
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _SetValueByIndex(
            [In] IWICMetadataWriter* This,
            [In, ComAliasName("UINT")] uint nIndex,
            [In, Optional] PROPVARIANT* pvarSchema,
            [In] PROPVARIANT* pvarId,
            [In] PROPVARIANT* pvarValue
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _RemoveValue(
            [In] IWICMetadataWriter* This,
            [In, Optional] PROPVARIANT* pvarSchema,
            [In] PROPVARIANT* pvarId
        );

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall, BestFitMapping = false, CharSet = CharSet.Unicode, SetLastError = false, ThrowOnUnmappableChar = false)]
        [return: ComAliasName("HRESULT")]
        public /* static */ delegate int _RemoveValueByIndex(
            [In] IWICMetadataWriter* This,
            [In, ComAliasName("UINT")] uint nIndex
        );
        #endregion

        #region IUnknown Methods
        [return: ComAliasName("HRESULT")]
        public int QueryInterface(
            [In, ComAliasName("REFIID")] Guid* riid,
            [Out] void** ppvObject
        )
        {
            fixed (IWICMetadataWriter* This = &this)
            {
                return MarshalFunction<_QueryInterface>(lpVtbl->QueryInterface)(
                    This,
                    riid,
                    ppvObject
                );
            }
        }

        [return: ComAliasName("ULONG")]
        public uint AddRef()
        {
            fixed (IWICMetadataWriter* This = &this)
            {
                return MarshalFunction<_AddRef>(lpVtbl->AddRef)(
                    This
                );
            }
        }

        [return: ComAliasName("ULONG")]
        public uint Release()
        {
            fixed (IWICMetadataWriter* This = &this)
            {
                return MarshalFunction<_Release>(lpVtbl->Release)(
                    This
                );
            }
        }
        #endregion

        #region IWICMetadataReader Methods
        [return: ComAliasName("HRESULT")]
        public int GetMetadataFormat(
            [Out, ComAliasName("GUID")] Guid* pguidMetadataFormat
        )
        {
            fixed (IWICMetadataWriter* This = &this)
            {
                return MarshalFunction<_GetMetadataFormat>(lpVtbl->GetMetadataFormat)(
                    This,
                    pguidMetadataFormat
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetMetadataHandlerInfo(
            [Out] IWICMetadataHandlerInfo** ppIHandler = null
        )
        {
            fixed (IWICMetadataWriter* This = &this)
            {
                return MarshalFunction<_GetMetadataHandlerInfo>(lpVtbl->GetMetadataHandlerInfo)(
                    This,
                    ppIHandler
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetCount(
            [Out, ComAliasName("UINT")] uint* pcCount
        )
        {
            fixed (IWICMetadataWriter* This = &this)
            {
                return MarshalFunction<_GetCount>(lpVtbl->GetCount)(
                    This,
                    pcCount
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetValueByIndex(
            [In, ComAliasName("UINT")] uint nIndex,
            [In, Out] PROPVARIANT* pvarSchema = null,
            [In, Out] PROPVARIANT* pvarId = null,
            [In, Out] PROPVARIANT* pvarValue = null
        )
        {
            fixed (IWICMetadataWriter* This = &this)
            {
                return MarshalFunction<_GetValueByIndex>(lpVtbl->GetValueByIndex)(
                    This,
                    nIndex,
                    pvarSchema,
                    pvarId,
                    pvarValue
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetValue(
            [In, Optional] PROPVARIANT* pvarSchema,
            [In] PROPVARIANT* pvarId,
            [In, Out] PROPVARIANT* pvarValue = null
        )
        {
            fixed (IWICMetadataWriter* This = &this)
            {
                return MarshalFunction<_GetValue>(lpVtbl->GetValue)(
                    This,
                    pvarSchema,
                    pvarId,
                    pvarValue
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int GetEnumerator(
            [Out] IWICEnumMetadataItem** ppIEnumMetadata = null
        )
        {
            fixed (IWICMetadataWriter* This = &this)
            {
                return MarshalFunction<_GetEnumerator>(lpVtbl->GetEnumerator)(
                    This,
                    ppIEnumMetadata
                );
            }
        }
        #endregion

        #region Methods
        [return: ComAliasName("HRESULT")]
        public int SetValue(
            [In, Optional] PROPVARIANT* pvarSchema,
            [In] PROPVARIANT* pvarId,
            [In] PROPVARIANT* pvarValue
        )
        {
            fixed (IWICMetadataWriter* This = &this)
            {
                return MarshalFunction<_SetValue>(lpVtbl->SetValue)(
                    This,
                    pvarSchema,
                    pvarId,
                    pvarValue
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int SetValueByIndex(
            [In, ComAliasName("UINT")] uint nIndex,
            [In, Optional] PROPVARIANT* pvarSchema,
            [In] PROPVARIANT* pvarId,
            [In] PROPVARIANT* pvarValue
        )
        {
            fixed (IWICMetadataWriter* This = &this)
            {
                return MarshalFunction<_SetValueByIndex>(lpVtbl->SetValueByIndex)(
                    This,
                    nIndex,
                    pvarSchema,
                    pvarId,
                    pvarValue
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int RemoveValue(
            [In, Optional] PROPVARIANT* pvarSchema,
            [In] PROPVARIANT* pvarId
        )
        {
            fixed (IWICMetadataWriter* This = &this)
            {
                return MarshalFunction<_RemoveValue>(lpVtbl->RemoveValue)(
                    This,
                    pvarSchema,
                    pvarId
                );
            }
        }

        [return: ComAliasName("HRESULT")]
        public int RemoveValueByIndex(
            [In, ComAliasName("UINT")] uint nIndex
        )
        {
            fixed (IWICMetadataWriter* This = &this)
            {
                return MarshalFunction<_RemoveValueByIndex>(lpVtbl->RemoveValueByIndex)(
                    This,
                    nIndex
                );
            }
        }
        #endregion

        #region Structs
        public /* blittable */ struct Vtbl
        {
            #region IUnknown Fields
            public IntPtr QueryInterface;

            public IntPtr AddRef;

            public IntPtr Release;
            #endregion

            #region IWICMetadataReader Fields
            public IntPtr GetMetadataFormat;

            public IntPtr GetMetadataHandlerInfo;

            public IntPtr GetCount;

            public IntPtr GetValueByIndex;

            public IntPtr GetValue;

            public IntPtr GetEnumerator;
            #endregion

            #region Fields
            public IntPtr SetValue;

            public IntPtr SetValueByIndex;

            public IntPtr RemoveValue;

            public IntPtr RemoveValueByIndex;
            #endregion
        }
        #endregion
    }
}
