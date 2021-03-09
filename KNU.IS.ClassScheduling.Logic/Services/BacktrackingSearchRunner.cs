using KNU.IS.ClassScheduling.Data.Models;
using KNU.IS.ClassScheduling.Logic.Interfaces;
using KNU.IS.ClassScheduling.Logic.Models.Schedule;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.IS.ClassScheduling.Logic.Services
{
    public class BacktrackingSearchRunner : IAlgorithmRunner
    {
        public BacktrackingSearchRunner()
        {
            this.scheduledClasses = new List<ScheduledClass>();
        }

        public Task RunAsync()
        {
            

            throw new NotImplementedException();
        }
    }
}
