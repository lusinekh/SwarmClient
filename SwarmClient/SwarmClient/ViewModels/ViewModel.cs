﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
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
		private TcpServereConnect _connection;
		private bool _convert=false;
		public Visibility _visibility;
		#endregion
		#region Constructrs
		public ViewModel()
		{
			_model = new Model();
			_logic = new logic();
			_connection = new TcpServereConnect();
			ConnectCommand = new Relaycommand(ConnectEcecute, CanEcecuteConnect);
			SendCommand = new Relaycommand(SendEcecute, CanEcecuteSend);
			Visibility1 = Visibility.Hidden;
			ClosedCommand= new Relaycommand(ClosedEcecute, CanClosed);
		}
		#endregion
		#region  Propertys

		public Visibility Visibility1
		{
			get { return _visibility; }
			set
			{
				_visibility = value;
				RaisePropertyChanged("Visibility1");
			}
		}
		public TcpServereConnect Connection
		{
			get { return _connection; }
			set
			{
				_connection = value;
				RaisePropertyChanged("Connection");
			}
		}
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
		
		public bool Convert
		{
			get { return _convert; }
			set { _convert = value;
				RaisePropertyChanged("Convert");
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

		public TcpClient Client
		{
			get { return Connection.Client; }
			
			set
			{
				Connection.Client = value;
				RaisePropertyChanged("Client");
			}
		}


		public NetworkStream Stream
		{
			get { return Connection.stream; }

			set
			{
				Connection.stream = value;
				RaisePropertyChanged("Stream");
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
		public ICommand ClosedCommand { get; }
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion
		#region Functions
		public void RaisePropertyChanged(string name)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(name));
		}


		public void ClosedEcecute()
		{
			Stream.Close();
			Client.Close();
			

		}

		public bool CanClosed()
		{
			return true;
		}


		public void ConnectEcecute()
		{
			try
			{
				var _apiAddres = HelpperFunctions.GetIPAddress(ConnectionString);

				var _port = HelpperFunctions.GetPort(ConnectionString);
				Connection.Connect(_apiAddres, _port);
				Connected = "Contact is connected";
				Visibility1 = Visibility.Visible;
			}
			catch (Exception e)
			{
				Connected = "Contact do`nt connected";
				MessageBox.Show(e.ToString());
			}
			//MessageBox.Show($"{ConnectionString},{DataToSend},{ResivedData}");
		}
		public void SendEcecute()
		{
			Connection.SendMassage(DataToSend);
			Send = "Sent";
			ResivedData = _connection.responseData;
			

		}
		public bool CanEcecuteConnect()
		{
			if (ConnectionString == string.Empty)
				return false;
			return true;
		}
		public bool CanEcecuteSend()
		{
			return true;
		}
		#endregion
	}
}

