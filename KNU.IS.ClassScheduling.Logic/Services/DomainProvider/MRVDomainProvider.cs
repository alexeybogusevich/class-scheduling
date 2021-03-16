using KNU.IS.ClassScheduling.Data.Context;
using KNU.IS.ClassScheduling.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace KNU.IS.ClassScheduling.Logic.Services.DomainProvider
{
    public class MRVDomainProvider : BaseDomainProvider
    {
        public MRVDomainProvider(ApplicationContext context) : base(context) { }

        public override IEnumerable<Course> GetCourses()
        {
            return base.GetCourses().Select(cource => new
            {
                Course = cource,
                DomainSize = courseHours[cource.Id].Sum(ch => cource.Hours - ch.Value)
            })
            .ToList()
            .OrderBy(s => s.DomainSize)
            .Select(val => val.Course);
        }
    }
}
