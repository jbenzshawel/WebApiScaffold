using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebApiScaffold.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
    }
}