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
        private Model _model;
        public ViewModel()
        {
            _model = new Model();
            AddCommand= new Relaycommand(Ececute, Canececute);
            AddCommand1 = new Relaycommand(Ececute1, Canececute);
        }
        public Model Model
        {
            get { return _model; }
            set { _model = value;
                RaisePropertyChanged("Model");
            }
        }
        public string Connected
        {
            get { return Model.Connected; }
            set { Model.Connected = value;
                RaisePropertyChanged("Connected");
            }
        }
        public string Sent
        {
            get { return Model.Sent; }
            set { Model.Sent = value;
                RaisePropertyChanged("Sent");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public void Ececute()
        {
            Connected = "Is string";
        }

        public void Ececute1()
        {
            Sent = "Sent";
        }
        public bool Canececute()
        {
            return true;
        }
        public ICommand AddCommand{ get;}
        public ICommand AddCommand1 { get; }
    }
        
        
    }

