using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class TicketMachine
    {
        private string message;
        private ActiveTickets ticketItem;
        private CarPark carPark;

        public TicketMachine(ActiveTickets ticketItem)
        {
            this.ticketItem = ticketItem;
        }

        public void AssignCarPark(CarPark carPark)
        {
            this.carPark = carPark;
        }

        public void CarArrived()
        {
            message = "Please press to get a ticket.";
        }

        public void PrintTicket()
        {
            ticketItem.AddTicket(new Ticket());
            message = "Thank you, enjoy your stay.";
            carPark.TicketDispensed();
        }

        public void ClearMessage()
        {
            message = " ";
        }

        public string GetMessage()
        {
            return message;
        }
    }
}
