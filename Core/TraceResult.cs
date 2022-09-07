using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
	internal class TraceResult
	{
		//IReadOnlyList<MethodData> _traceInfo;
		IReadOnlyDictionary<string, MethodData> _traceInfo;
		public TraceResult( Dictionary<string, MethodData> traceInfo )
		{
			_traceInfo = traceInfo;
		}
	}
}
