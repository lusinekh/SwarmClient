using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwarmClient.ViewModels
{
	public class Model
	{
        #region  Variables
        private string _conected;
        private string _sent;
       
        #endregion
        #region  Propertys
        public string Connected
        {
            get { return _conected; }
            set { _conected = value; }
        }
        public string Sent
        {
            get { return _sent; }
            set { _sent = value; }
        }
#endregion
    }
}
