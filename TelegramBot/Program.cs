using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot
{
    class Program
    {
        private static TelegramBotClient _botclient;
        static async Task Main(string[] args)
        {
           _botclient = new TelegramBotClient("934551867:AAEfUP9ElaqhtT7uEFufpDZVtGN91RM66n0");

            //var me = await client.GetMeAsync();

            _botclient.OnMessage += Client_OnMessage;

            _botclient.StartReceiving();

            //Console.WriteLine($"Username - { me.FirstName}, id - { me.Id} ");
            Thread.Sleep(int.MaxValue);

        }

        private static async void Client_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var chars = e.Message.Text.ToArray();
            byte[] array = new byte[e.Message.Text.ToArray().Length];
            for (int i = 0; i< chars.Length; i++)
            { 
                array[i] = Convert.ToByte(chars[i]); 
            }

           await _botclient.SendTextMessageAsync(e.Message.Chat.Id, "Your message" + Convert.ToBase64String(array));

        }
    }
}
