
using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace PrayerTime

{
    public static class Message
    {

        public static TelegramBotClient client;
        public static void Messages()
        {
            client = new TelegramBotClient(Constants.token);
            client.StartReceiving();
            client.OnMessage += messageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }

        private static async void messageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                // Console.WriteLine($"{msg.Text}");
                if (msg.Text == "/start")
                {
                    await client.SendTextMessageAsync
                   (msg.Chat.Id, "Namoz Vaxtlarini blshni xoxlasangiz Lokatsia jonating");

                    await client.SendTextMessageAsync(
                        chatId: msg.Chat.Id,
                        parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                        replyMarkup: new ReplyKeyboardMarkup()
                        {
                            OneTimeKeyboard = true,
                            Keyboard = new List<List<KeyboardButton>>()
                            {
                               new List<KeyboardButton>()
                               {
                                   new KeyboardButton("1-1")
                                   {
                                       Text = "Send location",
                                       RequestLocation = true,
                                   },
                                   new KeyboardButton()
                                   {
                                       Text = "Cancel"
                                   }

                               }
                            }
                        },
                        text: "Share your location?");

                }
                // await client.SendTextMessageAsync
                //       (msg.Chat.Id, "Qaysi Kunning taqvimi kerak", replyMarkup: GetButtons());
            }
        }

        // private static IReplyMarkup GetButtons()
        // {
        //     return new ReplyKeyboardMarkup
        //     {
        //         Keyboard = new List<List<KeyboardButton>>
        //        {
        //            new List<KeyboardButton>{new KeyboardButton { Text = "Tashkent"}}
        //        }
        //     };
        // }
    }
}