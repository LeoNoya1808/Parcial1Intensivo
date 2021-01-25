namespace PryUserNoyaL.Models
{
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<PryUserNoyaL.Models.Root> Roots { get; set; }

        public System.Data.Entity.DbSet<PryUserNoyaL.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<PryUserNoyaL.Models.Adress> Adresses { get; set; }

        public System.Data.Entity.DbSet<PryUserNoyaL.Models.Geo> Geos { get; set; }
    }
}