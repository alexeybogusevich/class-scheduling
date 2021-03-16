using KNU.IS.ClassScheduling.Data.Context;
using KNU.IS.ClassScheduling.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.IS.ClassScheduling.Logic.Services.DomainProvider
{
    public class ForwardCheckingDomainProvider : BaseDomainProvider
    {
        public ForwardCheckingDomainProvider(ApplicationContext context) : base(context) { }

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();
            instructors = await context.Instructors.Include(i => i.CourseInstructors).ToListAsync();
        }

        public override IEnumerable<Instructor> GetInstructors(TimePeriod timePeriod, Course course)
        {
            return base.GetInstructors(timePeriod, course)
                .Where(instructor => instructor.CourseInstructors.Any(ci => ci.CourceId == course.Id));
        }
    }
}
