using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PryUserMonasterioS.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<PryUserMonasterioS.Models.Address> Addresses { get; set; }

        public System.Data.Entity.DbSet<PryUserMonasterioS.Models.Geo> Geos { get; set; }

        public System.Data.Entity.DbSet<PryUserMonasterioS.Models.Roots> Roots { get; set; }

        public System.Data.Entity.DbSet<PryUserMonasterioS.Models.Company> Companies { get; set; }
    }
}