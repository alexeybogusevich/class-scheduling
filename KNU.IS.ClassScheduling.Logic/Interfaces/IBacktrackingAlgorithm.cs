using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.IS.ClassScheduling.Logic.Interfaces
{
    public interface IBacktrackingAlgorithm<T>
    {
        bool BacktrackingSearch(List<T> items, int depth = 1);
        Task GenerateBasicSolutionAsync();
    }
}
