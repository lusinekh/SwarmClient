﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwarmClient.ViewModels
{
	public class TcpServereConnect
	{
		#region  Variables
		private string _connectionString;
		private string _dataToSend;
		private string _resivedData;
#endregion
		public string ConnectionString
		{
			get { return _connectionString; }
			set { _connectionString = value; }
		}
		#region  Propertys
		public string DataToSend
		{
			get { return _dataToSend; }
			set { _dataToSend = value; }
		}
		public string ResivedData
		{
			get { return _resivedData; }
			set { _resivedData = value; }
		}
#endregion
	}
}
