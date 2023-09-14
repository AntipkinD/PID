using System;
using System.Linq;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            //Process.Start("D:\\Games\\Half-Life\\hl.exe");
            Console.WriteLine("*** ПРОЦЕССЫ ***\n");
            string comm = Command();
            UseMyCommand(comm);
            // Используем рекурсию для вызова новых команд
            if (comm != "X")
                Main();
        }

        static string Command()
        {
            Console.WriteLine("Какую информацию нужно получить? \n" +
                " 1 - Список всех процессов по приоритетам\n 2 - Список всех процессов по PID\n" +
                "X - завершить программу");
            Console.Write("Введите команду: ");
            string comm = Console.ReadLine();
            return comm;
        }

        static void UseMyCommand(string str)
        {
            switch (str)
            {
                case "X":
                    break;
                case "1":
                    AllInfoProcess();
                    break;
                case "2":
                    AllInfoProcess2();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Команда не распознана!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
            Console.WriteLine();
        }

        static void AllInfoProcess()
        {
            var myProcess = from proc in Process.GetProcesses(".")
                            orderby proc.BasePriority
                            select proc;
            Console.WriteLine("\n*** Текущие процессы ***\n");
            foreach (var p in myProcess)
                //if (p.ProcessName == "")
                Console.WriteLine("-> Pririty: {2}\tPID: {0}\tName: {1}", p.Id, p.ProcessName, p.BasePriority);
        }
        static void AllInfoProcess2()
        {
            int k = 0;
            var myProcess = from proc in Process.GetProcesses(".")
                            orderby proc.Id
                            select proc;
            Console.WriteLine("\n*** Текущие процессы ***\n");
            foreach (var p in myProcess)
            {
                k++;
                if (k > 2)
                    Console.WriteLine("-> PID: {0}\tName: {1}", p.Id, p.ProcessName);
                else Console.WriteLine();
            }
            //if (p.ProcessName == "")
            k = 0;
            Console.WriteLine("Три процесса");
            foreach (var b in myProcess)
            {
                Console.WriteLine("-> PID: {0}\tName: {1}", b.Id, b.ProcessName);
                k++;
                if (k > 2)
                    break;
            }
        }
    }
}

/*задание 1.
10 раз вызвать блокнот через интервал задданный системным таймером + вывести список процессов с временем старта
задание 2.
вывести пиды и имена всех текущих процессов отдельно вывести первые три процесса
задание 3.
вывести процессы отсортированные по приоритету (приоритет можно не показывать)*/