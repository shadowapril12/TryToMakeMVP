using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TryToMVP
{
    /// <summary>
    /// Класс подключения к базе данных
    /// </summary>
    class PersonContext : DbContext
    {
        public PersonContext() : base("DefaultConnection")
        {

        }

        //Сущность в базе данных
        public DbSet<ModelPerson> Persons { get; set; }
    }
}
