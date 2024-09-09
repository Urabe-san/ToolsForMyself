using System;
using System.Management;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("ネットワークアダプターの名称を引数として渡してください。");
            return;
        }

        string adapterName = args[0];
        SetDnsToAuto(adapterName);
    }

    static void SetDnsToAuto(string adapterName)
    {
        try
        {
            string query = $"SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionID = '{adapterName}'";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection adapters = searcher.Get();

            foreach (ManagementObject adapter in adapters)
            {
                string adapterId = adapter["DeviceID"].ToString();
                string query2 = $"SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Index = {adapterId}";
                ManagementObjectSearcher searcher2 = new ManagementObjectSearcher(query2);
                ManagementObjectCollection configurations = searcher2.Get();

                foreach (ManagementObject config in configurations)
                {
                    if ((bool)config["IPEnabled"])
                    {
                        ManagementBaseObject newDns = config.GetMethodParameters("SetDNSServerSearchOrder");
                        newDns["DNSServerSearchOrder"] = null; // 自動取得に設定
                        config.InvokeMethod("SetDNSServerSearchOrder", newDns, null);
                        Console.WriteLine("DNS設定を自動取得に変更しました。");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"エラーが発生しました: {ex.Message}");
        }
    }
}
