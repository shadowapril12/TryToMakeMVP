using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryToMVP
{
    /// <summary>
    /// Класс предсавителя
    /// </summary>
    class Presenter : IPresenter
    {
        //Экземпляр интерфейса 'IView'
        private IView _view;

        //Экземпляр интерфейса 'IOperatioons'
        private IOperations _modelOperations;

        //Идентификатор изменяемого элемента
        private int UpdatingId { get; set; }

        //Идентификатор удаляемого элемента
        private int DeletingId { get; set; }

        //Сообщение сигнализирующее о том найден ли необходимый элемент и выполнена ли операция успешно
        private string ResultMessage { get; set; } 

        /// <summary>
        /// Конструктор представителя
        /// </summary>
        /// <param name="view">Экземпляр класса 'MyView'</param>
        /// <param name="operations">Экземпляр класса 'ModelOoperations'</param>
        public Presenter(IView view, IOperations operations)
        {
            _view = view;
            _modelOperations = operations;
        }

        /// <summary>
        /// Метод добавления элемента в базу данных
        /// </summary>
        public void AddPerson()
        {
            //Экземпляр класса 'ModelPerson'
            ModelPerson mp = new ModelPerson();

            //Вывод сообщения
            _view.ShowMessage("\nВведите имя:");

            //Считывание с консоли ввеного имени
            mp.Name = _view.ReadIn();

            _view.ShowMessage("Введите номер:");

            //Присвоение нового номера
            mp.Number = _view.ReadIn();

            //Передача элемента в метод класса 'ModelOperations'
            _modelOperations.AddElement(mp);
        }

        /// <summary>
        /// Метод изменения данных о человеке
        /// </summary>
        public void UpdatePerson()
        {
            _view.ShowMessage("\nВыберите идентификатор элемента, котрорый хотите редактировать");

            //Считывание с консоли идентификатора удаляемого элемента
            UpdatingId = Convert.ToInt32(_view.ReadIn());

            //Передача идентификатора метод класса 'ModelOperations'
            ModelPerson mp = _modelOperations.FindElement(UpdatingId);

            //Если метод 'FindElement' вернул искомый элемент
            if(mp != null)
            {
                _view.ShowMessage("\nВведите имя");
                mp.Name = _view.ReadIn();

                _view.ShowMessage("Введите номер");
                mp.Number = _view.ReadIn();

                //Получение сообщения об успешном редактировании
                ResultMessage = _modelOperations.UpdateElement(mp);

                //Метод вывода сообщения красным цветом
                _view.WriteInRed(ResultMessage);
            }
            else
            {
                //Вывод сообщения о неудаче красным цветом
                _view.WriteInRed("По введеному индексу элемент не найден.");

                //Перезапуск метода 'Run'
                Run();
            }
        }

        /// <summary>
        /// Метод полчучения всех записей из базы данных
        /// </summary>
        public void GetAll()
        {
            //Подключение к базе данных
            using (PersonContext db = new PersonContext())
            {
                //Получение списка с элементами
                var persons = db.Persons;

                //Если количество элементов в списке больше нуля
                if(db.Persons.Count() > 0)
                {
                    //Вывод всех элементов в консоль
                    foreach (ModelPerson person in persons)
                    {
                        Console.WriteLine($"{person.Id} - {person.Name} - {person.Number}");
                    }
                }
                else
                {
                    //В обратном случае
                    _view.WriteInRed("База данных пока пуста.");
                }               
            }         
        }

        /// <summary>
        /// Метод удаления элемента из базы данных
        /// </summary>
        public void DeletePerson()
        {
            _view.ShowMessage("\nВыберите идентификатор элемента, котрорый хотите удалить");

            //Получение идентификатора удаляемого элемента
            DeletingId = Convert.ToInt32(_view.ReadIn());

            //Передача идентификатора методу класса 'ModelOperations'
            ModelPerson person = _modelOperations.FindElement(DeletingId);

            //Если такой элемент существует в базе данных
            if(person != null)
            {
                //Передача элемента методу класса 'ModelOperations'
                ResultMessage = _modelOperations.DeleteElement(person);

                //Вывод результирующего сообщения красным цыветом
                _view.WriteInRed(ResultMessage);
            }
            else
            {
                //В обратном случае
                _view.WriteInRed("По введеному мндексу элемента не найдено.");

                //Перезапуск метода 'Run'
                Run();
            }
            
        }

        /// <summary>
        /// Метод представляющий собой последовательность вызовов всех методов данного приложения в определенном порядке
        /// </summary>
        public void Run()
        {
            //Бесконечный цикл
            while(true)
            {
                _view.ShowMessage("***Все элементы в базе данных***");
                //Вызов метода по выводу всех элементов из базы данных
                GetAll();
                _view.ShowMessage("***");

                //Вывод меню
                _view.ShowMenu();

                //Считывание нажатой клавиши
                ConsoleKeyInfo button = Console.ReadKey();

                switch (button.Key)
                {
                    //В случае нажатия клавиши 'A'
                    case ConsoleKey.A:
                        //Вызывается метод по добавлению нового элемента
                        AddPerson();
                        break;
                    //В случае нажатия клавиши 'U'
                    case ConsoleKey.U:
                        //Вызывается метод по редактированию записи
                        UpdatePerson();
                        break;
                    //В случае нажатия клавиши 'D'
                    case ConsoleKey.D:
                        //Вызывается метод по удалению элемента
                        DeletePerson();
                        break;
                    default:
                        //Во всех остальных случаях выводится сообщение красным шрифтом
                        _view.WriteInRed("Вы выбрали некорректное действие");
                        break;
                }
               
            }
            
        }
        
    }
}
