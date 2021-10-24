using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Cafetera_Bot_Telegram
{
    class Program
    {
        static ITelegramBotClient _botClient;
        static void Main(string[] args)
        {
            _botClient = new TelegramBotClient("2087189707:AAGOs-eI1irJN0b-HVu4xBeUrHM1D0142I4");

            var bot = _botClient.GetMeAsync().Result;

            Console.WriteLine($"La cafetera con id: {bot.Id} y mi nombre es: {bot.FirstName}");

            _botClient.OnMessage += _botClient_OnMessage;
            _botClient.StartReceiving();

            Console.WriteLine("Porfavor pulse cualquier tecla para salir.");
            Console.ReadKey();

            _botClient.StopReceiving();
        }

        private async static void _botClient_OnMessage(object sender, MessageEventArgs e)
        {
            string cafetera = "ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg";
            if(e.Message.Text.Length >= 10 )
            {
                Console.WriteLine("Mensaje recibido con mas de 10 caracteres");

                await _botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat.Id,
                    text: cafetera
                    );
            }
            if (e.Message.Text.Length > 20 || e.Message.Text.Contains("diversion"))
            {
                Console.WriteLine("Mensaje recibido con mas de 20 caracteres o que contiene diversion");

                await _botClient.SendAudioAsync(
                    chatId: e.Message.Chat.Id,
                    audio: "https://github.com/TelegramBots/book/raw/master/src/docs/audio-guitar.mp3"
                    ); ;
            }
        }
    }
}
