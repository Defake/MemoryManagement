using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemoryManagement.Test 
{
	[TestClass]
	public class UnitTest1 
	{
		[TestMethod]
		public void TestMethod1() 
		{
			var timer = new Timer();
			using (timer.Start())
			{
				LongOperation();
			}
			var time1 = (int)(timer.ElapsedMilliseconds); 

			using (timer.Start())
			{
				LongOperation();
			}
			var time2 = (int)(timer.ElapsedMilliseconds);

			using (timer.Start())
			{
				LongOperation();
			}
			var time3 = (int)(timer.ElapsedMilliseconds);

			using (timer.Continue())
			{
				LongOperation();
			}
			var timeCont1 = (int)(timer.ElapsedMilliseconds);

			using (timer.Continue())
			{
				LongOperation();
			}
			var timeCont2 = (int)(timer.ElapsedMilliseconds);

			// Mathematical error is 100 last symbols
			Assert.IsTrue(Math.Abs(time1 - time2) < 150);
			Assert.IsTrue(Math.Abs(time2 - time3) < 150);
			
			Assert.IsTrue(Math.Abs(time2*2 - timeCont1) < 300);
			Assert.IsTrue(Math.Abs(timeCont1 + time3 - timeCont2) < 450);
		}

		private void LongOperation()
		{
			for (int i = 0; i < 1000000; i++)
			{
				var b = new byte[30000];
			}
		}
	}
}
