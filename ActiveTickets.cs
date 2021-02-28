using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class ActiveTickets
    {
        public List<Ticket> ticketList;

        public ActiveTickets()
        {
            ticketList = new List<Ticket>();
        }

        public void AddTicket(Ticket ticket)
        {
            ticketList.Add(ticket);
        }

        public void RemoveTicket()
        {
            ticketList.RemoveAt(0);
        }

        public Ticket GetTickets()      
        {
            return ticketList[0];
        }
    }
}
