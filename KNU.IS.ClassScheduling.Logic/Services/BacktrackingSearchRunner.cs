using KNU.IS.ClassScheduling.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.IS.ClassScheduling.Logic.Services
{
    public class BacktrackingSearchRunner<T> : IAlgorithmRunner
    {
        private readonly IBacktrackingAlgorithm<T> backtrackingAlgorithm;
        private readonly IAlgorithmOutputManager<T> outputManager;

        public BacktrackingSearchRunner(
            IBacktrackingAlgorithm<T> backtrackingAlgorithm, IAlgorithmOutputManager<T> outputManager)
        {
            this.backtrackingAlgorithm = backtrackingAlgorithm;
            this.outputManager = outputManager;
        }

        public async Task RunAsync()
        {
            await backtrackingAlgorithm.GenerateBasicSolutionAsync();

            var items = new List<T>();
            if (!backtrackingAlgorithm.BacktrackingSearch(items))
            {
                Console.WriteLine("Розв\'язків немає");
            }

            Console.WriteLine(outputManager.GetOutput(items));
        }
    }
}
