using KNU.IS.ClassScheduling.Logic.Interfaces;
using KNU.IS.ClassScheduling.Logic.Models.Genetic;
using KNU.IS.ClassScheduling.Logic.Models.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.IS.ClassScheduling.Logic.Services
{
    public class SchedulingGeneticAlgorithm : IGeneticAlgorithm<ScheduledClass>
    {
        private readonly Random random;
        private readonly IScheduleManager scheduleManager;

        public SchedulingGeneticAlgorithm(IScheduleManager scheduleManager)
        {
            this.random = new Random();
            this.scheduleManager = scheduleManager;
        }

        public async Task<Chromosome<ScheduledClass>> CreateChromosomeAsync()
        {
            var scheduledClasses = await scheduleManager.GenerateAsync();
            var fitness = CalculateFitness(scheduledClasses);
            return new Chromosome<ScheduledClass>(scheduledClasses, fitness);
        }

        public double CalculateFitness(IEnumerable<ScheduledClass> scheduledClasses)
        {
            var conflicts = scheduleManager.GountConflicts(scheduledClasses);
            return 1 / (double)(conflicts + 1);
        }

        // Roulette Wheel Fitness Proportionate Selection
        public Chromosome<ScheduledClass> ChooseParent(
            IOrderedEnumerable<Chromosome<ScheduledClass>> sortedPopulation)
        {
            var sumOfFitnesses = sortedPopulation.Sum(c => c.Fitness);
            var parentPoint = random.NextDouble() * sumOfFitnesses;

            double sum = 0;
            var iterator = sortedPopulation.GetEnumerator();

            while (iterator.MoveNext())
            {
                sum += iterator.Current.Fitness;
                if (sum > parentPoint)
                {
                    break;
                }
            }

            return iterator.Current;
        }

        public Chromosome<ScheduledClass> Crossover(
            Chromosome<ScheduledClass> parentA, Chromosome<ScheduledClass> parentB, double coefficient = 0.5)
        {
            var crossoverScheduledClasses = new List<ScheduledClass>();

            foreach (var i in Enumerable.Range(0, Math.Min(parentA.Genes.Count(), parentB.Genes.Count())))
            {
                if (random.NextDouble() < coefficient)
                {
                    crossoverScheduledClasses.Add(parentA.Genes.ElementAt(i));
                }
                else
                {
                    crossoverScheduledClasses.Add(parentB.Genes.ElementAt(i));
                }
            }

            return new Chromosome<ScheduledClass>(
                crossoverScheduledClasses, CalculateFitness(crossoverScheduledClasses));
        }
    }
}
