using System.Text.Json;
using System.Text;

namespace LLMFramework
{
    public static class ApiHelper
    {
        private static readonly HttpClient client = new();

        public static async Task<string> GetResponseFromApi(string currentRole, List<Dictionary<string, object>> previousMessages, double temperatureRandomness)
        {
            var url = "http://localhost:8080/v1/chat/completions";
            previousMessages ??= [];
            
            previousMessages.Add(new() { { "role", "system" }, { "content", "Answer as " + currentRole } });
            var payload = new
            {
                model = "hermes-2-theta-llama-3-8b",
                messages = previousMessages,
                temperature = temperatureRandomness
            };
            var jsonPayload = JsonSerializer.Serialize(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage? response;
            try
            {
                response = await client.PostAsync(url, content);
            }
            catch
            {
                throw new Exception("The API couldn't be reached.");
            }
            var responseString = await response.Content.ReadAsStringAsync();
            var responseJson = JsonDocument.Parse(responseString);

            var choices = responseJson.RootElement.GetProperty("choices");


            string? botMessage = null;

            if (choices.GetArrayLength() > 0)
            {
                botMessage = choices[0].GetProperty("message").GetProperty("content").GetString();
            }
            botMessage ??= "Couldn't Generate.";

            return botMessage;
        }

    }
}
