using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Threading;
using Discord.Webhook;
namespace UsrOnline
{
    internal class Program
    {
        static void Main()
        {
            Console.Clear();
            string cd = Environment.CurrentDirectory + @"\";
            Console.WriteLine("Loading Config.....");
            string[] Config = File.ReadAllLines(cd + @"main.config");
            Console.WriteLine("Config Loaded!");
            Console.WriteLine("Creating WebClient");
            WebClient wc = new WebClient();
            Console.WriteLine("WebClient Created!");
            Console.WriteLine("Starting Process...");
            while (true)
            {
               string data = wc.DownloadString(Config[0]);
                if(data.Contains(Config[1]))
                {
                    Webhook.SendMessage(Config[2],Config[3].Replace("{data}", data), "https://cdn-icons-png.flaticon.com/512/1827/1827301.png",Config[4]);
                }


                Thread.Sleep(int.Parse(Config[5]) * 60000);
            }
        }
    }
}
