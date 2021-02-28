using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class TicketValidator
    {
        private string message;

        private ActiveTickets ticketItem;
        private CarPark carPark;

        public TicketValidator(ActiveTickets ticketItem)
        {
            this.ticketItem = ticketItem;
        }

        public void AssignCarPark(CarPark carPark)
        {
            this.carPark = carPark;
        }

        public void CarArrived()
        {
            message = "Please insert your ticket.";
        }

        public bool TicketEntered()
        {
            ticketItem.RemoveTicket();
            carPark.TicketValidated();
            message = "Thank you, drive safely.";
            return true;
        }

        public void ClearMessage()
        {
            message = "";
        }

        public string GetMessage()
        {
            return message;
        }
    }
}
