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
		private bool _isRunning = false;
		private Dictionary<int, List<MethodData>>_tempMethodInfo = new();

		public TraceResult Result()
		{
			throw new NotImplementedException();
		}

		public void Start()
		{
			if ( _isRunning ) return;

			int threadId = Thread.CurrentThread.ManagedThreadId;

			StackTrace stackTrace = new StackTrace();
			
			var frame = stackTrace.GetFrame(1);
			string methodName = frame.GetMethod().Name;
			string className = frame.GetMethod().ReflectedType.Name;
			Stopwatch stopwatch = new Stopwatch();
			MethodData methodData = new MethodData( methodName, className, stopwatch.ElapsedMilliseconds );
			this.AddToDictionary( threadId, methodData );

			stopwatch.Start();
			_isRunning = true;

		}

		public void Stop()
		{
			if (!_isRunning) return;


			_isRunning = false;
		}

		private void  AddToDictionary(int threadId, MethodData data)
		{
			List<MethodData> list = new List<MethodData>();						
			if (_tempMethodInfo.TryGetValue(threadId, out list))
			{
				list.Add( data );
				_tempMethodInfo[ threadId ] = list;
			}
			else
			{
				list.Add( data );
				_tempMethodInfo.Add( threadId, list );
			}
			
			
			
			
		}

		
	}
}
