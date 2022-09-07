using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 


namespace Example
{
	public  class Class1
	{
		Core.Tracer tracer = new();

		public void Test1()
		{
			tracer.Start();
			int x = 0;
			x++;
			x--;
			x = 2 * 123;
			tracer.Stop();
		}

		public void Test2()
		{
			
		}
	}
}
