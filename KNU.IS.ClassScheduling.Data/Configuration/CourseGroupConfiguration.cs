using KNU.IS.ClassScheduling.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KNU.IS.ClassScheduling.Data.Configuration
{
    class CourseGroupConfiguration : IEntityTypeConfiguration<CourseGroup>
    {
        public void Configure(EntityTypeBuilder<CourseGroup> builder)
        {
            builder.HasKey(cg => new { cg.CourceId, cg.GroupId });

            builder.HasOne(cg => cg.Course)
                .WithMany(c => c.CourseGroups)
                .HasForeignKey(cg => cg.CourceId);

            builder.HasOne(cg => cg.Group)
                .WithMany(g => g.CourceGroups)
                .HasForeignKey(cg => cg.GroupId);

            builder.HasData(
                new CourseGroup() { CourceId = 1, GroupId = 1 },
                new CourseGroup() { CourceId = 1, GroupId = 2 },
                new CourseGroup() { CourceId = 1, GroupId = 3 },

                new CourseGroup() { CourceId = 2, GroupId = 1 },
                new CourseGroup() { CourceId = 2, GroupId = 2 },
                new CourseGroup() { CourceId = 2, GroupId = 3 },

                new CourseGroup() { CourceId = 3, GroupId = 1 },
                new CourseGroup() { CourceId = 3, GroupId = 2 },
                new CourseGroup() { CourceId = 3, GroupId = 3 },

                new CourseGroup() { CourceId = 4, GroupId = 4 },
                new CourseGroup() { CourceId = 4, GroupId = 5 },
                new CourseGroup() { CourceId = 4, GroupId = 6 },

                new CourseGroup() { CourceId = 5, GroupId = 1 },
                new CourseGroup() { CourceId = 5, GroupId = 2 },
                new CourseGroup() { CourceId = 5, GroupId = 3 },
                new CourseGroup() { CourceId = 5, GroupId = 4 },

                new CourseGroup() { CourceId = 6, GroupId = 4 },
                new CourseGroup() { CourceId = 6, GroupId = 5 },
                new CourseGroup() { CourceId = 6, GroupId = 6 },

                new CourseGroup() { CourceId = 7, GroupId = 4 },
                new CourseGroup() { CourceId = 7, GroupId = 5 },
                new CourseGroup() { CourceId = 7, GroupId = 6 },
                new CourseGroup() { CourceId = 7, GroupId = 7 },
                new CourseGroup() { CourceId = 7, GroupId = 8 },
                new CourseGroup() { CourceId = 7, GroupId = 9 },

                new CourseGroup() { CourceId = 8, GroupId = 7 },
                new CourseGroup() { CourceId = 8, GroupId = 8 },
                new CourseGroup() { CourceId = 8, GroupId = 9 },

                new CourseGroup() { CourceId = 9, GroupId = 10 },
                new CourseGroup() { CourceId = 9, GroupId = 11 },
                new CourseGroup() { CourceId = 10, GroupId = 10 },
                new CourseGroup() { CourceId = 10, GroupId = 11 }
            );
        }
    }
}
