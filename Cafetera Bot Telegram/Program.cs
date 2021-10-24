using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace Cafetera_Bot_Telegram
{
    class Program
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("2087189707:AAGOs-eI1irJN0b-HVu4xBeUrHM1D0142I4");
        static void Main(string[] args)
        {
            var bot = Bot.GetMeAsync().Result;

            Console.WriteLine($"La cafetera con id: {bot.Id} y mi nombre es: {bot.FirstName}");

            Bot.OnMessage += _botClient_OnMessage;
            Bot.StartReceiving();

            Console.WriteLine("Porfavor pulse cualquier tecla para salir.");
            Console.ReadKey();

            Bot.StopReceiving();
        }

        private async static void _botClient_OnMessage(object sender, MessageEventArgs e)
        {
            string cafetera = "ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg";

            if (e.Message.Text.Contains("Marton Strongald"))
            {
                Console.WriteLine("Se ha llamado a Marton Strongald.");

                await Bot.SendTextMessageAsync(
                    chatId: e.Message.Chat.Id,
                    text: "No tienes poder suficiente para mencionar a MARTON STRONGALD"
                    );
            }

            if (e.Message.Text.Contains("Matsumoto"))
            {
                Console.WriteLine("Se ha llamado a Matsumoto.");

                await Bot.SendStickerAsync(
                    chatId: e.Message.Chat.Id,
                    sticker: "https://nordot-res.cloudinary.com/c_limit,w_800,f_auto,q_auto:eco/ch/images/703502092748588129/origin_1.jpg"
                    );
            }

            if (e.Message.Text.Length >= 10 && e.Message.Text.Length < 20)
            {
                Console.WriteLine("Mensaje recibido con mas de 10 caracteres");

                await Bot.SendTextMessageAsync(
                    chatId: e.Message.Chat.Id,
                    text: cafetera
                    );
            }
            else if(e.Message.Text.Length > 20 || e.Message.Text.Contains("diversion"))
            {
                Console.WriteLine("Mensaje recibido con mas de 20 caracteres o que contiene diversion");

                Message message;
                using (var stream = System.IO.File.OpenRead(@"D:\Proyectos\.NET\Cafetera Bot Telegram\Cafetera Bot Telegram\Media\coffiemachine.mp3"))
                {
                    message = await Bot.SendVoiceAsync(
                      chatId: e.Message.Chat.Id,
                      voice: stream,
                      duration: 10
                    );
                }
            }
        }
    }
}
