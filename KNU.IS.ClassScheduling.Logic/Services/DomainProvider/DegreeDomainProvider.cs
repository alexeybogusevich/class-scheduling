using KNU.IS.ClassScheduling.Data.Context;
using KNU.IS.ClassScheduling.Data.Models;
using System.Linq;

namespace KNU.IS.ClassScheduling.Logic.Services.DomainProvider
{
    public class DegreeDomainProvider : BaseDomainProvider
    {
        public DegreeDomainProvider(ApplicationContext context) : base(context) { }

        public override TimePeriod GetPeriod()
        {
            if (base.GetPeriod() == null)
            {
                return null;
            }

            var minTaken = timePeriodSelections.Values
                .Min(tps => tps.GetTotalTakenVariables());

            var timePeriod = timePeriods
                .FirstOrDefault(tp => timePeriodSelections[tp.Id].GetTotalTakenVariables() == minTaken);

            if (timePeriod != null)
            {
                return timePeriod;
            }

            return base.GetPeriod();
        }
    }
}
