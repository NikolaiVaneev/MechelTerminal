﻿using MechelTerminal.Interfaces;
using MechelTerminal.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MechelTerminal
{
    internal class Program
    {
        /// <summary>
        /// Терминал
        /// </summary>
        private static Terminal Terminal { get; set; }
        /// <summary>
        /// Операторы
        /// </summary>
        private static List<IEmployee> Employees { get; set; }

        static void Main()
        {
            EmployeesInit(3);

            TerminalBuilder tb = new TerminalBuilder();
            tb.SetWelcomeMessage("Добро пожаловать!");
            tb.AddService(new Service(1, "Получение выписки", 5));
            tb.AddService(new Service(2, "Оформление заказа", 7));
            tb.AddService(new Service(3, "Оформление возврата", 10));
            tb.AddService(new Service(4, "Консультация", 15));
            Terminal = tb.Build();

            if (Terminal.Services.Count > 0)
            {
                while (true)
                {
                    Work();
                }
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Инициализация рабочих окон
        /// </summary>
        /// <param name="employeesCount">Количество</param>
        private static void EmployeesInit(int employeesCount)
        {
            Employees = new List<IEmployee>();
            for (int i = 1; i < employeesCount + 1; i++)
            {
                Employees.Add(new Employee(i));
            }
        }

        private static void Work()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Выберите номер услуги: ");

            if (int.TryParse(Console.ReadLine(), out int serviceNumber))
            {
                // получаем выбранную услугу
                var selectedService = Terminal.Services.Where(s => s.Number == serviceNumber).FirstOrDefault();
                if (selectedService == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Такой услуги не найдено. Попробуйте снова");
                }
                else
                {
                    // Получаем менее загруженного оператора
                    var leastLoadedEmployee = Employees.OrderBy(t => t.CurrentServices.Sum(s => s.Time)).First();

                    if (480 - leastLoadedEmployee.CurrentServices.Sum(s => s.Time) < selectedService.Time)
                    {
                        Console.WriteLine("К сожалению, лимит талонов на данную услугу исчерпан");
                        return;
                    }

                    leastLoadedEmployee.CurrentServices.Add(selectedService);
                    // Выкатываем талон
                    Ticket ticket = new Ticket(leastLoadedEmployee, selectedService);
                    ticket.Print();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Введено некорректное значение! Попробуйте снова");
            }
        }
    }
}
