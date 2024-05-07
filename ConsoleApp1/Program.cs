using System;
using System.Net.Http;

class Program
{
    static void Main()
    {
        string url = "https://aws.random.cat/meow";

        
        HttpClient client = new HttpClient();

        // Вызов синхронного метода getHttpResponse и ожидание завершения запроса
        string response = getHttpResponse(client, url);

        
        Console.WriteLine(response);
        Console.WriteLine(response);
        Console.WriteLine(response);

        Console.WriteLine("All requests completed.");
    }

    public static string getHttpResponse(HttpClient client, string url)
    {
        try
        {
            
            HttpResponseMessage response = client.GetAsync(url).Result;

            
            if (response.IsSuccessStatusCode)
            {
                
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
               
                return $"Failed to get response from {url}. Status code: {response.StatusCode}";
            }
        }
        catch (HttpRequestException ex)
        {
            
            return $"An error occurred while making a request to {url}: {ex.Message}";
        }
    }
}
