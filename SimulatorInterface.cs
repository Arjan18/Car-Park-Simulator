using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarParkSimulator
{
    public partial class SimulatorInterface : Form
    {
        // Attributes ///        
        private TicketMachine ticketMachine;
        private ActiveTickets activeTickets;
        private TicketValidator ticketValidator;
        private Barrier entryBarrier;
        private Barrier exitBarrier;
        private FullSign fullSign;
        private CarPark carPark;
        private EntrySensor entrySensor;
        private ExitSensor exitSensor;
        private PayTicket PayForTicket;
        /////////////////


        // Constructor //
        public SimulatorInterface()
        {
            InitializeComponent();
        }
        /////////////////


        // Operations ///
        private void ResetSystem(object sender, EventArgs e)
        {
            // STUDENTS:
            ///// Class contructors are not defined so there will be errors
            ///// This code is correct for the basic version though
            activeTickets = new ActiveTickets();
            ticketMachine = new TicketMachine(activeTickets);
            ticketValidator = new TicketValidator(activeTickets);
            entryBarrier = new Barrier();
            exitBarrier = new Barrier();
            fullSign = new FullSign();
            carPark = new CarPark(PayForTicket,entryBarrier, exitBarrier, ticketValidator, fullSign, ticketMachine);
            entrySensor = new EntrySensor(carPark);
            exitSensor = new ExitSensor(carPark);
            PayForTicket = new PayTicket(activeTickets);

            ticketMachine.AssignCarPark(carPark);
            ticketValidator.AssignCarPark(carPark);

            /////////////////////////////////////////
            btnPayTicket.Visible = false;
            btnCarArrivesAtEntrance.Visible = true;
            btnDriverPressesForTicket.Visible = false;
            btnCarEntersCarPark.Visible = false;
            btnCarArrivesAtExit.Visible = false;
            btnDriverEntersTicket.Visible = false;
            btnCarExitsCarPark.Visible = false;

            UpdateDisplay();
        }

        private void CarArrivesAtEntrance(object sender, EventArgs e)
        {
            entrySensor.CarDetected();
            btnDriverPressesForTicket.Visible = true;
            btnCarArrivesAtEntrance.Visible = false;
            lstActiveTickets.Visible = true;
            UpdateDisplay();
        }

        private void DriverPressesForTicket(object sender, EventArgs e)
        {
            ticketMachine.PrintTicket();
            btnCarEntersCarPark.Visible = true;
            btnDriverPressesForTicket.Visible = false;
            UpdateDisplay();
        }

        private void CarEntersCarPark(object sender, EventArgs e)
        {
            entrySensor.CarLeftSensor();
            btnCarArrivesAtEntrance.Visible = true;
            btnCarArrivesAtExit.Visible = true;
            btnCarEntersCarPark.Visible = false;

            if (carPark.GetCurrentSpaces() == 0)
            {
                btnCarArrivesAtEntrance.Visible = false;
            }
            if (exitSensor.IsCarOnSensor() == true || exitBarrier.IsLifted() == true)

            {
                btnCarArrivesAtExit.Visible = false;
            }
            UpdateDisplay();
        }

        private void CarArrivesAtExit(object sender, EventArgs e)
        {
            exitSensor.CarDetected();
            btnCarArrivesAtExit.Visible = false;
            btnDriverEntersTicket.Visible = true;
            btnPayTicket.Visible = false;
            UpdateDisplay();
        }

        private void DriverEntersTicket(object sender, EventArgs e)
        {
            exitBarrier.Raise();                        // raise the exit barrier
            btnDriverEntersTicket.Visible = false;
            btnCarExitsCarPark.Visible = true;
            btnPayTicket.Visible = true;

            if (ticketValidator.TicketEntered() != true)    // if the ticket is not paid
            {
                btnDriverEntersTicket.Visible = false;      // prevent it from being removed from the listbox
            }
            
            UpdateDisplay();

        }

        private void CarExitsCarPark(object sender, EventArgs e)
        {
            exitSensor.CarLeftSensor();
            btnCarExitsCarPark.Visible = false;
            btnCarArrivesAtEntrance.Visible = true;
            // if carOnSensor in EntrySensor is true or lifted in EntryBarrier is true then
            if (entrySensor.IsCarOnSensor() == true || entryBarrier.IsLifted() == true)
            {
                btnCarArrivesAtEntrance.Visible = false;    // prevent any cars from arriving to the car park
            }
            if (carPark.GetCurrentSpaces() != 5)         // if the car park not empty, display btnCarArrivesAtExit
            {
                btnCarArrivesAtExit.Visible = false;
            }
            else
            {
                btnCarArrivesAtExit.Visible = false;     // if its empty, we have no cars to leave
            }
            UpdateDisplay();
        }

       

        private void groupBox7_Enter(object sender, EventArgs e)
        {

            
        }
            private void btnPayTicket_Click(object sender, EventArgs e)
        {
            PayForTicket.payForTicket();   // used to retrieve the top ticket and set it to paid
            btnDriverEntersTicket.Enabled = true;
            btnPayTicket.Visible = false;
            UpdateDisplay();
        }
             private void UpdateDisplay()

         {
            lblPaystation.Text = Convert.ToString(PayForTicket.GetMessage());
            lblSpaces.Text = Convert.ToString(carPark.GetCurrentSpaces());
            lblEntryBarrier.Text = Convert.ToString(entryBarrier.IsLifted());
            lblEntrySensor.Text = Convert.ToString(entrySensor.IsCarOnSensor());
            lblExitBarrier.Text = Convert.ToString(exitBarrier.IsLifted());
            lblExitSensor.Text = Convert.ToString(exitSensor.IsCarOnSensor());
            lblFullSign.Text = Convert.ToString(fullSign.IsLit());
            lblTicketMachine.Text = ticketMachine.GetMessage();
            lblTicketValidator.Text = ticketValidator.GetMessage();
            lstActiveTickets.Items.Clear();
            // used to loop over every ticket item in ticketList
            foreach (Ticket ticket in activeTickets.ticketList)
            {
                // add a random hashcode for the ticket while displaying its paid status
                lstActiveTickets.Items.Add("#" + ticket.GetHashCode() + ": " + ticket.IsPaid());
            }
        }
        private void lblPaystation_Click(object sender, EventArgs e)
        {

        }
    }
}
