using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


namespace FlipaCoinBot
{
    class Program
    {
        private static string Token { get; set; } = "5121481602:AAEkhOFk-EQuSXNDZHUuPFAYx3d4jdSVHdY";
        private static TelegramBotClient client;

        static void Main(string[] args)
        {
            client = new TelegramBotClient(Token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine($"Got message: {msg.Text}");

                switch (msg.Text)
                {
                    case "Flip a Coin":
                        Random rnd = new Random();
                        int r = rnd.Next(0, 200);

                        if (r < 100)
                        {
                            var stic = await client.SendStickerAsync(
                            chatId: msg.Chat.Id,
                            sticker: "https://github.com/TelegramBots/book/raw/master/src/docs/sticker-fred.webp",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButtons());
                        }

                        else
                        {
                            var stic = await client.SendStickerAsync(
                            chatId: msg.Chat.Id,
                            sticker: "https://github.com/TelegramBots/book/raw/master/src/docs/sticker-fred.webp",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButtons());

                        }

                        break;

                    default:
                        await client.SendTextMessageAsync(msg.Chat.Id, "wanna flip a coin?", replyMarkup: GetButtons());
                        break;


                }
            }
        }

        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{new KeyboardButton { Text = "Flip a Coin"} }
                }
            };
        }
    }
}
