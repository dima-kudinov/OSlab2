using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSlab2
{
    public class Process
    {
        Random rand = new Random();

        public List<Thread> Threads;

        public string name { get; private set; }
        public int maxTime;
        public int currentTime;
        private int threadMaxTime;

        public Process(string name, int maxTime, Priority priority)
        {

            this.name = "Процесс " + name + " с приоритетом: " + priority;

            Threads = new List<Thread>();
            int threadsNumber = rand.Next(4) + 1;
            threadMaxTime = this.maxTime / threadsNumber;

            for (int i = 0; i < threadsNumber; i++)
            {
                Threads.Add(new Thread("" + i, rand.Next(10) + 1, threadMaxTime));
            }
        }

        public int getCount()
        {
            return Threads.Count();
        }

        public bool isEmpty()
        {
            return !(Threads.Any());
        }

        public bool haveTime()
        {
            return maxTime > currentTime;
        }
    }
}
