using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class ExitSensor : Sensor
    {
        public ExitSensor(CarPark carPark) : base(carPark)
        {
        }

        public override void CarDetected()
        {
            carOnSensor = true;
            carPark.CarArrivedAtExit();
        }

        public override void CarLeftSensor()
        {
            carOnSensor = false;
            carPark.CarExitedCarPark();
        }
    }
}
