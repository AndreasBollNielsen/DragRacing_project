using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DragRacing_project
{
    class Program
    {
        public static bool checkResult = true;

        static void Main(string[] args)
        {
            Controller ctrl = new Controller();

            ctrl.RunSameEngine();

            while (checkResult)
            {
                if (Controller.RaceFinished)
                {
                    for (int j = 0; j < Controller.cars.Count; j++)
                    {
                        Console.WriteLine($" car number {Controller.cars[j].RunningNumber} finised at  {Controller.cars[j].Stoptime} seconds ");

                    }
                    checkResult = false;
                }
               
            }


            Console.ReadKey();
        }

        

        public static void show()
        {
            while (!Controller.RaceFinished)
            {
                for (int i = 0; i < Controller.cars.Count; i++)
                {
                    Console.WriteLine($"car number {Controller.cars[i].RunningNumber} distance: {Controller.cars[i].Distance}\n");
                    
                }
                Thread.Sleep(250);
                Console.Clear();

                Console.WriteLine(Controller.RaceFinished);
            }
        }
    }
}
