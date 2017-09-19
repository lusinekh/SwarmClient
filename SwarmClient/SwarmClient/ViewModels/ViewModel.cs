using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SwarmClient.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region  Variables
        private Model _model;
        #endregion
        #region Constructrs
        public ViewModel()
        {
            _model = new Model();
            ConnectCommand = new Relaycommand(ConnectEcecute, CanEcecuteConnect);
            SendCommand = new Relaycommand(SendEcecute, CanEcecuteSend);
        }
        #endregion
        #region  Propertys
        public Model Model
        {
            get { return _model; }
            set
            {
                _model = value;
                RaisePropertyChanged("Model");
            }
        }
        public string Connected
        {
            get { return Model.Connected; }
            set
            {
                Model.Connected = value;
                RaisePropertyChanged("Connected");
            }
        }
        public string Send
        {
            get { return Model.Send; }
            set
            {
                Model.Send = value;
                RaisePropertyChanged("Send");
            }
        }
        public ICommand ConnectCommand { get; }
        public ICommand SendCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Functions
        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public void ConnectEcecute()
        {
            Connected = "String is connected";
        }
        public void SendEcecute()
        {
            Send = "Sent";
        }
        public bool CanEcecuteConnect()
        {
            return true;
        }
        public bool CanEcecuteSend()
        {
            return true;
        }
        #endregion
    }
}

