using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;

class RawPingWithTTL
{
    static void Main(string[] args)
    {
        // 引数チェック
        if (args.Length != 1)
        {
            Console.WriteLine("Usage    : RawPingWithTTL <IP address or hostname>");
            Console.WriteLine("Important: You must run this program with administrator privileges (e.g., 'Run as Administrator') for proper functionality.");
            return;
        }

        string host = args[0];
        IPAddress ip;
        try
        {
            // ホスト名またはIPアドレスの解決
            ip = Dns.GetHostEntry(host).AddressList[0];
        }
        catch
        {
            Console.WriteLine("Unable to resolve host.");
            return;
        }

        // Rawソケットの作成（ICMPプロトコル）
        using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Icmp))
        {
            socket.ReceiveTimeout = 3000;

            byte[] icmpPacket = CreateIcmpPacket();
            EndPoint remoteEP = new IPEndPoint(ip, 0);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            socket.SendTo(icmpPacket, remoteEP);

            byte[] buffer = new byte[1024];
            try
            {
                socket.ReceiveFrom(buffer, ref remoteEP);
                sw.Stop();

                //byte ttl = buffer[8]; // IPヘッダーのTTLフィールド（9バイト目）
                //Console.WriteLine($"Reply from {ip}: time={sw.ElapsedMilliseconds}ms TTL={ttl}");

                //詳細を出力
                PrintIpHeader(buffer, sw.ElapsedMilliseconds);
            }
            catch (SocketException)
            {
                Console.WriteLine($"Request timed out.");
            }
        }
    }

    // ICMP Echo Request パケット生成
    static byte[] CreateIcmpPacket()
    {
        byte[] data = Encoding.ASCII.GetBytes("PingWithTTL");
        int size = 8 + data.Length;
        byte[] packet = new byte[size];

        packet[0] = 8;  // Type: Echo Request
        packet[1] = 0;  // Code
        packet[2] = 0;  // チェックサム（仮）
        packet[3] = 0;
        packet[4] = 0;  // ID
        packet[5] = 1;
        packet[6] = 0;  // シーケンス番号
        packet[7] = 1;

        Array.Copy(data, 0, packet, 8, data.Length);

        ushort checksum = CalculateChecksum(packet);
        packet[2] = (byte)(checksum >> 8);
        packet[3] = (byte)(checksum & 0xFF);

        return packet;
    }

    // ICMPチェックサム計算
    static ushort CalculateChecksum(byte[] buffer)
    {
        int sum = 0;
        for (int i = 0; i < buffer.Length; i += 2)
        {
            ushort word = (i + 1 < buffer.Length)
                ? (ushort)((buffer[i] << 8) | buffer[i + 1])
                : (ushort)(buffer[i] << 8);
            sum += word;
        }

        while ((sum >> 16) != 0)
            sum = (sum & 0xFFFF) + (sum >> 16);

        return (ushort)~sum;
    }

    // IPヘッダの詳細表示
    static void PrintIpHeader(byte[] buffer, long responseTime)
    {
        int version = buffer[0] >> 4; // バージョン / byte 0 / IPv4なら 4(上位4ビット)
        int headerLength = (buffer[0] & 0x0F) * 4; // ヘッダー長 / byte 0 / 通常は 20バイト(下位4ビット)
        int serviceType = buffer[1]; // サービスタイプ / byte 1 / 通信優先度の指標(通常 0)
        int totalLength = (buffer[2] << 8) + buffer[3]; // 全体の長さ / bytes 2–3 / IPヘッダ + データ部のサイズ
        int identification = (buffer[4] << 8) + buffer[5]; // 識別子 / bytes 4–5 / パケットのID
        int flagsAndOffset = (buffer[6] << 8) + buffer[7]; // フラグ／オフセット / bytes 6–7 / フラグとフラグオフセット
        int ttl = buffer[8]; // TTL / byte 8 / 到達可能なルータ数
        int protocol = buffer[9]; // プロトコル / byte 9 / 1=ICMP, 6=TCP, 17=UDPなど
        int checksum = (buffer[10] << 8) + buffer[11]; // チェックサム / bytes 10–11 / ヘッダー検証用
        string sourceIP = $"{buffer[12]}.{buffer[13]}.{buffer[14]}.{buffer[15]}"; // 送信元IPアドレス / bytes 12–15 / 通常、相手先のIP
        string destinationIP = $"{buffer[16]}.{buffer[17]}.{buffer[18]}.{buffer[19]}"; // 宛先IPアドレス / bytes 16–19 / 自身のIP(ただしここでは無視)

        //Console.WriteLine("--- IP Header Info ---");
        Console.WriteLine($"Reply Host      : {sourceIP}"); // 送信元IPアドレス / Source IP
        Console.WriteLine($"Response time   : {responseTime} ms"); // 送信元IPアドレス / Source IP
        Console.WriteLine($"Time to Live    : {ttl}"); // TTL / Time to Live
        //Console.WriteLine("---------------------------------"); // セパレーター
        Console.WriteLine($"Local Host      : {destinationIP}"); // 宛先IPアドレス / Destination IP
        Console.WriteLine($"Service Type    : {serviceType}"); // サービスタイプ / Service Type
        // プロトコル / Protocol
        Console.Write($"Protocol        : {protocol} - ");
        if (protocol == 1)
        {
            Console.WriteLine($"ICMP");
        }
        else if (protocol == 6)
        {
            Console.WriteLine($"TCP");
        }
        else if(protocol == 17)
        {
            Console.WriteLine($"UDP");
        }
        else
        {
            Console.WriteLine($"Other Protocol");
        }
        Console.WriteLine($"Version         : {version}"); // バージョン / Version
        Console.WriteLine($"Header Length   : {headerLength} bytes"); // ヘッダー長 / Header Length
        Console.WriteLine($"Header Checksum : 0x{checksum:X}"); // チェックサム / Header Checksum
        Console.WriteLine($"Identification  : {identification}"); // 識別子 / Identification
        Console.WriteLine($"Flags/Fragment  : 0x{flagsAndOffset:X}"); // フラグメント / Fragment
        Console.WriteLine($"Total Length    : {totalLength}"); // 全体の長さ / Total Length
        Console.WriteLine($""); //空行
    }

}


/* 以下、管理者権限不要版 */
/*
using System;
using System.Net.NetworkInformation;

class SimplePing
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("使い方: SimplePing <IPまたはホスト名>");
            return;
        }

        string host = args[0];
        Ping ping = new Ping();

        try
        {
            PingReply reply = ping.Send(host, 3000);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine($"Reply from {reply.Address}: time={reply.RoundtripTime}ms TTL={reply.Options.Ttl}");
            }
            else
            {
                Console.WriteLine($"Ping failed: {reply.Status}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"エラー: {ex.Message}");
        }
    }
}
*/