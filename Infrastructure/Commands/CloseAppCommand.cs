using RequestManager.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RequestManager.Infrastructure.Commands
{
    /// <summary>
    /// Класс команды, демонстирующий способ, когда объект команды создается автоматически, без инициализации
    /// в конструкторе
    /// </summary>
    internal class CloseAppCommand : Command
    {
        public override bool CanExecute(object? parameter) => true;


        public override void Execute(object? parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
