namespace SolverZeroUI.Services
{
    public class Solver : ISolver
    {
        private HttpClient _httpClient;

        public Solver()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<int[,]>> Solve(int[,] input)
        {
            // Ignore input for now.

            string json = File.ReadAllText("./Samples/basic.json");

            HttpRequestMessage message = new(HttpMethod.Get, "http://localhost:8081/sudoku")
                { Content = new StringContent(json) };

            HttpResponseMessage response = await _httpClient.SendAsync(message);

            Console.WriteLine(await response.Content.ReadAsStringAsync());

            return new List<int[,]> { new int[0,0] };
        }
    }
}
