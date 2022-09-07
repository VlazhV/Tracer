using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
	internal class MethodData
	{
		string _methodName;
		string _className;
		long _timeMs;

		public MethodData(string methodName, string className, long timeMs){
			_methodName = methodName;
			_className = className;
			_timeMs = timeMs;
		}

	}
}
