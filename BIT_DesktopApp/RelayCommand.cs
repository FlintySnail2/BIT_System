using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BIT_DesktopApp
{
    public class RelayCommand 
    {
        private Action _whatToExecute;
        private event EventHandler CanExecuteChanged;
        private bool _canExecute;

        public RelayCommand(Action what, bool canExecute)
        {
            _whatToExecute = what;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }
        public void Execute(object parameter)
        {
            _whatToExecute.Invoke();
        }
    }

}
