using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement 
{
	public class Timer : Stopwatch, IDisposable
	{

		public IDisposable Start()
		{
			Restart();
			return this;
		}

		public IDisposable Continue()
		{
			base.Start();
			return this;
		}

		public void Dispose()
		{
			base.Stop();
		}
	}
}
