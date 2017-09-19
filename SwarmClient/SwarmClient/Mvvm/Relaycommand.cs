using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace SwarmClient
{
    class Relaycommand : ICommand
    {
        #region Variables
        private Action _ececute;
        private Func<bool> _canececute;
#endregion
        #region Constructrs
        public Relaycommand(Action ececute) : this(ececute, null)
        { }
        public Relaycommand(Action ececute,Func<bool> canececute)
        {
            _ececute = ececute;
            _canececute = canececute;
        }
        #endregion
        #region Propertys
        public event EventHandler CanExecuteChanged
        {
            add {
                if (_canececute != null)
                    CommandManager.RequerySuggested += value;
                }
            remove
            {
                if (_canececute != null)
                    CommandManager.RequerySuggested -= value;
            }

        }
        #endregion
        #region Functions
        public bool CanExecute(object parameter)
        {
           return _canececute==null?true:_canececute();
        }

        public void Execute(object parameter)
        {
            _ececute();
        }
#endregion
    }
}
