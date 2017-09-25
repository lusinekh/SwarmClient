using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwarmClient.ViewModels
{
	static class HelpperFunctions
	{
		#region Functions
		static public string GetIPAddress(string name)
		{
			string[] s = name.Split(':');
			return s[0];
		}
		static public int GetPort(string name)
		{
			string[] s = name.Split(':');
			int number2 = Convert.ToInt32(s[1]);
			return number2;
		}
#endregion
	}
}
