using MechelTerminal.Interfaces;

namespace MechelTerminal.Models
{
    internal class Service : IService
    {
        public Service(int number, string description, int time)
        {
            Number = number;
            Description = description;
            Time = time;
        }

        public int Number { get; set; }
        public string Description { get; set; }
        public int Time { get; set; }
    }
}
