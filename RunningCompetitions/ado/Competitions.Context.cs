﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RunningCompetitions.ado
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CompetitionEntities : DbContext
    {
        public CompetitionEntities()
            : base("name=CompetitionEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Command> Command { get; set; }
        public virtual DbSet<Competition> Competition { get; set; }
        public virtual DbSet<Result_competition> Result_competition { get; set; }
        public virtual DbSet<Sponsor> Sponsor { get; set; }
        public virtual DbSet<Sponsor_command> Sponsor_command { get; set; }
        public virtual DbSet<Sportsman> Sportsman { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Title> Title { get; set; }
        public virtual DbSet<Type_running> Type_running { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<Venue> Venue { get; set; }
    }
}
