using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragRacing_project
{
    public  class Car
    {
        private float topspeed;
        private float speed;
        private int runningNumber;
        private float acceleration;
        private float accelerationTime;
        private float accelerationMeter;
        private float distance;
        private float stoptime;
        private Parts.Engines engine;
        private Parts.Colors color;
        
        public Parts.Engines Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        public Parts.Colors Color
        {
            get { return color; }
            set { color = value; }
        }
        public float Stoptime
        {
            get { return stoptime; }
            set { stoptime = value; }
        }
        public float Distance
        {
            get { return distance; }
            set { distance = value; }
        }
        public float AccelerationTime
        {
            get { return accelerationTime; }
            set { accelerationTime = value; }
        }
        public float AccelerationMeter
        {
            get { return accelerationMeter; }
            set { accelerationMeter = value; }
        }
        public float Acceleration
        {
            get { return acceleration; }
            set { acceleration = value; }
        }
        public float Topspeed
        {
            get { return topspeed; }
            set { topspeed = value; }
        }
        public float Speed
        {
            get { return speed; }
            set 
            { 
                speed = value; 
                if(value > topspeed)
                {
                    speed = topspeed;
                }
            }
        }
        public int RunningNumber
        {
            get { return runningNumber; }
            set { runningNumber = value; }
        }

        public Car(int _number,Parts.Colors _color,Parts.Engines _engine)
        {
            this.color = _color;
            this.engine = _engine;
            this.runningNumber = _number;
            configure_Car();
        }

        private void configure_Car()
        {
            if(engine == Parts.Engines.Jonda)
            {
                accelerationTime = 2.5f;
                accelerationMeter = 50;
                topspeed = 280;
                acceleration = 15;
            }
            else
            {
                accelerationTime = 4f;
                accelerationMeter = 100;
                topspeed = 330;
                acceleration = 6;
            }
        }

        public void DriveCar()
        {
            if (this.Speed < this.Topspeed)
            {
                this.Speed += this.Acceleration * Controller.GetDeltatime();

            }

            this.Distance += this.Speed * Controller.GetDeltatime();
        }
    }


}
