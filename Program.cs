namespace PrakticheckaiRabota_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                List<Zametka> zametki = new List<Zametka>();
                ConsoleKeyInfo key;
                DateTime date = DateTime.Now;
                int arrow = 1;
                int max_arrow;

                do
                {
                    var ZametkiOnPage =
                        from zametka in zametki
                        where zametka.date == date
                        select zametka;
                    max_arrow = ZametkiOnPage.Count() + 1;

                    Interface(date, zametki);
                    Console.SetCursorPosition(0, arrow);
                    Console.WriteLine("---> ");

                    key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.RightArrow:
                            date = date.AddDays(+1);
                            break;
                        case ConsoleKey.UpArrow:
                            arrow--;
                            arrow = Arrows(arrow, max_arrow);
                            break;
                        case ConsoleKey.LeftArrow:
                            date = date.AddDays(-1);
                            break;
                        case ConsoleKey.DownArrow:
                            arrow++;
                            arrow = Arrows(arrow, max_arrow);
                            break;
                        case ConsoleKey.Enter:
                            if (arrow == 1)
                            {
                                CreateZametki(zametki, date);
                            }
                            if (arrow > 1)
                            {
                                OpenZametka(ZametkiOnPage.ToList()[arrow - 2]);
                            }
                            break;
                    }
                } while (key.Key != ConsoleKey.F5);
            }
            static void Interface(DateTime date, List<Zametka> zametki)
            {
                Console.Clear();
                Console.WriteLine(date.ToString("d"));
                Console.WriteLine(" Создаем заметочку ептить");
                foreach (var zametka in zametki)
                {
                    if (date == zametka.date)
                    {
                        Console.WriteLine(" " + zametka.name);
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Чтобы выйти с программы нажмите "F5");
            }
            static void CreateZametki(List<Zametka> zametki, DateTime date)
            {
                Console.Clear();
                string name = Console.ReadLine();
                string description = Console.ReadLine();
                zametki.Add(new Zametka() { date = date, name = name, description = description });
            }
            static void OpenZametka(Zametka zametka)
            {
                Console.Clear();
                Console.WriteLine(zametka.date);
                Console.WriteLine(zametka.name);
                Console.WriteLine(zametka.description);
                Console.WriteLine();
                Console.WriteLine("Рандомная кнопка позволяет закрыть меня закладок");
                Console.ReadKey();
            }
            static int Arrows(int arrow, int max_arrow)
            {
                if (arrow < 1)
                {
                    arrow = 1;
                }
                else if (arrow > max_arrow)
                {
                    arrow = max_arrow;
                }
                return arrow;
            }
        }
    }
}

class Zametka
{
}