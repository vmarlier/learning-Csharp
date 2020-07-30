using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Subtitles
{
    public class Reader
    {
        public string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+@"/subtitles.srt";
        
        public void ReadText()
        {
            List<int> list = GetAllLineNb();

            int delayFirstBlock = GetTimeForStartFirstBlock();
            Thread.Sleep(delayFirstBlock);

            foreach (int i in list)
            {
                List<SubList> subList = GetBlockInList(i);
                int delayBetweenBlock = GetTimeBetweenBlock(i);

                foreach (SubList sub in subList)
                {
                    var timeStart = sub.time.Split(new [] {"-->"}, StringSplitOptions.None)[0];
                    var timeStop = sub.time.Split(new [] {"-->"}, StringSplitOptions.None)[1];
                    
                    TimeSpan timeSpanStart = TimeSpan.Parse(timeStart);
                    TimeSpan timeSpanStop = TimeSpan.Parse(timeStop);

                    float diffusionDelay0 = (float)timeSpanStop.TotalMilliseconds - (float)timeSpanStart.TotalMilliseconds;
                    int diffusionDelay = (int) diffusionDelay0;

                    
                    Console.Write(sub.text);
                    Thread.Sleep(diffusionDelay);
                    Console.Clear();
                    Thread.Sleep(delayBetweenBlock);
                }
                
            }

        }

        //Retourner le temps entre d'attente entre le bloc n/n+1
        public int GetTimeBetweenBlock(int x)
        {
            string time1 = ReadLine(x);
            string time2;

            if (x <= 2384 && ReadLine(x + 2) != "")
            {
                time2 = ReadLine(x + 5);

            }
            else
            {
                time2 = ReadLine(x + 4);
            }

            var timeBlock = time1.Split(new[] {"-->"}, StringSplitOptions.None)[1];
            var timeNextBlock = time2.Split(new[] {"-->"}, StringSplitOptions.None)[0];
            
            TimeSpan timeSpanBlock = TimeSpan.Parse(timeBlock);
            TimeSpan timeSpanNextBlock = TimeSpan.Parse(timeNextBlock);
            
            float delay0 = (float)timeSpanNextBlock.TotalMilliseconds - (float)timeSpanBlock.TotalMilliseconds;
            int delay = (int) delay0;

            return delay;
        }
        
        //Retourner le temps entre d'attente pour diffuser le premier bloc
        public int GetTimeForStartFirstBlock()
        {
            string time1 = ReadLine(1);

            var timeBlock = time1.Split(new [] {"-->"}, StringSplitOptions.None)[0];
            
            TimeSpan timeSpanBlock = TimeSpan.Parse(timeBlock);
            
            float delay0 = (float)timeSpanBlock.TotalMilliseconds;
            int delay = (int) delay0;

            return delay;
        }
        
        //Retourne la list contenant le temps en string et le text du bloc x fournit par LineNbForEachBlock
        public List<SubList> GetBlockInList(int x)
        {
            List<SubList> subLists = new List<SubList>();
            
            string time = ReadLine(x);
            string line1 = ReadLine(x+1);
            string text;

            if (x <= 2384 && ReadLine(x+2) != "")
            {
                text = line1 + " " + ReadLine(x + 2);
            }
            else
            {
                text = line1;
            }
            
            subLists.Add(new SubList(time,text));
            
            return subLists;
        }

        //Retourne toutes les lignes de début de chaque bloc
        public List<int> GetAllLineNb()
        {
            List<int> list = new List<int>();
            int x = 1;
            
            while (x <= 2383)
            {
                x = LineNbForEachBlock(x);
                list.Add(x);
            }
            
            return list;
        }
        
        //Retourne la ligne entre chaque bloc pour utiliser GetBlockInList
        public int LineNbForEachBlock(int x)
        {
            while (ReadLine(x) != "")
            {
                x++;
            }

            return x + 2;
        }

        //Lire la ligne skip+1
        public string ReadLine(int skip)
        {
            return File.ReadLines(path).Skip(skip).Take(1).First();
        }
        
    }
}