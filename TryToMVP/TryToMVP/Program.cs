using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryToMVP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создание экземпляра класса 'MyView'
            MyView myView = new MyView();

            //Создание экземпляра класса 'ModelOperations'
            ModelOperations modelOperations = new ModelOperations();

            //Вызов конструктора представителя, и передача ему экземпляров класса 'MyView' и 'ModelOperations'
            new Presenter(myView, modelOperations).Run();
        }
    }
}
