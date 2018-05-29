using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryToMVP
{
    /// <summary>
    /// Представление операций модели
    /// </summary>
    interface IOperations
    {
        //Метод добавления элемента в базу данных
        void AddElement(ModelPerson mp);

        //Метод удаления элемента из базы данных
        string DeleteElement(ModelPerson mp);

        //Метод редактирования элемента из базы данных
        string UpdateElement(ModelPerson mp);

        //Метод поиска элемента в базе данных
        ModelPerson FindElement(int id);
    }
}
