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

    public static async Task<T> PostAsync<T>(string baseUrl, string url, object body = null) where T : class, new()
    {
        var client = new RestClient(baseUrl);
        var request = new RestRequest(url);
        request.Method = Method.Post;
        request.RequestFormat = DataFormat.Json;
        if (body != null)
            request.AddJsonBody(body, "application/json");
        var queryResult = await client.ExecuteAsync(request);
        if (!queryResult.IsSuccessful) { return new T(); }

        var result = JsonConvert.DeserializeObject<T> (queryResult.Content);

        if(result == null)
            { return new T(); }
        return result;
    }

}
