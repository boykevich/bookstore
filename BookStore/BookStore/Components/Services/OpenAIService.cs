using OpenAI.Chat;
using System;

class Program
{
    static void Main()
    {
        string? apiKey = Environment.GetEnvironmentVariable("OpenAI:OpenAIKey");
        if (string.IsNullOrEmpty(apiKey))
        {
            Console.WriteLine("API key not found. Set the 'OpenAI:OpenAIKey' environment variable.");
            return;
        }

        ChatClient client = new(model: "gpt-4o", apiKey: apiKey);

        ChatCompletion completion = client.CompleteChat("Say 'this is a test.'");

        Console.WriteLine($"[ASSISTANT]: {completion.Content[0].Text}");
    }
}
