namespace ejednev
{
    internal class Program
    {
        public static List<Sobytie> taskList = new List<Sobytie>();
        static List<Sobytie> searchTasks(DateTime data)
        {
            List<Sobytie> response = new List<Sobytie>();
            foreach (Sobytie task in taskList)
            {
                if (task.data == data)
                    response.Add(task);
            }
            return response;
        }
        static void newTask(DateTime data)
        {
            Console.Write("Введите титульник: ");
            string title = Console.ReadLine();
            Console.Write("Введите описание: ");
            string description = Console.ReadLine();
            taskList.Add(new Sobytie()
            {
                data = data,
                title = title,
                description = description,
            });
            Console.WriteLine("|:^) Выход");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            // DateTime currentData = DateTime.Now;
            // Console.WriteLine($"Список задач на {currentData.ToShortDateString()}");
            for (int i = 0; i < 5; i++)
                taskList.Add(new Sobytie());
            taskList[0] = new Sobytie()
            {
                data = new DateTime(2022, 10, 27),
                title = "Сдача работы",
                description = "workilng so hard"
            };
            taskList[1] = new Sobytie()
            {
                data = new DateTime(2022, 10, 27),
                title = "Ходить барьба",
                description = "Идти бароца жиес"
            };
            taskList[2] = new Sobytie()
            {
                data = new DateTime(2022, 10, 27),
                title = "Делать осла",
                description = "Осел сам себя не сделает жиес"
            };
            taskList[3] = new Sobytie()
            {
                data = new DateTime(2022,10,26),
                title = "Идти шаурмешна",
                description = "Дядя Нарек скидка мне делает среда жиес"
            };
            taskList[4] = new Sobytie()
            {
                data = new DateTime(2022, 10, 25),
                title = "Курсы по изучению русского языка",
                description = "Я должен выучить русский язык жиес"
            };
            DateTime currentDate = DateTime.Now;
            currentDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 0, 0, 0);
            int position = 1;
            int maxPosition;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Задачи на {currentDate.ToShortDateString()} жиес");
                
                string cursor = "|:^) ";
                List<Sobytie> todayTasks = searchTasks(currentDate);
                maxPosition = todayTasks.Count+1;
                foreach (var task in todayTasks)
                {
                    Console.WriteLine("     "+task.title);
                }
                Console.WriteLine("     Создать новую задачу");
                Console.SetCursorPosition(0, position);
                Console.WriteLine(cursor);
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                switch (keyPressed.Key)
                {
                    case ConsoleKey.RightArrow:
                        currentDate = currentDate.AddDays(1);
                        position = 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        currentDate = currentDate.AddDays(-1);
                        position = 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (position != maxPosition)
                            position++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (position != 1)
                            position--;
                        break;
                    case ConsoleKey.Enter:
                        if (position == maxPosition)
                        {
                            newTask(currentDate);
                        }
                        else
                        {
                            Sobytie ourTask = todayTasks[position-1];
                            Console.Clear();
                            Console.WriteLine(ourTask.title);
                            Console.WriteLine(ourTask.description);
                            Console.WriteLine(cursor+"Выход");
                            Console.ReadKey();
                        }
                        break;
                }
            }
        }
    }
}