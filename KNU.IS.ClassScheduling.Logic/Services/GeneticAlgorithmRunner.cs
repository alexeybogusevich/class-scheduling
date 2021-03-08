using KNU.IS.ClassScheduling.Logic.Configuration;
using KNU.IS.ClassScheduling.Logic.Interfaces;
using KNU.IS.ClassScheduling.Logic.Models.Genetic;
using KNU.IS.ClassScheduling.Logic.Models.Schedule;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.IS.ClassScheduling.Logic.Services
{
    public class GeneticAlgorithmRunner<T> : IAlgorithmRunner
    {
        private readonly Random random;

        private readonly IGeneticAlgorithm<T> geneticAlgorithm;
        private readonly GeneticOptions geneticOptions;

        private readonly IAlgorithmOutputManager<T> outputManager;

        public GeneticAlgorithmRunner(
            IGeneticAlgorithm<T> geneticAlgorithm, IOptions<GeneticOptions> geneticOptions,
            IAlgorithmOutputManager<T> outputManager)
        {
            this.random = new Random();
            this.geneticOptions = geneticOptions.Value;
            this.geneticAlgorithm = geneticAlgorithm;
            this.outputManager = outputManager;
        }

        public async Task RunAsync()
        {
            var population = new List<Chromosome<T>>();

            foreach (var _ in Enumerable.Range(0, geneticOptions.PopulationSize))
            {
                var chromosome = await geneticAlgorithm.CreateChromosomeAsync();
                population.Add(chromosome);
            }

            var sortedPopulation = population.OrderByDescending(c => c.Fitness);
            var generations = 1;

            while (sortedPopulation.First().Fitness < geneticOptions.SatisfactoryFitnessValue)
            {
                var elitesToTake = (int)Math.Floor(
                    geneticOptions.PopulationSize * (geneticOptions.ElitismPercentage / 100));
                var newPopulation = sortedPopulation.Take(elitesToTake).ToList();

                ApplyCrossover(sortedPopulation, newPopulation);
                await ApplyMutationAsync(newPopulation);

                sortedPopulation = newPopulation.OrderByDescending(c => c.Fitness);
                generations += 1;
            }

            var bestChromosome = sortedPopulation.First();

            Console.WriteLine($"Generations passed: {generations}");
            Console.WriteLine(outputManager.GetOutput(bestChromosome.Genes));
        }

        private void ApplyCrossover(
            IOrderedEnumerable<Chromosome<T>> sortedPopulation, 
            List<Chromosome<T>> newPopulation)
        {
            while (newPopulation.Count() != geneticOptions.PopulationSize)
            {
                var parentA = geneticAlgorithm.ChooseParent(sortedPopulation);
                var parentB = geneticAlgorithm.ChooseParent(sortedPopulation);

                if (random.NextDouble() < geneticOptions.CrossoverProbability)
                {
                    newPopulation.Add(geneticAlgorithm.Crossover(parentA, parentB));
                }
            }
        }

        private async Task ApplyMutationAsync(List<Chromosome<T>> newPopulation)
        {
            foreach (var i in Enumerable.Range(0, newPopulation.Count()))
            {
                var mutationCandidate = newPopulation.ElementAt(i);

                if (random.NextDouble() < geneticOptions.MutationProbability)
                {
                    var randomChromosome = await geneticAlgorithm.CreateChromosomeAsync();
                    var mutant = geneticAlgorithm.Crossover(
                        mutationCandidate, randomChromosome, geneticOptions.MutationCoefficient);

                    newPopulation.RemoveAt(i);
                    newPopulation.Add(mutant);
                }
            }
        }
    }
}
