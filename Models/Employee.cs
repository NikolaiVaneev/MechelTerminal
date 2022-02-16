using MechelTerminal.Interfaces;
using System.Collections.Generic;

namespace MechelTerminal.Models
{
    internal class Employee : IEmployee
    {
        public Employee(int number)
        {
            Number = number;
            CurrentServices = new List<IService>();
        }

        public int Number { get; set; }
        public List<IService> CurrentServices { get; set; }
    }
}
