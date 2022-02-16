using System.Collections.Generic;

namespace MechelTerminal.Interfaces
{
    internal interface IEmployee
    {
        /// <summary>
        /// Номер оператора
        /// </summary>
        int Number { get; set; }
        /// <summary>
        /// Текущие задачи
        /// </summary>
        List<IService> CurrentServices { get; set; }
    }
}