using MechelTerminal.Interfaces;
using System.Collections.Generic;

namespace MechelTerminal.Models
{
    internal class Terminal
    {
        public Terminal()
        {
            Services = new List<IService>();
        }

        
        /// <summary>
        /// Услуги
        /// </summary>
        public List<IService> Services { get; set; }
        /// <summary>
        /// Приветственное сообщение
        /// </summary>
        public string WelcomeMessage { get; set; }
    }
}
