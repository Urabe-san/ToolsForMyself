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
            PingReply reply = null;

            Ping pingSender = new Ping();

            try
            {
                 reply = pingSender.Send(args[0].Trim(), 100);
            }
            catch (Exception ex)
            {
                IsExistError = true;
                ErrorMessage = ex.Message;
            }

            if (IsExistError)
            {
                Console.WriteLine("Target: {0}, Status: Unknown Error - {1}.", args[0].Trim(), ErrorMessage);
            }
            else if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("Target: {0}, Status: Echo OK.", reply.Address.ToString());
            }
            else
            {
                if (reply.Status == IPStatus.TimedOut)
                {
                    Console.WriteLine("Target: {0}, Status: Time out.", reply.Address.ToString());
                }
                else if (reply.Status == IPStatus.BadDestination)
                {
                    Console.WriteLine("Target: {0}, Status: Bad destination.", reply.Address.ToString());
                }
                else if (reply.Status == IPStatus.BadOption)
                {
                    Console.WriteLine("Target: {0}, Status: Bad option.", reply.Address.ToString());
                }
                else if (reply.Status == IPStatus.BadRoute)
                {
                    Console.WriteLine("Target: {0}, Status: Bad route.", reply.Address.ToString());
                }
                else if (reply.Status == IPStatus.HardwareError)
                {
                    Console.WriteLine("Target: {0}, Status: Hardware error.", reply.Address.ToString());
                }
                else if (reply.Status == IPStatus.IcmpError)
                {
                    Console.WriteLine("Target: {0}, Status: ICMP error.", reply.Address.ToString());
                }
                else if (reply.Status == IPStatus.TtlExpired)
                {
                    Console.WriteLine("Target: {0}, Status: TTL expired.", reply.Address.ToString());
                }
                else if (reply.Status == IPStatus.NoResources)
                {
                    Console.WriteLine("Target: {0}, Status: No resources.", reply.Address.ToString());
                }
                else
                {
                    Console.WriteLine("Target: {0}, Status: Unknown Error - {1}.", reply.Address.ToString(), reply.Status.ToString());
                }
            }

            reply = null;
            pingSender = null;
        }
    }
}
