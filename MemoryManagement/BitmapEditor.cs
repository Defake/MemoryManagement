using System;
using System.Drawing;

namespace MemoryManagement
{
	public class BitmapEditor : IDisposable
	{

		private Bitmap _bitmap;

		public BitmapEditor(Bitmap bitmap)
		{
			_bitmap = bitmap;
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public void SetPixel(int i, int i1, int i2, int i3, int i4)
		{
			throw new NotImplementedException();
		}
	}
}