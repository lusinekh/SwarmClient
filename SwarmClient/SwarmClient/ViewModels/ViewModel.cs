﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SwarmClient.ViewModels
{
	public class ViewModel : INotifyPropertyChanged
	{
		#region  Variables
		private Model _model;
		private logic _logic;
		#endregion
		#region Constructrs
		public ViewModel()
		{
			_model = new Model();
			_logic = new logic();
			ConnectCommand = new Relaycommand(ConnectEcecute, CanEcecuteConnect);
			SendCommand = new Relaycommand(SendEcecute, CanEcecuteSend);
		}
		#endregion
		#region  Propertys
		public logic Logic
		{
			get { return _logic; }
			set
			{
				_logic = value;
				RaisePropertyChanged("Logic");
			}
		}
		public string ConnectionString
		{
			get { return Logic.ConnectionString; }
			set
			{
				Logic.ConnectionString = value;
				RaisePropertyChanged("ConnectionString");
			}
		}
		public string DataToSend
		{
			get { return Logic.DataToSend; }
			set
			{
				Logic.DataToSend = value;
				RaisePropertyChanged("DataToSend");
			}
		}

		public string ResivedData
		{
			get { return Logic.ResivedData; }
			set
			{
				Logic.ResivedData = value;
				RaisePropertyChanged("ResivedData");
			}
		}
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
			DataToSend = ConnectionString;

			//MessageBox.Show($"{ConnectionString},{DataToSend},{ResivedData}");
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

