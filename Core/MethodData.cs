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

		public long TimeMs 
		{ 
			get { return _timeMs; } 
			set { _timeMs = value; }
		}

		public MethodData(string methodName, string className, long timeMs){
			_methodName = methodName;
			_className = className;
			_timeMs = timeMs;
		}

		public override bool Equals( object? md )
		{
			if ( md == null ) return false;
			var md1 = (MethodData)md;
			return _methodName == md1._methodName &&
				   _className == md1._className;				   
		}

		

	}
}
