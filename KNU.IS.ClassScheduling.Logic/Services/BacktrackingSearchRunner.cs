using KNU.IS.ClassScheduling.Logic.Interfaces;
using KNU.IS.ClassScheduling.Logic.Models.Schedule;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.IS.ClassScheduling.Logic.Services
{
    public class BacktrackingSearchRunner : IAlgorithmRunner
    {
        private readonly List<ScheduledClass> scheduledClasses;

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
