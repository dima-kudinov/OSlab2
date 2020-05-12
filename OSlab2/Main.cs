using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSlab2
{
    class Program
    {
        private static List<Process> Processes = new List<Process>();
        private static Random rand = new Random();
        private static int quant = 10;

        static void Main(string[] args)
        {
            createProcess();
            getInfo();
            Implement();
        }

        private static void Implement()
        {
            if (quant < 1)
            {
                Console.WriteLine("Квант времени меньше 1");
                return;
            }
            while (Processes.Any())
            {
                for (int i = 0; i < Processes.Count(); i++)
                {
                    if (Processes[i].haveTime())
                    {
                        if (!Processes[i].isEmpty())
                        {
                            implementThreads(Processes[i]);
                        }
                        else
                        {
                            Console.WriteLine("Все потоки " + Processes[i].name + "  выполнены");
                            Processes.RemoveAt(i);
                            i--;
                        }
                    }
                    else
                    {
                        Processes.RemoveAt(i);
                        i--;
                    }
                }
            }
            Console.WriteLine("Все процессы выполнены");
        }

        private static void getInfo()
        {
            for (int i = 0; i < Processes.Count(); i++)
            {
                Console.WriteLine(Processes[i].name + " Потоков: " + Processes[i].getCount());
            }

            Console.WriteLine();
        }

        private static void createProcess()
        {

            for (int i = 0; i < rand.Next(5) + 3; i++)
            {
                Priority priority = (Priority)rand.Next(3);
                Processes.Add(new Process("" + i, quant * (int)priority, priority));
            }
        }

        private static void implementThreads(Process process)
        {
            if (!(process.maxTime > 0))
            {
                Console.WriteLine("Выделенный квант времени меньше 1");
                Environment.Exit(0);
            }
            Console.WriteLine("\n" + process.name + "  Время макс: " + process.maxTime);
            int initialThreadsCount = process.Threads.Count();
            int currentThreadsCount = process.Threads.Count();

            for (int curThreadNum = 0; curThreadNum < currentThreadsCount;)
            {
                Thread thread = process.Threads[curThreadNum];
                while (thread.needTime())
                {
                    if (thread.haveTime())
                    {
                        thread.execute();
                        process.currentTime++;
                    }
                    else
                    {
                        Console.WriteLine("Максимальное время " + 
                            "Поток " + (initialThreadsCount - currentThreadsCount) + " истекло");				
                        break;
                    }
                }
                Console.WriteLine(thread.name + " завершен");
                process.Threads.RemoveAt(curThreadNum);
                currentThreadsCount--;
            }
        }
    }
}
