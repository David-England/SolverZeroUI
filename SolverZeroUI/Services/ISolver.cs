namespace SolverZeroUI.Services
{
    public interface ISolver
    {
        Task<List<int[,]>> Solve(int[,] input);
    }
}
