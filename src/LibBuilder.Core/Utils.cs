// project=LibBuilder.Core, file=Utils.cs, create=09:16 Copyright (c) 2021 Timeline
// Financials GmbH & Co. KG. All rights reserved.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace LibBuilder.Core
{
    /// <summary>
    /// Utils.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Attaches the console.
        /// </summary>
        /// <param name="processId">The process identifier.</param>
        /// <returns></returns>
        [DllImport("Kernel32.dll")]
        public static extern bool AttachConsole(int processId);

        /// <summary>
        /// Überprüft ob Orca DLL vorhanden ist, indem eine Session geöffnet und dann
        /// wieder geschlossen wird.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <returns></returns>
        public static bool CheckLibrary(PBDotNet.Core.orca.Orca.Version version)
        {
            try
            {
                PBDotNet.Core.orca.Orca orca = new PBDotNet.Core.orca.Orca(version, true);
                orca.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="enumVal">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        /// <example>
        /// <![CDATA[string desc =
        /// myEnumVariable.GetAttributeOfType<DescriptionAttribute>().Description;]]>
        /// </example>
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        /// <summary>
        /// Determines whether [is null or empty].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <returns>
        /// <c>true</c> if [is null or empty] [the specified enumerable]; otherwise,
        /// <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }
    }
}