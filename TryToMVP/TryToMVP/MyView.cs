using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryToMVP
{
    //Класс представления
    class MyView : IView
    {
        /// <summary>
        /// Функция вывода меню
        /// </summary>
        public void ShowMenu()
        {
            Console.WriteLine("\nДля добавления элемента в базу данных нажмите 'A'. Для редактирования элементов нажмите 'U'. Для удаления нажмите 'D'.");
        }

        //Функция вывода любого текстового сообшения
        public void ShowMessage(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Функция считывания данных с консоли
        /// </summary>
        /// <returns></returns>
        public string ReadIn()
        {
            string input = Console.ReadLine();

            return input;
        }

        //Функция вывода сообщения красным цветом
        public void WriteInRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(text);

            Console.ResetColor();
        }
    }
}
