using System.Data.Entity;

namespace StaraPiasokownicaNetFramework.Models
{
    public class DbDataContext : DbContext
    {
       // public DbSet<DataFilesTB> DataFiles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<tblImages> Files { get; set; }
    }
}