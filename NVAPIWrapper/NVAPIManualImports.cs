using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace NVAPIWrapper
{
    public static unsafe partial class NVAPI
    {
        /// <summary>
        /// Initializes all ClangSharp-generated <c>delegate*</c> function-pointer
        /// fields by resolving each function through <c>NvAPI_QueryInterface</c>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The NVAPI DLL (<c>nvapi64.dll</c>) does not export individual functions
        /// as named symbols. Instead, every function must be resolved at runtime via
        /// <c>NvAPI_QueryInterface(uint id)</c>. ClangSharp generates the matching
        /// <c>delegate* unmanaged[Cdecl]&lt;...&gt;</c> fields (via
        /// <c>--with-manual-import</c>), and this method populates them.
        /// </para>
        /// <para>
        /// The interface IDs come from <see cref="NVAPIInterfaceTable"/>, which is
        /// auto-generated from <c>nvapi_interface.h</c>.
        /// </para>
        /// </remarks>
        /// <param name="queryInterface">
        /// The <c>NvAPI_QueryInterface</c> delegate obtained from the loaded NVAPI DLL.
        /// </param>
        /// <returns>
        /// The number of function-pointer fields that were successfully resolved.
        /// </returns>
        internal static int InitializeManualImports(NVAPINative.NvApiQueryInterfaceDelegate queryInterface)
        {
            if (queryInterface == null)
                throw new ArgumentNullException(nameof(queryInterface));

            // Build a name -> ID lookup from the interface table.
            var lookup = new Dictionary<string, uint>(NVAPIInterfaceTable.Entries.Length, StringComparer.Ordinal);
            foreach (var entry in NVAPIInterfaceTable.Entries)
            {
                if (!string.IsNullOrEmpty(entry.Name))
                    lookup[entry.Name] = entry.Id;
            }

            int resolved = 0;

            // Iterate every public static field on the NVAPI class.
            foreach (var field in typeof(NVAPI).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                // Only process function-pointer fields (delegate* unmanaged[Cdecl]<...>).
                if (!field.FieldType.IsFunctionPointer)
                    continue;

                // Look up the QueryInterface ID by field name.
                if (!lookup.TryGetValue(field.Name, out var id))
                    continue;

                // Resolve the function pointer via QueryInterface.
                var ptr = queryInterface(id);
                if (ptr == IntPtr.Zero)
                    continue;

                // Write the resolved pointer into the static field.
                // delegate* fields are nint-sized at the IL level; we use
                // Unsafe.As on the field's static backing to write directly.
                field.SetValue(null, (nint)ptr);
                resolved++;
            }

            return resolved;
        }

        /// <summary>
        /// Resets all ClangSharp-generated <c>delegate*</c> function-pointer fields
        /// to <c>null</c>. Must be called before <c>FreeLibrary</c> to prevent
        /// dangling pointers into the unloaded DLL from blocking process shutdown.
        /// </summary>
        internal static void ClearManualImports()
        {
            foreach (var field in typeof(NVAPI).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                if (!field.FieldType.IsFunctionPointer)
                    continue;

                field.SetValue(null, (nint)0);
            }
        }
    }
}
