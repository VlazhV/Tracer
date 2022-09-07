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
		
		
		private Stopwatch _stopWatch;
		private int _currentThreadId;
		private MethodData _currentMethodData;
		

		public TraceResult Result()
		{
			throw new NotImplementedException();
		}

		
		public void Start()
		{
			if ( _isRunning ) return;

			int _currentThreadId = Thread.CurrentThread.ManagedThreadId;
			Stopwatch _stopwatch = new Stopwatch();

			_currentMethodData = GetFrameInfo();
			
			_isRunning = true;
			_stopwatch.Start();

		}

		public void Stop()
		{
			
			if (! _isRunning) return;
			_stopWatch.Stop();
			
			var checkMethodData = GetFrameInfo();
			var threadId = Thread.CurrentThread.ManagedThreadId;

			if ( !checkMethodData.Equals( _currentMethodData ) || !(threadId != _currentThreadId)) return;

			_currentMethodData.TimeMs = _stopWatch.ElapsedMilliseconds;

			this.AddToDictionary( _currentThreadId, _currentMethodData );

			_isRunning = false;
		}

		private void  AddToDictionary(int threadId, MethodData data)
		{
			List<MethodData> list = new List<MethodData>();
			if ( _tempMethodInfo.TryGetValue( threadId, out list ) )
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

		private MethodData GetFrameInfo(){
			StackTrace stackTrace = new StackTrace();
			var frame = stackTrace.GetFrame( 1 );
			string methodName = frame.GetMethod().Name;
			string className = frame.GetMethod().ReflectedType.Name;

			return new MethodData( methodName, className, _stopWatch.ElapsedMilliseconds );
		}

		
	}
}
