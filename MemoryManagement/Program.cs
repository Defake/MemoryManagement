using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement 
{
	class Program 
	{
		static void Main(string[] args)
		{
			//Tes();

			var bitmap = (Bitmap)Image.FromFile("1000x1000.bmp");
			var timer = new Timer();

			using (timer.StartTimer())
			{
				for (int x = 0; x < 1000; x++)
					for (int y = 0; y < 1000; y++)
						bitmap.SetPixel(x, y, Color.BurlyWood);
			}
			Console.WriteLine(timer.ElapsedMilliseconds); //986

			using (timer.StartTimer())
			{
				using (var bitmapEditor = new BitmapEditor(bitmap))
				{
					for (int x = 0; x < 1000; x++)
						for (int y = 0; y < 1000; y++)
							bitmapEditor.SetPixel(x, y, (byte) (255 - x/4), (byte) (y/4), (byte) (x/8 + y/8));
				}
			}
			Console.WriteLine(timer.ElapsedMilliseconds); //49

			Console.ReadKey();
		}

		//public static void Tes()
		//{
		//	var timer = new Timer();
		//	using (timer.StartTimer())
		//	{
		//		LongOperation();
		//	}
		//	var time1 = (int)(timer.TimeInMiliseconds); // Mathematical error is two last symbols
		//	Console.WriteLine(time1);

		//	using (timer.StartTimer())
		//	{
		//		LongOperation();
		//	}
		//	var time2 = (int)(timer.TimeInMiliseconds);
			
		//	Console.WriteLine(time2);

		//	using (timer.StartTimer())
		//	{
		//		LongOperation();
		//	}
		//	var time3 = (int)(timer.TimeInMiliseconds);
		//	Console.WriteLine(time3);

		//	using (timer.Continue())
		//	{
		//		LongOperation();
		//	}
		//	var timeCont1 = (int)(timer.TimeInMiliseconds);
		//	Console.WriteLine(timeCont1);

		//	using (timer.Continue())
		//	{
		//		LongOperation();
		//	}
		//	var timeCont2 = (int)(timer.TimeInMiliseconds);
		//	Console.WriteLine(timeCont2);

		//	//Math.Abs(time1 - time2) < 100;

		//	Console.ReadKey();
		//}

		//private static void LongOperation()
		//{
		//	for (int i = 0; i < 1000000; i++)
		//	{
		//		var b = new byte[30000];
		//	}
		//}
	}
}
