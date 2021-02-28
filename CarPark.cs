using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class CarPark
    {
        private Barrier entryBarrier, exitBarrier;
        private FullSign fullSign;
        private TicketMachine ticketMachine;
        private TicketValidator ticketValidator;
        private PayTicket PayForTicket;
        private int currentSpaces = 0;
        private const int maxSpaces = 5;

        public CarPark(PayTicket payForTicket, Barrier entryBarrier, Barrier exitBarrier, TicketValidator ticketValidator, FullSign fullSign, TicketMachine ticketMachine)
        {
            this.PayForTicket = payForTicket;
            this.entryBarrier = entryBarrier;
            this.exitBarrier = exitBarrier;
            this.fullSign = fullSign;
            this.ticketMachine = ticketMachine;
            this.ticketValidator = ticketValidator;
        }

        public void CarArrivedAtEntrance()

        {
            ticketMachine.CarArrived();
        }

        public void TicketDispensed()

        {
            entryBarrier.Raise();
        }

        public void CarEnteredCarPark()
        {
            ticketMachine.ClearMessage();
            entryBarrier.Lower();
            currentSpaces = currentSpaces + 1;
            GetCurrentSpaces();

            if (currentSpaces == 5)
            {
                fullSign.SetLit(true);
                fullSign.IsLit();
            }
        }

        public void CarArrivedAtExit()
        {
            ticketValidator.CarArrived();
        }

        public void TicketValidated()

        {
            exitBarrier.Raise();
        }

        public void CarExitedCarPark()
        {
            currentSpaces = currentSpaces - 1;
            ticketValidator.ClearMessage();
            exitBarrier.Lower();
        }

        public bool IsFull()
        {
            return (currentSpaces == 0);
        }

        public bool IsEmpty()
        {
            return (currentSpaces == 5);
        }

        public bool HasSpace()
        {
            return (currentSpaces != 0);
        }

        public int GetCurrentSpaces()
        {
            return (maxSpaces - currentSpaces);
        }
    }
}
