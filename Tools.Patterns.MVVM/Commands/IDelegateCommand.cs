using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Tools.Patterns.MVVM.Commands
{
    public interface IDelegateCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}
