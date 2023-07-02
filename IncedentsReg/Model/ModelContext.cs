using IncedentsReg.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Kurs.Model
{
    public class ModelContext : DbContext
    {
        public DbSet<IncidentDecisions> incidentdecisions { get; set; } = null;
        public DbSet<IncidentReports> incidentreports { get; set; } = null;
        public DbSet<User> User { get; set; } = null;
        public DbSet<PersonIncidentRelations> personincidentrelations { get; set; } = null;
        public DbSet<Persons> persons { get; set; } = null;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=incedents.db");
        }
    }
}



