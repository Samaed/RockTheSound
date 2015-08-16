using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RTServer
{
    class TempClient
    {
        public static bool connected = true;
        public static void Coucou()
        {
            TcpClient client = new TcpClient("127.0.0.1", 8210);
            Console.WriteLine("Client connect");
            try
            {
                Stream s = client.GetStream();

                StreamReader sr = new StreamReader(s);
                StreamWriter sw = new StreamWriter(s);
                sw.AutoFlush = true;
                Console.WriteLine("Client got message : " + sr.ReadLine());
                sw.WriteLine("john");
                string msg = sr.ReadLine();
                Console.WriteLine("Client got message : " + msg);

                while (!msg.Equals("stop"))
                {
                    msg = sr.ReadLine();
                    Console.WriteLine("Client got msg : " + msg);
                    sw.WriteLine("Hey, how are you?");

                }

            }
            finally
            {
                client.Close();
            }
        }

    }
}
