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
		IReadOnlyDictionary<int, List<MethodData>> _traceInfo;
		public TraceResult( Dictionary<int, List<MethodData>> traceInfo )
		{
			_traceInfo = traceInfo;
		}
	}
}
