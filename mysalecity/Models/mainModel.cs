using MYSALE.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MYSALE.Models
{
    public class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string TelNumber { get; set; }
        public string Email { get; set; }
        public DateTime Datebirth { get; set; }

    }
    public class Bonusprogram
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
    public class City
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
    public class Company
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Service { get; set; }
        public int City { get; set; }
        public int BonusProgram { get; set; }
        public int HeaderCompany { get; set; }
        public string TelNumber { get; set; }
        public string Adress { get; set; }
        public bool Active { get; set; }
        public string SiteLink { get; set; }
        public int BonusPercent { get; set; }
          
    }
    public class Task
    {
        public int? id { get; set; }
        [DisplayName("Категория") ]
        public int Company { get; set; }
        [DisplayName("Название")]
        public string Title { get; set; }
        [DisplayName("Сообщение")]
        public string Text { get; set; }
        [DisplayName("Начало акции")]
        public DateTime? Start { get; set; }
        [DisplayName("Окончание акции")]
        public DateTime? Finish { get; set; }
    }
    public class Userlogindata
    {
        public int id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
    
    public class Rubric
    {
        public int id { get; set; }
        public string rubric_name { get; set; }
    }
  
    public class mscContext : DbContext
    {
        public mscContext() : base("connection"){ }

        public DbSet<User> Users { get; set; }
        public DbSet<Bonusprogram> Bonusprogram {get; set;}
        public DbSet<City> Cities {get; set;}
        public DbSet<Company> Companies {get; set;}
        public DbSet<Task> Tasks {get; set;}
        public DbSet<Userlogindata> Userlogindatas {get; set;}
        public DbSet<Rubric> Rubrics { get; set; }
    }
}