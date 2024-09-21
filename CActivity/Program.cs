using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace CActivity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool IsExistError = false;
            string ErrorMessage = string.Empty;
            string TargetAddress = string.Empty;
            string ResultAddress = string.Empty;
            PingReply reply = null;

            Ping pingSender = new Ping();

            if (args.Length > 0)
            {
                TargetAddress = args[0].Trim();
            }
            else
            {
                Console.WriteLine("No parameters.");
                return;
            }

            try
            {
                reply = pingSender.Send(TargetAddress, 100);
            }
            catch (Exception ex)
            {
                IsExistError = true;
                ErrorMessage = ex.Message;
            }

            if (IsExistError)
            {
                ResultAddress = args[0].Trim();
                Console.WriteLine("Target: {0}, Status: Unknown Error - {1}.", TargetAddress, ErrorMessage);
            }
            else if (reply.Status == IPStatus.Success)
            {
                ResultAddress = reply.Address.ToString();
                Console.WriteLine("Target: {0}[{1}], Status: Echo OK.", TargetAddress, ResultAddress);
            }
            else
            {
                try
                {
                    ResultAddress = TargetAddress + "[" + reply.Address.ToString() + "]";
                }
                catch
                {
                    ResultAddress = TargetAddress;
                }

                if (reply.Status == IPStatus.TimedOut)
                {
                    Console.WriteLine("Target: {0}, Status: Time out.", ResultAddress);
                }
                else if (reply.Status == IPStatus.BadDestination)
                {
                    Console.WriteLine("Target: {0}, Status: Bad destination.", ResultAddress);
                }
                else if (reply.Status == IPStatus.BadOption)
                {
                    Console.WriteLine("Target: {0}, Status: Bad option.", ResultAddress);
                }
                else if (reply.Status == IPStatus.BadRoute)
                {
                    Console.WriteLine("Target: {0}, Status: Bad route.", ResultAddress);
                }
                else if (reply.Status == IPStatus.HardwareError)
                {
                    Console.WriteLine("Target: {0}, Status: Hardware error.", ResultAddress);
                }
                else if (reply.Status == IPStatus.IcmpError)
                {
                    Console.WriteLine("Target: {0}, Status: ICMP error.", ResultAddress);
                }
                else if (reply.Status == IPStatus.TtlExpired)
                {
                    Console.WriteLine("Target: {0}, Status: TTL expired.", ResultAddress);
                }
                else if (reply.Status == IPStatus.NoResources)
                {
                    Console.WriteLine("Target: {0}, Status: No resources.", ResultAddress);
                }
                else
                {
                    Console.WriteLine("Target: {0}, Status: Unknown Error - {1}.", ResultAddress, reply.Status.ToString());
                }
            }

            reply = null;
            pingSender = null;
        }
    }
}
