using System.Collections.Generic;

namespace KNU.IS.ClassScheduling.Logic.Interfaces
{
    public interface IAlgorithmOutputManager<T>
    {
        string GetOutput(IEnumerable<T> items);
    }
}
