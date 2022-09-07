using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
	internal class Tracer : ITracer
	{
		private bool _isRunning;
		private Dictionary<string, MethodData>_methodInfo;

		public TraceResult Result()
		{
			throw new NotImplementedException();
		}

		public void Start()
		{
			//throw new NotImplementedException();
			string threadName = Thread.CurrentThread.Name;

			StackTrace stackTrace = new StackTrace();
			
			var frame = stackTrace.GetFrame(1);
			string methodName = frame.GetMethod().Name;
			string className = frame.GetMethod().ReflectedType.Name;
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			_isRunning = true;

		}

		public void Stop()
		{
			_isRunning = false;
		}

		
	}
}
