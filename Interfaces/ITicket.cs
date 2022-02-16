namespace MechelTerminal.Interfaces
{
    internal interface ITicket
    {
        /// <summary>
        /// Оператор
        /// </summary>
        IEmployee Employee { get; set; }
        /// <summary>
        /// Услуга
        /// </summary>
        IService Service { get; set; }
        /// <summary>
        /// Отпрвить на печать
        /// </summary>
        void Print();
    }
}