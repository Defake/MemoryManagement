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
		//public long TimeInMiliseconds { get; private set; } = 0;

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
			Stop();
		}
	}
}
