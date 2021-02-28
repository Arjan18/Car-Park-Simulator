using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class EntrySensor : Sensor
    {
        public EntrySensor(CarPark carPark) : base(carPark)
        {
        }

        public override void CarDetected()
        {
            carOnSensor = true;
            carPark.CarArrivedAtEntrance();
        }

        public override void CarLeftSensor()
        {
            carOnSensor = false;
            carPark.CarEnteredCarPark();
        }
    }
}