using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Management;

namespace GetWinProductKey
{
    class GetWinProductKey
    {
        static void Main(string[] args)
        {
            try
            {
                string productKey = string.Empty;

                productKey = GetWindowsProductKey();

                if (string.IsNullOrEmpty(productKey))
                {
                    SetExecutionPolicy("RemoteSigned");
                    productKey = GetWindowsProductKeyFromPowerShell();
                }

                if (string.IsNullOrEmpty(productKey))
                {
                    productKey = FormatProductKey(GetWindowsProductKeyFromRegistry());
                }

                Console.WriteLine("Windows Product Key: " + productKey);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static string GetWindowsProductKey()
        {
            string productKey = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM SoftwareLicensingService");

            foreach (ManagementObject obj in searcher.Get())
            {
                productKey = obj["OA3xOriginalProductKey"]?.ToString();
                break;
            }

            return productKey;
        }

        static string GetWindowsProductKeyFromRegistry()
        {
            string keyPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            string valueName = "DigitalProductId";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath);
            byte[] digitalProductId = (byte[])key.GetValue(valueName);

            return DecodeProductKey(digitalProductId);
        }

        static string DecodeProductKey(byte[] digitalProductId)
        {
            if(digitalProductId==null)
            {
                return string.Empty;
            }

            const string keyChars = "BCDFGHJKMPQRTVWXY2346789";
            int keyStartIndex = 52;
            int keyEndIndex = keyStartIndex + 15;
            char[] productKey = new char[25];

            for (int i = keyEndIndex; i >= keyStartIndex; i--)
            {
                int current = 0;
                for (int j = 24; j >= 0; j--)
                {
                    current = current * 256 ^ digitalProductId[i];
                    digitalProductId[i] = (byte)(current / 24);
                    current %= 24;
                    productKey[j] = keyChars[current];
                }
            }

            return new string(productKey);
        }

        static string FormatProductKey(string UnformatProductID)
        {
            string FormatProductKey = string.Empty;

            if (UnformatProductID.Length != 25)
            {
                FormatProductKey = UnformatProductID;
            }
            else
            {
                FormatProductKey = UnformatProductID.Substring(0, 5) + "-" + UnformatProductID.Substring(5, 5) + "-" + UnformatProductID.Substring(10, 5) + "-" + UnformatProductID.Substring(15, 5) + "-" + UnformatProductID.Substring(20, 5);
            }
            
            return FormatProductKey;
        }

        static string GetWindowsProductKeyFromPowerShell()
        {
            string script = string.Empty;
            //script = "(Get-WmiObject -query 'select * from SoftwareLicensingService').OA3xOriginalProductKey";
            script = "(Get-CimInstance -Query 'Select * from SoftwareLicensingService').OA3xOriginalProductKey";
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = $"-NoProfile -Command \"{script}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(psi))
            {
                using (System.IO.StreamReader reader = process.StandardOutput)
                {
                    return reader.ReadToEnd().Trim();
                }
            }
        }

        static void SetExecutionPolicy(string policy)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = $"-NoProfile -Command \"Set-ExecutionPolicy -Scope Process -ExecutionPolicy {policy} -Force\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(psi))
            {
                process.WaitForExit();
            }
        }

    }
}
