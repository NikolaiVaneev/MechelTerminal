using MechelTerminal.Models;
using System.Collections.Generic;
using System;
using MechelTerminal.Interfaces;
using System.Text;

namespace MechelTerminal
{
    internal class TerminalBuilder
    {
        public TerminalBuilder()
        {
            terminal = new Terminal
            {
                Services = new List<IService>()
            };
        }

        private readonly Terminal terminal;

        /// <summary>
        /// Установить приветственное сообщение
        /// </summary>
        /// <param name="_welcomeMessage">Сообщение</param>
        public void SetWelcomeMessage(string welcomeMessage)
        {
            terminal.WelcomeMessage = welcomeMessage;
        }
        /// <summary>
        /// Добавить новую услугу
        /// </summary>
        /// <param name="service"></param>
        public void AddService(IService service)
        {
            terminal.Services.Add(service);
        }
        /// <summary>
        /// Добавить коллекцию услуг
        /// </summary>
        /// <param name="services"></param>
        public void AddServiceRange(ICollection<IService> services)
        {
            foreach (IService service in services)
            {
                AddService(service);
            }
        }

        /// <summary>
        /// Запустить терминал
        /// </summary>
        /// <param name="showInfo">Показать информацию</param>
        /// <returns></returns>
        public Terminal Build(bool showInfo = true)
        {
            if (showInfo)
            {
                ShowHeader();
                ShowServices();
            }
            return terminal;
        }

        /// <summary>
        /// Отобразить заголовок
        /// </summary>
        private void ShowHeader()
        {
            string msg = terminal.WelcomeMessage;
            int indent = 5;
            char decorator = '/';

            if (!string.IsNullOrWhiteSpace(msg))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(new string(decorator, msg.Length + indent * 2));
                sb.Append(new string(decorator, indent - 1));
                sb.Append($" {msg} ");
                sb.AppendLine(new string(decorator, indent - 1));
                sb.AppendLine(new string(decorator, msg.Length + indent * 2));

                Console.WriteLine(sb.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        /// <summary>
        /// Отобразить услуги
        /// </summary>
        private void ShowServices()
        {
            if (terminal.Services.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("В настоящее время предоставление услуг не производится");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Вам доступны следующие виды услуг:");

                Console.ForegroundColor = ConsoleColor.White;
                foreach (var service in terminal.Services)
                {
                    sb.AppendLine($"  {service.Number} - {service.Description}");
                }

                Console.WriteLine(sb.ToString());
            }
        }
    }
}
