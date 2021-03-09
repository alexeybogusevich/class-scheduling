using System;
using System.Collections.Generic;
using System.Text;

namespace KNU.IS.ClassScheduling.Logic.Interfaces
{
    public interface ICSPAlgorithm<T>
    {
        T GetVariable();
    }
}
