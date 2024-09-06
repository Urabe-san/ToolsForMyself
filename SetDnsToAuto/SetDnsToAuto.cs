﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Net.NetworkInformation;

namespace SetDnsToAuto
{
    public partial class SetDnsToAuto : Form
    {
        public SetDnsToAuto()
        {
            InitializeComponent();
        }

        private void SetDnsToAuto_Load(object sender, EventArgs e)
        {
            textboxTargetAdapter.Text = GetCurrentNetworkAdaputerName();

            if(string.IsNullOrEmpty(textboxTargetAdapter.Text))
            {
                buttonExecute.Enabled = false;
            }
            else
            {
                buttonExecute.Enabled = true;
            }
        }


        private void buttonExecute_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textboxTargetAdapter.Text))
            {
                SetDnsSettingToAuto(textboxTargetAdapter.Text);
            }
        }

        private string GetCurrentNetworkAdaputerName()
        {
            string result = string.Empty;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    result = nic.Name;
                }
            }

            return result;
        }

        private void SetDnsSettingToAuto(string adapterName)
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
                            //Console.WriteLine("DNS設定を自動取得に変更しました。");
                            MessageBox.Show("DNS設定を自動取得に変更しました。", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"エラーが発生しました: {ex.Message}");
                MessageBox.Show($"エラーが発生しました: {ex.Message}", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}
