using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovateQ.Assignment.Infrastructure.Data.EntityFramework
{
    public class DbContextFactory : DesignTimeDbContextFactoryBase<InnovateqContext>
    {
        protected override InnovateqContext CreateNewInstance(DbContextOptions<InnovateqContext> options)
        {
            return new InnovateqContext(options);
        }
    }
}
