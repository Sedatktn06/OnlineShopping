using Newtonsoft.Json;
using RestSharp;

namespace OnlineShopping.Core.Helpers;

public class RequestHelper
{
    public static async Task<T> GetAsync<T>(string baseUrl, string url) where T : class, new()
    {
        var client = new RestClient(baseUrl);
        var request = new RestRequest(url);
        request.Method = Method.Get;
        var queryResult = await client.ExecuteAsync(request);

        if (!queryResult.IsSuccessful)
        {
            return new T();
        }

        var response = JsonConvert.DeserializeObject<T>(queryResult.Content);

        if (response == null)
        {
            return new T();
        }

        return response;
    }

    public static async Task<T> PostAsync<T>(string baseUrl, string url, object body = null)
    {
        var client = new RestClient(baseUrl);
        var request = new RestRequest(url);
        request.Method = Method.Post;
        request.RequestFormat = DataFormat.Json;
        if (body != null)
            request.AddJsonBody(body, "application/json");
        var queryResult = await client.ExecuteAsync(request);

        var result = JsonConvert.DeserializeObject<T>(queryResult.Content);

        return result;
    }

    public static async Task<T> DeleteAsync<T>(string baseUrl, string url)
    {
        var client = new RestClient(baseUrl);
        var request = new RestRequest(url);
        request.Method = Method.Delete;
        request.RequestFormat = DataFormat.Json;
       
        var queryResult = await client.ExecuteAsync(request);

        var result = JsonConvert.DeserializeObject<T>(queryResult.Content);

        return result;
    }

}
