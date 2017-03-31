using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Common;


namespace MvcRpg.DAL
{
    public class RpgContext : DbContext
    {

        public DbSet<Monster> Monsters { get; set; }
        
    }
}