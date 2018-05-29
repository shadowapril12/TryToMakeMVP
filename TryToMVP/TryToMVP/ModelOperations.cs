using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TryToMVP
{
    /// <summary>
    /// Класс операций модели
    /// </summary>
    class ModelOperations : IOperations
    {
        /// <summary>
        /// Метод добавления элемента в базу данных
        /// </summary>
        /// <param name="mp">Экземпляр класса 'MoodelPerson'</param>
        public void AddElement(ModelPerson mp)
        {
            //Подключение к базе данных
            using (PersonContext db = new PersonContext())
            {
                //Добаления элемента в баззу
                db.Persons.Add(mp);

                //Сохранение изменений
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Метод поиска элемента в базе данных
        /// </summary>
        /// <param name="id">Идентификатор искомого элемента</param>
        /// <returns>Возвращщает найденный объект</returns>
        public ModelPerson FindElement(int id)
        {
            //Подключение к базе данных
            using (PersonContext db = new PersonContext())
            {
                //Искомый элемент
                var person = db.Persons.Where(p => p.Id == id).FirstOrDefault();

                return person;
            }
        }

        /// <summary>
        /// Метод редактирования элементов в базе данных
        /// </summary>
        /// <param name="mp">Объект над которым производится редактирование</param>
        /// <returns>Возвращает текстовое сообщение</returns>
        public string UpdateElement(ModelPerson mp)
        {
            //Плдключение к базе данных
            using (PersonContext db = new PersonContext())
            {
                //Получение редактируемого элемента
                ModelPerson updatingPerson = db.Persons.Where(p => p.Id == mp.Id).FirstOrDefault();

                //Установка нвого имени
                updatingPerson.Name = mp.Name;

                //Установка нового номера
                updatingPerson.Number = mp.Number;

                //Сохранение изменений
                db.SaveChanges();

                return $"Данные успешно обновлены";
            }          
        }

        /// <summary>
        /// Метод удаления элемента из базы данных
        /// </summary>
        /// <param name="mp">Удаляемый элемент</param>
        /// <returns></returns>
        public string DeleteElement(ModelPerson mp)
        {
            using (PersonContext db = new PersonContext())
            {
                //Получение удаляемого элемента из базы данных
                ModelPerson deletingPerson = db.Persons.Where(p => p.Id == mp.Id).FirstOrDefault();

                try
                {
                    //Попытка удалить элемент
                    db.Persons.Remove(deletingPerson);
                }
                catch
                {
                    //В случае неудачи возвращщается текстовое сообщение
                    return $"Неверно задан индекс элемента.";
                }

                //Сохранение изменений
                db.SaveChanges();

                return "Удаление успешно выполнено";
            }
        }
    }
}
