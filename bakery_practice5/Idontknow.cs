using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bakery_practice5
{
    internal class Idontknow
    {
        private static ConsoleKeyInfo key = Console.ReadKey();
        private static string adress = "C:\\Users\\naili\\OneDrive\\Рабочий стол\\Заказ.txt";

        /*
        Теперь перейду к управлению через стрелочное меню. Переменная key принимает в себя
        данные, введенные клавиатуры, а переменная TF нужна для того, чтобы зациклить этот 
        метод. Вход из него будет производиться, когда переменная приймет значение false.
        */ 

        public static void KeyArrows()
        {
            key = Console.ReadKey();
            bool TF = true;

            while (TF == true)
            {
                int position = 0;
                Program.Menu();

                while (key.Key != ConsoleKey.Enter)
                {
                    if (key.Key == ConsoleKey.UpArrow)
                    {

                        /*
                        Чтобы счетчик позиции не входил в outofrange сделаю исключение, 
                        при выполнении которого стрелка будет возвращаться в начало, то
                        есть к первому пункту меню.
                        */

                        position--;
                        if (position < 2) 
                        {
                            position = 8;
                        }
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        position++;
                        if (position > 8)
                        {
                            position = 2;
                        }
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    { 
                        TF = false;
                        break;
                    }

                    /*
                    После считывания кнопки консоль должна очиститься, а затем
                    снова отрисовать все элементы меню (текст и курсор). Потом
                    снова запросить пользователя ввести клавишу с клавиатуры.
                    */ 

                    Console.Clear();
                    Program.Menu();
                    Console.SetCursorPosition(0, position);
                    Console.WriteLine("->");
                    key = Console.ReadKey();
                }

                /*
                Цикл завершается после нажатия клавиши Enter. Затем программа
                считывает значение переменной position, на которой находился
                курсор в момент нажатия Enter.
                */

                Console.Clear();
                if (position >= 2) 
                { 
                    Program.Menu(position);
                    key = Console.ReadKey();
                    int pospos = 0;
                    while (key.Key != ConsoleKey.Enter)
                    {
                        if (key.Key == ConsoleKey.UpArrow)
                        {
                            pospos--;
                            if (pospos < 0)
                            {
                                pospos = 3;
                            }
                        }
                        else if (key.Key == ConsoleKey.DownArrow)
                        {
                            pospos++;
                            if (pospos > 3)
                            {
                                pospos = 0;
                            }
                        }
                        else if (key.Key == ConsoleKey.Escape)
                        {
                            break;
                        }
                        Console.Clear();
                        Program.Menu(position, pospos);

                        Console.SetCursorPosition(0, pospos);
                        Console.WriteLine("->");
                        key = Console.ReadKey();
                    }
                    Console.Clear();
                    List<OrderListMenu[]> bruh = Program.Generate();
                    Add(bruh, position - 2, pospos);
                }
                Program.Menu();
                key= Console.ReadKey();
            }
        }
        public static void Ext(OrderListMenu[] AllPoints)
        { 
            foreach (OrderListMenu point in AllPoints) 
            { 
                Console.WriteLine(point.Description);
            }
        }

        public static void Add(List<OrderListMenu[]> AllPoints, int position, int pospos)
        {
            if (key.Key == ConsoleKey.Enter)
            {
                OrderListMenu.Order.Add(AllPoints[position][pospos].Description);
                OrderListMenu.Cost.Add(AllPoints[position][pospos].Price);
            }
        }
        public static void Out()
        {
            Console.WriteLine("ИТОГОВАЯ ЦЕНА ЗАКАЗА: ");
            OrderListMenu.supCost = OrderListMenu.Cost.Sum();
            Console.WriteLine(OrderListMenu.supCost);
            Console.WriteLine("ВАШ ЗАКАЗ: ");
            foreach (string line in OrderListMenu.Order)
            { 
                Console.WriteLine(line);
            }
        }
        public static void Zakaz()
        {
            OrderListMenu.supCost = OrderListMenu.Cost.Sum();
            string line1 = Convert.ToString(OrderListMenu.supCost);
            string heading = "\n\nЗАКАЗ В ПЕКАРНЕ МПТ\n=================================";
            string line2 = String.Join("\n", OrderListMenu.Order);
            File.AppendAllText(adress, heading);
            File.AppendAllText(adress, $"\nОБЩАЯ СТОИМОСТЬ ВАШЕГО ЗАКАЗА: {line1}");
            File.AppendAllText(adress, $"\nВАШ ЗАКАЗ: {line2}");
            File.AppendAllText(adress, $"\nДАТА И ВРЕМЯ ВАШЕГО ЗАКАЗА: {DateTime.Now.ToString()}");
        }
    }
}
