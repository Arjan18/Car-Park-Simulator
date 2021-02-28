using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkSimulator
{
    class PayTicket
    {
        private string message;                         // used to display output
        private ActiveTickets ticketPay;                   // declaring an object from ActiveTickets class
        public PayTicket(ActiveTickets ticketPay)         // association with ActiveTickets class
        {
            this.ticketPay = ticketPay;                       // store the reference of ticket object in ActiveTickets class
        }
        public void payForTicket()
        {
            ticketPay.GetTickets().SetPaid(true);      // gets the top ticket and sets the bool SetPaid to true
            message = "Ticket has been paid";
        }
        public void TicketToBePaid()
        {
            message = "You need to pay for your ticket";   // message output
        }
        public void ClearMessage()
        {
            message = " ";                              // clears the message in lblPayStation
        }
        public string GetMessage()
        {
            return message;
        }
    }
}
