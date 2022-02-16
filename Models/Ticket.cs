using MechelTerminal.Interfaces;
using System;
using System.Text;

namespace MechelTerminal.Models
{
    internal class Ticket : ITicket
    {
        public Ticket(IEmployee epmployee, IService service)
        {
            Employee = epmployee;
            Service = service;
        }
   
        public IService Service { get; set; }
        public IEmployee Employee { get; set; }

        public void Print()
        {
            StringBuilder ticket = new StringBuilder();

            ticket.AppendLine(new string('-', 20));
            ticket.AppendLine($"  Окно №{Employee.Number}. Ваш номер в очереди - {Employee.CurrentServices.Count}");
            ticket.AppendLine($"  {Service.Description} ({Service.Time} мин.)");
            ticket.AppendLine(new string('-', 20));

            Console.WriteLine(ticket.ToString());
        }
    }
}
