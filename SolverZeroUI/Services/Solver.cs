﻿using System.Net.Http.Headers;
using System.Text.Json;

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
            var content = new StringContent(json, MediaTypeHeaderValue.Parse("application/json"));

			HttpRequestMessage message = new(HttpMethod.Get, "http://localhost:8081/sudoku")
                { Content = content };

            HttpResponseMessage response = await _httpClient.SendAsync(message);

            return ParseJsonifiedSudokus(await response.Content.ReadAsStringAsync())!;
		}

        private List<int[,]>? ParseJsonifiedSudokus(string json)
        {
            List<int[][]>? jagged = JsonSerializer.Deserialize<List<int[][]>>(json);

            if (jagged == null)
                return null;
            else
                return jagged!.Select(a => MapJaggedTo2D(a)).ToList();
        }

        private T[,] MapJaggedTo2D<T>(T[][] array)
        {
            int countRows = array.Length;
            int countCols = array.Select(r => r.Length).Max();
            T[,] returnArr = new T[countRows, countCols];

            for (int row = 0; row < countRows; row++)
            {
                int rowLength = array[row].Length;

                for (int col = 0; col < countCols; col++)
                {
                    if (col < rowLength)
                        returnArr[row, col] = array[row][col];
                }
            }

            return returnArr;
        }
    }
}
