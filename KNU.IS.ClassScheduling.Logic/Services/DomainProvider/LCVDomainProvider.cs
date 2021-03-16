using KNU.IS.ClassScheduling.Data.Context;
using KNU.IS.ClassScheduling.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace KNU.IS.ClassScheduling.Logic.Services.DomainProvider
{
    public class LCVDomainProvider : BaseDomainProvider
    {
        public LCVDomainProvider(ApplicationContext context) : base(context) { }

        public override IEnumerable<Course> GetCourses()
        {
            return base.GetCourses().Select(c => new
            {
                Course = c,
                DomainSize = courseHours[c.Id].Sum(ch => c.Hours - ch.Value)
            })
            .ToList()
            .OrderByDescending(s => s.DomainSize)
            .Select(val => val.Course);
        }
    }
}
