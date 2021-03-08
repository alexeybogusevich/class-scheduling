using KNU.IS.ClassScheduling.Logic.Models.Genetic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.IS.ClassScheduling.Logic.Interfaces
{
    public interface IGeneticAlgorithm<T>
    {
        Task<Chromosome<T>> CreateChromosomeAsync();
        double CalculateFitness(IEnumerable<T> genes);
        Chromosome<T> ChooseParent(IOrderedEnumerable<Chromosome<T>> sortedPopulation);
        Chromosome<T> Crossover(Chromosome<T> parentA, Chromosome<T> parentB, double coefficient = 0.5);
    }
}
