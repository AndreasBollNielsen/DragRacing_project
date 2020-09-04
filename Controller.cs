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


        Car car1 = new Car(1, Parts.Colors.Blue, Parts.Engines.Jonda);
        Car car2 = new Car(2, Parts.Colors.Red, Parts.Engines.Jonda);

        public static Stopwatch speedwatch = new Stopwatch();
        private static DateTime currenttime = DateTime.Now;
        private static DateTime lasttime = DateTime.Now;
        public static bool RaceFinished;
        public static List<Car> cars = new List<Car>();

        public Controller()
        {
            cars = new List<Car>() { car1, car2 };

        }

        public void RunSameEngine()
        {
            Thread gui = new Thread(new ThreadStart(Program.show));
            Thread[] threads = new Thread[2];
          
            for (int i = 0; i < cars.Count; i++)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(RunRace));
                threads[i] = thread;

            }
            threads[0].Start(cars[0]);
            threads[1].Start(cars[1]);
            gui.Start();

            threads[0].Join();
            threads[1].Join();
          


            RaceFinished = true;
            
        }


        public void RunRace(object car)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            float timer = 0;
            float currentStep = 0;
            Car _car = (Car)car;

            while (_car.Distance < 400)
            {
                currenttime = DateTime.Now;
                
                //accelerate to topspeed
                if (_car.Speed < _car.Topspeed)
                {
                    _car.Speed += _car.Acceleration * GetDeltatime();
                }
                
                if(currenttime.Second >= currentStep )
                {
                    timer++;
                    currentStep = currenttime.Second*2;
                    Console.WriteLine(currentStep);
                }

                // add distance to the car
                _car.Distance += _car.Speed * GetDeltatime();
              //  Program.ShowCars(_car);
             //   Console.Write("current distance: \n" + _car.Distance);

                //  _car.FractionalDistance.Add(_car.Distance);
                lasttime = currenttime;
            }



            watch.Stop();
            _car.Stoptime = watch.ElapsedMilliseconds / 1000f;
         
        }

       

        public static float GetDeltatime()
        {
            float dt = (currenttime.Ticks - lasttime.Ticks) / 10000000f;
            return dt;
        }


    }
}
