using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace DesktopNote
{
    internal class RegistryUtil
    {
        private static readonly string RegistrySubKey = "Software\\Urabe-san\\DesktopNote";
        private static readonly string RegistrySubKeyBase = RegistrySubKey;

        // // Exanple for 'SubKeyExists' and 'ValueExists'.
        //if (SubKeyExists("Software\\YourCompanyName"))
        //{
        //    Console.WriteLine("Subkey 'Software\\YourCompanyName' exists.");
        //}
        //else
        //{
        //    Console.WriteLine("Subkey 'Software\\YourCompanyName' does not exist.");
        //}

        //if (ValueExists("WindowWidth"))
        //{
        //    Console.WriteLine("Value 'WindowWidth' exists.");
        //}
        //else
        //{
        //    Console.WriteLine("Value 'WindowWidth' does not exist.");
        //}


        /// <summary>
        /// Checks if the specified registry subkey exists under HKEY_CURRENT_USER.
        /// </summary>
        /// <param name="subKeyPath">The path of the subkey to check (relative to HKEY_CURRENT_USER).</param>
        /// <returns>True if the subkey exists, otherwise false.</returns>
        public static bool SubKeyExists(string subKeyPath)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(subKeyPath))
                {
                    return key != null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while checking if the subkey exists: {ex.Message}");
                return false; // Assume it doesn't exist in case of an error
            }
        }

        /// <summary>
        /// Checks if the specified value (entry) exists under the application's registry subkey.
        /// </summary>
        /// <param name="valueName">The name of the value to check.</param>
        /// <returns>True if the value exists, otherwise false.</returns>
        public static bool ValueExists(string valueName)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistrySubKey))
                {
                    if (key != null)
                    {
                        return key.GetValue(valueName) != null;
                    }
                    return false; // Key doesn't exist, so the value can't exist
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while checking if the value exists: {ex.Message}");
                return false; // Assume it doesn't exist in case of an error
            }
        }

        /// <summary>
        /// Writes a value to the registry (CurrentUser).
        /// </summary>
        /// <param name="valueName">The name of the value to write.</param>
        /// <param name="value">The value to write.</param>
        public static void WriteRegistryValue(string valueName, object value)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistrySubKey))
                {
                    if (key != null)
                    {
                        key.SetValue(valueName, value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while writing to the registry: {ex.Message}");
                // Add error handling as needed
            }
        }

        /// <summary>
        /// Reads a value from the registry (CurrentUser).
        /// </summary>
        /// <param name="valueName">The name of the value to read.</param>
        /// <param name="defaultValue">The default value to return if the value does not exist.</param>
        /// <returns>The read value. Returns defaultValue if the value does not exist.</returns>
        public static string ReadRegistryValue(string valueName, string defaultValue)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistrySubKey))
                {
                    if (key != null)
                    {
                        object value = key.GetValue(valueName);
                        if (value != null)
                        {
                            return value.ToString();
                        }
                    }
                }
                return defaultValue; // Return default value if the value does not exist
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading from the registry: {ex.Message}");
                return defaultValue; // Return default value in case of an error
            }
        }

        // Overloads for reading other data types (int, bool, etc.) can be created as needed
        /// <summary>
        /// Reads an integer value from the registry (CurrentUser).
        /// </summary>
        /// <param name="valueName">The name of the value to read.</param>
        /// <param name="defaultValue">The default value to return if the value does not exist or cannot be parsed as an integer.</param>
        /// <returns>The read integer value. Returns defaultValue if the value does not exist or cannot be parsed.</returns>
        public static int ReadRegistryValueInt(string valueName, int defaultValue)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistrySubKey))
                {
                    if (key != null)
                    {
                        object value = key.GetValue(valueName);
                        if (value != null && int.TryParse(value.ToString(), out int result))
                        {
                            return result;
                        }
                    }
                }
                return defaultValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading from the registry: {ex.Message}");
                return defaultValue;
            }
        }

        /// <summary>
        /// Deletes the registry hierarchy for the specified application under CurrentUser.
        /// </summary>
        public static void DeleteRegistrySubKey()
        {
            try
            {
                //using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistrySubKey, true)) // Write permission is required
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistrySubKeyBase, true)) // Write permission is required
                {
                    if (key != null)
                    {
                        key.DeleteSubKeyTree("DesktopNote", false); // Specifying false prevents an exception if the subkey does not exist
                        //Console.WriteLine("Deleted the registry key '" + RegistrySubKey +  "'.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the registry key: {ex.Message}");
                // Add error handling as needed
            }
        }
    }
}
