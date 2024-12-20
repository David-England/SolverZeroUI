namespace SolverZeroUI.Services
{
    public class Solver : ISolver
    {
        public async Task<List<int[,]>> Solve(int[,] input)
        {
            // Ignore input for now.

            string json = File.ReadAllText("./Samples/basic.json");

            Console.WriteLine(json);

            return new List<int[,]> { new int[0,0] };
        }
    }
}
