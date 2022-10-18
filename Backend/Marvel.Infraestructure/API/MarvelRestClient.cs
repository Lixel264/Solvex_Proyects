using Marvel.Domain.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Marvel.Infraestructure.API
{
    public class MarvelRestClient<T> : IMarvelRestClient<T>
    {

        private static readonly string BASE_URL = "https://gateway.marvel.com:443/v1/public/";
        private string _apiKey;
        private string _hash;
        private string _searchTerm;
        private MarvelSearch _searchResponse;
        private readonly HttpClient _httpClient;


        public MarvelRestClient(HttpClient httpClient, string apiKey, string hash)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri(BASE_URL);

            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
            _hash = hash;
            _apiKey= apiKey;


        }

        public async Task<dynamic> GetAllAsync(string requestedUri)
        {
            var url = $"?nameStartsWith=Deadpool&apikey={_apiKey}";

            _searchResponse = await _httpClient.GetFromJsonAsync<dynamic>(url, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return _searchResponse;
        }


        public async Task GetAsync(string requestedUri)
        {
            var url = $"?nameStartsWith={_searchTerm}&apikey={_apiKey}";

            _searchResponse = await _httpClient.GetFromJsonAsync<MarvelSearch>(url, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

    }
}
