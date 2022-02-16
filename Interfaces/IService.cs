namespace MechelTerminal.Interfaces
{
    internal interface IService
    {
        /// <summary>
        /// Номер услуги
        /// </summary>
        int Number { get; set; }
        /// <summary>
        /// Описание услуги
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Время на услугу
        /// </summary>
        int Time { get; set; }
    }
}
