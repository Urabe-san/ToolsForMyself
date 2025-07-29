using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

class SimpleNslookup
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

        string domain = args[0]; // ← 任意のホスト名を指定
        byte[] query = BuildQuery(domain);

        using (UdpClient client = new UdpClient())
        {
            // DNS サーバーの IP アドレス（Google Public DNS）
            IPEndPoint dnsServer = new IPEndPoint(IPAddress.Parse("8.8.8.8"), 53);
            //IPEndPoint dnsServer = new IPEndPoint(GetSystemDnsServer(), 53);

            Console.WriteLine("Sending DNS query...");
            client.Send(query, query.Length, dnsServer); // ★送信ステップ

            Console.WriteLine("Waiting for response...");
            byte[] response = client.Receive(ref dnsServer); // ★受信ステップ

            Console.WriteLine("Raw response bytes: " + BitConverter.ToString(response));

            // ★応答の簡易解析（例：IP取得のみ）
            ParseResponse(response);
        }
    }

    static byte[] BuildQuery(string domain)
    {
        Random rand = new Random();
        ushort transactionID = (ushort)rand.Next(ushort.MaxValue); // ★識別ID

        byte[] header = new byte[12];
        header[0] = (byte)(transactionID >> 8);
        header[1] = (byte)(transactionID & 0xFF);
        header[2] = 0x01; // 再帰的問い合わせ
        header[5] = 0x01; // 質問数 1

        var domainParts = domain.Split('.');
        var question = new List<byte>();
        foreach (var part in domainParts)
        {
            question.Add((byte)part.Length);
            question.AddRange(Encoding.ASCII.GetBytes(part));
        }
        question.Add(0x00);         // ドメインの終端
        question.Add(0x00); question.Add(0x01); // Type: A
        question.Add(0x00); question.Add(0x01); // Class: IN

        var packet = new List<byte>();
        packet.AddRange(header);
        packet.AddRange(question);
        return packet.ToArray();
    }

    //static void ParseResponse(byte[] response)
    //{
    //    // ★Answerセクションを探して簡易的にIPアドレス抽出
    //    int index = 12; // ヘッダー後の質問までスキップ
    //    while (response[index] != 0) index++; index += 5;

    //    // ★Answerセクション（ひとつだけ解析）
    //    index += 6; // Name(2) + Type(2) + Class(2)
    //    index += 4; // TTL
    //    ushort dataLen = (ushort)((response[index] << 8) | response[index + 1]);
    //    index += 2;

    //    if (dataLen == 4)
    //    {
    //        Console.WriteLine("Resolved IP Address: " +
    //            $"{response[index]}.{response[index + 1]}.{response[index + 2]}.{response[index + 3]}");
    //    }
    //    else
    //    {
    //        Console.WriteLine("Unexpected data length.");
    //    }
    //}

    //static void ParseResponse(byte[] response)
    //{
    //    int index = 12;
    //    while (response[index] != 0) index++; index += 5;

    //    index += 2 + 2; // Type(2) + Class(2)
    //    uint ttl = (uint)((response[index] << 24) |
    //                      (response[index + 1] << 16) |
    //                      (response[index + 2] << 8) |
    //                       response[index + 3]);
    //    index += 4;

    //    ushort dataLen = (ushort)((response[index] << 8) | response[index + 1]);
    //    index += 2;

    //    if (dataLen == 4)
    //    {
    //        string ip = $"{response[index]}.{response[index + 1]}.{response[index + 2]}.{response[index + 3]}";
    //        Console.WriteLine($"Resolved IP Address: {ip}");
    //        Console.WriteLine($"TTL: {ttl} 秒");
    //    }
    //    else
    //    {
    //        Console.WriteLine("Unexpected data length.");
    //    }
    //    Console.WriteLine("");
    //}
    static void ParseResponse(byte[] response)
    {
        int index = 12;

        // 質問セクションをスキップ
        while (response[index] != 0) index++; // QNAME の末尾（0x00）を探す
        index += 5; // 末尾(0) + QTYPE(2) + QCLASS(2)

        // Answer セクション（1つ目）解析
        // ★ 名前フィールド（圧縮ポインタ）なら 2 バイト
        index += 2;

        // タイプとクラス
        ushort type = (ushort)((response[index] << 8) | response[index + 1]);
        index += 2;
        index += 2; // クラス

        // TTL（4バイト）
        uint ttl = (uint)((response[index] << 24) |
                          (response[index + 1] << 16) |
                          (response[index + 2] << 8) |
                           response[index + 3]);
        index += 4;

        // データ長（2バイト）
        ushort dataLen = (ushort)((response[index] << 8) | response[index + 1]);
        index += 2;

        // IPアドレス（タイプがAかつ長さが4）
        if (type == 1 && dataLen == 4)
        {
            string ip = $"{response[index]}.{response[index + 1]}.{response[index + 2]}.{response[index + 3]}";
            Console.WriteLine($"Resolved IP Address: {ip}");
            Console.WriteLine($"TTL: {ttl} seconds");
        }
        else
        {
            Console.WriteLine($"Non-A record or unexpected data length. Type={type}, Length={dataLen}");
        }
        Console.WriteLine("");
    }

    static IPAddress GetSystemDnsServer()
    {
        foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
        {
            var ipProps = ni.GetIPProperties();
            foreach (var dns in ipProps.DnsAddresses)
            {
                if (dns.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine($"Using system DNS: {dns}");
                    return dns;
                }
            }
        }
        // デフォルトのDNS（例：Google Public DNS）へフォールバック
        return IPAddress.Parse("8.8.8.8");
    }


}
