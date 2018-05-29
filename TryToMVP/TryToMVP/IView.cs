using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryToMVP
{
    /// <summary>
    /// Интерфейс представления
    /// </summary>
    interface IView
    {
        //Метод вывода меню
        void ShowMenu();

        //Метод вывода сообщения
        void ShowMessage(string text);

        //Метод считывания с консоли
        string ReadIn();

        //Метод вывода сообщения красным цветом
        void WriteInRed(string text);

    }
}
