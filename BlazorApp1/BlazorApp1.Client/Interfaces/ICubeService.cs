namespace BlazorApp1.Client.Interfaces
{
    public interface ICubeService
    {
        public Task<Dictionary<string, string[]>> GetCubeStateAsync();
        public Task RotateFaceAsync(string face, string direction);
    }
}
