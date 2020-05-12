using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSlab2
{
    public class Thread
    {
        public string name { get; private set; }
        public int maxTime { get; private set; }
        public int currentTime { get; private set; }
        public int requiredTime { get; private set; }

        public Thread(string description, int requiredTime, int maxTime)
        {
            this.maxTime = maxTime;
            this.requiredTime = requiredTime;
            this.currentTime = 0;
            this.name = "Поток " + description;
        }

        public void execute()
        {
            currentTime++;
            Console.WriteLine(getInfo());
        }

        public bool needTime()
        {
            return requiredTime > currentTime;
        }

        public bool haveTime()
        {
            return maxTime > currentTime;
        }

        public string getInfo()
        {
            return name + " maxTime:" + maxTime +
                " currentTime:" + currentTime + " requiredTime:" + requiredTime;
        }
    }
}
