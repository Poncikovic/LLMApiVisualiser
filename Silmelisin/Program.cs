// See https://aka.ms/new-console-template for more information
using System.Text;

using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
/*
struct Message
{
    string role;
    string content;
    double temperature;

    public Message(string role, string content, double temperature)
    {
        this.role = role;
        this.content = content;
        this.temperature = temperature;
    }
}*/
namespace Silmelisin
{
    public struct ApiResponse(string response, List<Dictionary<string, string>> history)
    {
        public string response = response;
        public List<Dictionary<string, string>> history = history;
    }
    public class ApiHelper
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<ApiResponse> GetResponseFromApi(string message, List<Dictionary<string, string>> previousMessages)
        {
            var url = "http://localhost:8080/v1/chat/completions";
            previousMessages ??= new List<Dictionary<string, string>>();
            var allMessages = new List<Dictionary<string, string>>(previousMessages)
            {
                new Dictionary<string, string>
                {
                    { "role", "user" },
                    { "content", message}
                }
            };
            var payload = new
            {
                model = "hermes-2-theta-llama-3-8b",
                messages = allMessages/*new[]
            {
                new { role = "user", content = message, temperature = 0.1 }
            }*/
            };
            //payload.messages = Array.Copy payload.messages
            var jsonPayload = JsonSerializer.Serialize(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);
            var responseString = await response.Content.ReadAsStringAsync();
            var responseJson = JsonDocument.Parse(responseString);

            var choices = responseJson.RootElement.GetProperty("choices");


            string? botMessage = null;

            if (choices.GetArrayLength() > 0)
            {
                botMessage = choices[0].GetProperty("message").GetProperty("content").GetString();
            }
            botMessage ??= "Sorry I don't understand";

            previousMessages.Add(new Dictionary<string, string> { { "role", "assistant" }, { "content", botMessage } });

            return new ApiResponse(botMessage, previousMessages);
        }

    }

    /*
    class TestClass
    {
        static async Task Main(string[] args)
        {
            ApiHelper api = new ApiHelper();
            // Display the number of command line arguments.

            List<Dictionary<string, string>>? MessageHistory = new List<Dictionary<string, string>>();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Apply role to ai: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string? role = Console.ReadLine();
            if (role != null)
            {
                MessageHistory.Add(new Dictionary<string, string>
                {
                    { "role", "system" },
                    { "content", role }
                });
            }
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(">");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                string? text = Console.ReadLine();
                if (text == null) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("#:Please enter a valid input#"); continue; }
                var output = await (api.GetResponseFromApi(text, MessageHistory));
                output.history = MessageHistory;
                string outputText = output.response;
                //string output = await api.GetResponseFromApi(text);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nAI: ");
                Console.ForegroundColor= ConsoleColor.Gray;
                Console.WriteLine(outputText + "\n");

            }
        }
    }
    */
}