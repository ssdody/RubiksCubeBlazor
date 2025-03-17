using System.Net.Http.Json;

namespace BlazorApp1.Client.Services
{
    public class CubeService
    {
        private readonly HttpClient _client;

        public CubeService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Dictionary<string, string[]>> GetCubeStateAsync()
        {
            return await _client.GetFromJsonAsync<Dictionary<string, string[]>>("https://localhost:7187/api/RubiksCube/state");
        }

        public async Task RotateFaceAsync(string face, string direction)
        {
            await _client.PostAsync($"https://localhost:7187/api/rubikscube/rotate/{face}?direction={direction}", null);
        }
    }

}
