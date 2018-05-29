using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryToMVP
{
    /// <summary>
    /// Интерфейс представителя
    /// </summary>
    interface IPresenter
    {
        //Метод добавления элемента в базу данных
        void AddPerson();

        //Метод удаления элемента из базы данных
        void DeletePerson();

        //Метод редактирования элемента в базе данных
        void UpdatePerson();

        //Метод извлечения всех элементов из базы данных
        void GetAll();
    }
}
