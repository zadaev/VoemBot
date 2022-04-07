using Telegram.Bot.Types;
using Telegram.Bot.Extensions.Polling;

namespace Telegram.Bot.VoiceMemBot
{
    public static class Program
    {

        private static TelegramBotClient? Bot;

        public static async Task Main()
        {

            Bot = new TelegramBotClient(Configuration.BotToken);

            User me = await Bot.GetMeAsync();
            using var cts = new CancellationTokenSource();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            ReceiverOptions receiverOptions = new() { AllowedUpdates = { } };
            Bot.StartReceiving(Handlers.HandleUpdateAsync,
                               Handlers.HandleErrorAsync,
                               receiverOptions,
                               cts.Token);

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            // Send cancellation request to stop bot
            cts.Cancel();

        }
    }
}