using System;
using System.Net.Http;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        string url = "https://catfact.ninja/fact";

        
        await MakeHttpRequest(url);
        await MakeHttpRequest(url);
        await MakeHttpRequest(url);

        Console.WriteLine("All requests completed.");
    }

    public static async Task MakeHttpRequest(string url)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                // Проверка успешности ответа
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Response from {url}: {responseBody}");
                }
                else
                {
                    Console.WriteLine($"Failed to get response from {url}. Status code: {response.StatusCode}");
                }
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"An error occurred while making a request to {url}: {ex.Message}");
        }                                                                                                                                                                                                                                       
    }
}
