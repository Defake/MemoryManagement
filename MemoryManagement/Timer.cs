using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement 
{
	public class Timer
	{

		public long TimeInMiliseconds { get; private set; }

		public Timer()
		{
			TimeInMiliseconds = 0;
		}

		public IDisposable Start() => 
			new TimerDisposable((t) => TimeInMiliseconds = t);

		public IDisposable Continue() => 
			new TimerDisposable((t) => TimeInMiliseconds += t);

		private class TimerDisposable : IDisposable
		{
			private readonly Stopwatch _swTimer;
			private readonly Action<long> _disposeAction;

			public TimerDisposable(Action<long> disposeAction)
			{
				_disposeAction = disposeAction;
				_swTimer = new Stopwatch();
				_swTimer.Start();
			}

			public void Dispose()
			{
				_swTimer.Stop();
				_disposeAction(_swTimer.ElapsedMilliseconds);
			}
		}
			
	}
}
