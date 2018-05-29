using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TryToMVP
{
    /// <summary>
    /// Класс данных человека в телефонной книге
    /// </summary>
    class ModelPerson
    {
        //Идентификатор элемента в базе данных
        public int Id { get; set; }

        //Имя
        public string Name { get; set; }

        //Номер телефона
        public string Number { get; set; }
    }
}
