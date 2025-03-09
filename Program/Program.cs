using Lab_10;
using ToolLibrary;

namespace MainProgram
{
    public class Program
    {
        //Часть 1
        public static Tool[] CreateArray() 
        {

            Tool[] tools = new Tool[20];

            for (int i = 0; i < tools.Length / 4; i++)
            {
                tools[i] = new Tool();
                tools[i].IRandomInit();
            }


            for (int i = tools.Length / 4; i < tools.Length / 2; i++)
            {
                HandTool tool = new HandTool();
                tool.IRandomInit();
                tools[i] = tool;
            }


            for (int i = tools.Length / 2; i < tools.Length * 3 / 4; i++)
            {
                ElTool tool = new ElTool();
                tool.IRandomInit();
                tools[i] = tool;
            }


            for (int i = tools.Length * 3 / 4; i < tools.Length; i++)
            {
                MeasTool tool = new MeasTool();
                tool.IRandomInit();
                tools[i] = tool;
            }


            return tools;
        }
        public static void PrintArray(Tool[] tools) 
        {
            ShowData showData = new ShowData();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Объекты типа Tool: ");

            for (int i = 0; i < tools.Length / 4; i++)
            {

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Объект {i + 1}: ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Просмотр элемента при помощи обычного метода: ");
                Console.ForegroundColor = ConsoleColor.White;
                showData.Print(tools[i].Show());

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Просмотр элемента при помощи виртуального метода: ");
                Console.ForegroundColor = ConsoleColor.White;
                showData.Print(tools[i].VirtualShow());
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Объекты типа HandTool: ");

            for (int i = tools.Length / 4; i < tools.Length / 2; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Объект {i + 1}: ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Просмотр элемента при помощи обычного метода: ");
                Console.ForegroundColor = ConsoleColor.White;
                showData.Print(tools[i].Show());

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Просмотр элемента при помощи виртуального метода: ");
                Console.ForegroundColor = ConsoleColor.White;
                showData.Print(tools[i].VirtualShow());
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Объекты типа ElTool: ");

            for (int i = tools.Length / 2; i < tools.Length * 3 / 4; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Объект {i + 1}: ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Просмотр элемента при помощи обычного метода: ");
                Console.ForegroundColor = ConsoleColor.White;
                showData.Print(tools[i].Show());

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Просмотр элемента при помощи виртуального метода: ");
                Console.ForegroundColor = ConsoleColor.White;
                showData.Print(tools[i].VirtualShow());
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Объекты типа MeasTool: ");

            for (int i = tools.Length * 3 / 4; i < tools.Length; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Объект {i + 1}: ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Просмотр элемента при помощи обычного метода: ");
                Console.ForegroundColor = ConsoleColor.White;
                showData.Print(tools[i].Show());

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Просмотр элемента при помощи виртуального метода: ");
                Console.ForegroundColor = ConsoleColor.White;
                showData.Print(tools[i].VirtualShow());
            }

        }

        //Часть 2
        public static string SrAccuracy(Tool[] tools) 
        {
            double sum = 0, count = 0;

            foreach (var tool in tools) 
            {
                MeasTool correctTool = tool as MeasTool;

                if (correctTool != null) 
                {
                    sum += correctTool.Accuracy;
                    count++;
                }
            }

            return $"Средняя точность измерительных инструментов равна {Math.Round(sum / count, 2)}";
        }

        public static string ElToolCount(Tool[] tools)
        {
            int count = 0;

            foreach (var tool in tools)
            {
                if ((tool is ElTool) && (tool.Name == "отбойный молоток"))
                {
                    count++;
                }
            }

            return $"Всего было найдено {count} электических отбойных молотков";
        }

        public static string HandToolDrelsCount(Tool[] tools)
        {
            int count = 0;

            foreach (var tool in tools)
            {
                if ((tool.GetType() == typeof(HandTool)) && (tool.Name == "дрель"))
                {
                    count++;
                }
            }

            return $"Всего было найдено {count} ручных дрелей";
        }

        public static void Asks(Tool[] tools) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Запросы: ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Запрос 1: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(SrAccuracy(tools));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Запрос 2: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(ElToolCount(tools));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Запрос 3: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(HandToolDrelsCount(tools));
        }

        //Часть 3
        public static IInit[] CreateIInitArray() 
        {
            IInit[] array = new IInit[25];

            for (int i = 0; i < array.Length / 5; i++)
            {
                array[i] = new ChessboardCell();
                array[i].IRandomInit();
            }

            for (int i = array.Length / 5; i < array.Length * 2 / 5; i++)
            {
                array[i] = new Tool();
                array[i].IRandomInit();
            }

            for (int i = array.Length * 2 / 5; i < array.Length * 3 / 5; i++)
            {
                array[i] = new HandTool();
                array[i].IRandomInit();
            }

            for (int i = array.Length * 3 / 5; i < array.Length * 4 / 5; i++)
            {
                array[i] = new ElTool();
                array[i].IRandomInit();
            }

            for (int i = array.Length * 4 / 5; i < array.Length; i++)
            {
                array[i] = new MeasTool();
                array[i].IRandomInit();
            }

            return array;

        }

        public static void PrintIInitArray(IInit[] array) 
        {
            int chessCount = 0, toolCount = 0, elToolCount = 0, handToolCount = 0, measToolCount = 0;

            ShowData showData = new ShowData();

            foreach (var element in array) 
            {
                ChessboardCell cell = element as ChessboardCell;

                if (cell != null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Объект типа ChessboardCell: ");

                    Console.ForegroundColor = ConsoleColor.White;

                    showData.Print(cell.Show());
                    chessCount++;
                    continue;
                }

                else 
                {
                    toolCount++;

                    HandTool handTool = element as HandTool;

                    if (handTool != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Объект типа HandTool: ");

                        Console.ForegroundColor = ConsoleColor.White;
                        showData.Print(handTool.Show());
                        handToolCount++;
                        continue;
                    }

                    ElTool elTool = element as ElTool;

                    if (elTool != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Объект типа ElTool: ");

                        Console.ForegroundColor = ConsoleColor.White;

                        showData.Print(elTool.Show());
                        elToolCount++;
                        continue;
                    }

                    MeasTool measTool = element as MeasTool;

                    if (measTool != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Объект типа MeasTool: ");

                        Console.ForegroundColor = ConsoleColor.White;
                        showData.Print(measTool.Show());
                        measToolCount++;
                        continue;
                    }
                }

            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Всего было обнаружено {chessCount} элементов типа ChessBoardCell, а также {toolCount} элементов типа Tool:");
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{handToolCount} элементов типа HandTool");
            Console.WriteLine($"{elToolCount} элементов типа ElTool");
            Console.WriteLine($"{measToolCount} элементов типа MeasTool");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintToolArray(Tool[] tools)
        {
            ShowData showData = new ShowData();

            for (int i = 0; i < tools.Length / 4; i++)
            {

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Объект {i + 1}: ");

                Console.ForegroundColor = ConsoleColor.White;
                showData.Print(tools[i].VirtualShow());
            }

            for (int i = tools.Length / 4; i < tools.Length / 2; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Объект {i + 1}: ");

                Console.ForegroundColor = ConsoleColor.White;
                showData.Print(tools[i].VirtualShow());
            }

            for (int i = tools.Length / 2; i < tools.Length * 3 / 4; i++)
            {

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Объект {i + 1}: ");

                Console.ForegroundColor = ConsoleColor.White;
                showData.Print(tools[i].VirtualShow());
            }

            for (int i = tools.Length * 3 / 4; i < tools.Length; i++)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Объект {i + 1}: ");

                Console.ForegroundColor = ConsoleColor.White;
                showData.Print(tools[i].VirtualShow());
            }

        }

        //Name
        static void PrintArrayNameSort(Tool[] tools)
        {
            Array.Sort(tools);
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("Сортировка по названию инструмента");
            Console.ForegroundColor = ConsoleColor.White;
            PrintToolArray(tools);

        }

        static string NameBinarySearch(Tool[] tools)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Введите название инструмента для поиска: ");
            Console.ForegroundColor = ConsoleColor.White;
            string name = Console.ReadLine();
            Console.WriteLine();

            Array.Sort(tools);

            Tool searchTool = new Tool(name, 0);
            int number = Array.BinarySearch(tools, searchTool);

            if (number >= 0) { return $"Искомый объект: {tools[number].Show()}"; }
            return "Объект не найден";
        }

        //Year
        static void ArrayNameLengthSort(Tool[] tools)
        {
            Array.Sort(tools, new SortByNameLength());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Сортировка длине названия инструмента:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            PrintToolArray(tools);
        }

        static string YearBinarySearch(Tool[] tools)
        {
            int length = 0;
            Console.WriteLine();

            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Введите длину названия инструмента для поиска: ");
                Console.ForegroundColor = ConsoleColor.White;

                string inputData = Console.ReadLine();

                bool isConverted = int.TryParse(inputData, out length);

                if ((isConverted) && (length > 0))
                {
                    break;
                }

                else
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Длина названия инструмента должна быть числом больше 0, повторите попытку ");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            } while (true);


            Array.Sort(tools, new SortByNameLength());

            string smth = null;
            for (int i = 0; i < length; i++) { smth += "a"; }

            Tool searchTool = new Tool(smth, 0);

            int number = Array.BinarySearch(tools, searchTool, new SortByNameLength());
            if (number >= 0) { return $"Искомый объект: {tools[number].Show()}"; }
            return "Объект не найден";
        }

        //Разница между клонированием и поверхностным копированием объектов

        static void ShowCopies()
        {
            Tool tool = new Tool("дрель", 10);
            Tool clone = (Tool)tool.Clone();
            Tool copy = (Tool)tool.ShallowCopy();

            Console.WriteLine($"Сам объект: {tool.Show()}");
            Console.WriteLine($"Клон объекта: {clone.Show()}");
            Console.WriteLine($"Копия объекта: {copy.Show()}");

            Console.WriteLine();
            tool.ID.Number = 100;
            tool.Name = "перфоратор";

            Console.WriteLine($"Сам объект: {tool.Show()}");
            Console.WriteLine($"Клон объекта: {clone.Show()}");
            Console.WriteLine($"Копия объекта: {copy.Show()}");
        }

        static void Main(string[] args)
        {
            Tool[] tools = CreateArray();
            PrintArray(tools);
            Asks(tools);

            IInit[] array = CreateIInitArray();
            PrintIInitArray(array);

            Tool[] tools2 = CreateArray();

            PrintToolArray(tools2);
            Console.WriteLine(NameBinarySearch(tools2));

            ArrayNameLengthSort(tools2);
            Console.WriteLine(YearBinarySearch(tools2));

            ShowCopies();
        }
    }
}
