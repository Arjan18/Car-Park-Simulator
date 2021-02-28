using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    abstract class Sensor
    {
        protected CarPark carPark;
        protected bool carOnSensor;

        public Sensor(CarPark carPark)
        {
            carOnSensor = false;
            this.carPark = carPark;
        }

        public abstract void CarDetected();
        public abstract void CarLeftSensor();

        public bool IsCarOnSensor()
        {
            return carOnSensor;
        }
    }
}
