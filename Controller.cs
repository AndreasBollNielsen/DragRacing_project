using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace DragRacing_project
{
    class Controller
    {
        public float Distance = 400;
        Car car1 = new Car(1, Parts.Colors.Blue, Parts.Engines.Poyota);
        Car car2 = new Car(2, Parts.Colors.Red, Parts.Engines.Jonda);

        public static Stopwatch speedwatch = new Stopwatch();
        private static DateTime currenttime = DateTime.Now;
        private static DateTime lasttime = DateTime.Now;
        public static bool RaceFinished;
        public static List<Car> cars = new List<Car>();

        //constructor of the controller
        public Controller()
        {
            cars = new List<Car>() { car1, car2 };
        }

        //run the race with same engine in both cars
        public void RunSameEngine()
        {
            Thread gui = new Thread(new ThreadStart(Program.show));
            Thread[] threads = new Thread[2];

            for (int i = 0; i < cars.Count; i++)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(RunRace));
                threads[i] = thread;

            }

            //start the threads
            threads[0].Start(cars[0]);
            threads[1].Start(cars[1]);
            gui.Start();

            threads[0].Join();
            threads[1].Join();

            //check if threads are done
            if(!threads[0].IsAlive && !threads[1].IsAlive)
            {
                RaceFinished = true;
            }

        }

        //run the race
        public void RunRace(object car)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Car _car = (Car)car;
            
            while (_car.Distance < 400)
            {
                currenttime = DateTime.Now;

                //accelerate to topspeed
                if (_car.Speed < _car.Topspeed)
                {
                    _car.Speed += _car.Acceleration * GetDeltatime();
                }

                

                // add distance to the car
                _car.Distance += _car.Speed * GetDeltatime();

                lasttime = currenttime;
            }



            watch.Stop();
            _car.Stoptime = watch.ElapsedMilliseconds / 1000f;

        }

        //get the delta time
        public static float GetDeltatime()
        {
            float dt = (currenttime.Ticks - lasttime.Ticks) / 10000000f;
            return dt;
        }


    }
}
