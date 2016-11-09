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

			var bitmap = (Bitmap)Bitmap.FromFile("...");
			using (var bitmapEditor = new BitmapEditor(bitmap))
			{
				bitmapEditor.SetPixel(0, 1, 255, 255, 255);
			}

			Console.ReadKey();
		}

		//public static void Tes()
		//{
		//	var timer = new Timer();
		//	using (timer.Start())
		//	{
		//		LongOperation();
		//	}
		//	var time1 = (int)(timer.TimeInMiliseconds); // Mathematical error is two last symbols
		//	Console.WriteLine(time1);

		//	using (timer.Start())
		//	{
		//		LongOperation();
		//	}
		//	var time2 = (int)(timer.TimeInMiliseconds);
			
		//	Console.WriteLine(time2);

		//	using (timer.Start())
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
