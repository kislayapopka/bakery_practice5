using bakery_practice5;

/*
Я представляю себе функционал программы так:
1. Пользователь переключается между пунктами меню (сделать метод для вывода меню и
отдельный класс с управлением стрелочками).
2. Каждый пункт побочного меню - это список, содержащий в себе описание услуги и цену 
на нее (эти значения должны быть где-то сохранены, чтобы в дальнейшем было удобно 
вывести общее сведение о заказе в текстовый файл).
3. Каждый пункт главного меню - это список, содержащий в себе список значений побочного
меню (опять лист листов?).
4. На вывод в текстовый документ идет отформатированная строковая переменная (при этом
надо оформить вывод через AppendAllText, чтобы предыдущие заказы не стирались).
5. В меню должна выводиться переменная с ценой, которая обновляется при добавлении
пункта заказа.

Все-таки надо с чего-то начинать. Пускай здесь будет какой-то список OrderListMenu,
который будет содержать в себе все данные, содержащиеся в пунктах меню создания заказа.
*/

internal class Program
{
    static void Main()
    {
        Idontknow.KeyArrows();
    }
    public static List<OrderListMenu[]> Generate()
    {

        OrderListMenu[] CakeShape = new OrderListMenu[] //Формочка тортика
        {
            new OrderListMenu("     Круг - 500", 500),
            new OrderListMenu("     Квадрат - 600", 600),
            new OrderListMenu("     Прямоугольник - 700", 700),
            new OrderListMenu("     Двухэтажный свадебный торт - 800", 800)
        };

        OrderListMenu[] CakeSize = new OrderListMenu[] //Размерчик тортика
        {
            new OrderListMenu("     Маленький - 200", 200),
            new OrderListMenu("     Средний - 300", 300),
            new OrderListMenu("     Большой - 400", 400),
            new OrderListMenu("     Ужасно большой - 800", 800)
        };

        OrderListMenu[] CakeShellFlavor = new OrderListMenu[] //Вкус коржика тортика
        {
            new OrderListMenu("     Безвкусный - 100", 100),
            new OrderListMenu("     С намеком на вкус - 200", 200),
            new OrderListMenu("     С привкусом - 300", 300),
            new OrderListMenu("     Вкусный - 1000", 1000)
        };

        OrderListMenu[] CakeShellAmount = new OrderListMenu[] //Количество коржиков тортика
        {
            new OrderListMenu("     С одним (1) коржом - 400", 400),
            new OrderListMenu("     С двумя (2) коржами - 500", 500),
            new OrderListMenu("     С четыремя (4) коржами - 600", 600),
            new OrderListMenu("     С двенадцатью (12) коржами [ЗАЧЕМ???] - 1200", 1200)
        };

        OrderListMenu[] CakeGlaze = new OrderListMenu[] //Глазурька тортика
        {
            new OrderListMenu("     Экзотические фрукты - 300", 300),
            new OrderListMenu("     Деревенские ягодки - 300", 300),
            new OrderListMenu("     Банальный шоколад - 300", 300),
            new OrderListMenu("     Нетривиальный мед - 300", 300)
        };

        OrderListMenu[] CakeDecor = new OrderListMenu[] //Декоративные штучки для тортика
        {
            new OrderListMenu("     Карамельные леденцы - 500", 500),
            new OrderListMenu("     Посыпка для пончиков - 500", 500),
            new OrderListMenu("     Слезы ученика МПТ - 500", 500),
            new OrderListMenu("     Сюрприз от главного кондитера - 500", 500)
        };

        /*
        После заполнения списка элементами необходимо заполнить лист по ключам элементов
        (Пока не придумал говорящего названия для этого листа, пока будет superbruh).
        */

        List<OrderListMenu[]> superbruh = new List<OrderListMenu[]>()
        {
            CakeShape, CakeSize, CakeShellFlavor, CakeShellAmount, CakeGlaze, CakeDecor
        };

        return superbruh;
    }

    public static void Menu(int position = 0, int pospos = 0)
    {
        List<OrderListMenu[]> bruh = Generate();
        if (position == 0)
        {
            Console.WriteLine("ДОБРО ПОЖАЛОВАТЬ В ПЕКАРНЮ МПТ");
            Console.WriteLine("==============================");
            Console.WriteLine("     ВЫБРАТЬ ФОРМУ ТОРТИКА");
            Console.WriteLine("     ВЫБРАТЬ РАЗМЕР ТОРТИКА");
            Console.WriteLine("     ВЫБРАТЬ ВКУС ТОРТИКА");
            Console.WriteLine("     ВЫБРАТЬ КОЛИЧЕСТВО КОРЖЕЙ");
            Console.WriteLine("     ВЫБРАТЬ ГЛАЗУРЬ");
            Console.WriteLine("     ВЫБРАТЬ ДЕКОР");
            Console.WriteLine("     ЗАВЕРШИТЬ ЗАКАЗ");
        }
        else if (position != 8)
        {
            Idontknow.Ext(bruh[position - 2]);
        }
        else if (position == 8)
        {
            Console.WriteLine("БЛАГОДАРИМ ВАС ЗА ЗАКАЗ! ОБЯХАТЕЛЬНО ПРИХОДИТЕ К НАМ ЕЩЕ!!!" +
                "ЕСЛИ ВЫ УЖЕ ВЕРНУЛИСЬ ДЛЯ НОВОГО ЗАКАЗА, ТО НАЖМИТЕ КНОПКУ ENTER");
            Idontknow.Zakaz();
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            { 
                OrderListMenu.Order.Clear();
                OrderListMenu.Cost.Clear();
                Idontknow.KeyArrows();
            }
        }
    }
}