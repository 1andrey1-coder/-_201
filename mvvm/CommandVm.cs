using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Билет_20.mvvm
{
    public class CommandVm : ICommand
    {
        private readonly Action action;
        private readonly Func<bool> condition;


        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public CommandVm(Action action, Func<bool> condition)
        {
            this.action = action;
            this.condition = condition;
        }
       
        public bool CanExecute(object? parameter)
        {
            return condition();
        }

        public void Execute(object? parameter)
        {
            action();
        }
    }
}
