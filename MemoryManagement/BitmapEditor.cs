using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace MemoryManagement
{
	// Code fully from mdsn
	public class BitmapEditor : IDisposable
	{
		private readonly Bitmap _bitmap;
		private readonly BitmapData _bmpData;
		private readonly byte[] _rgbValues;
		private readonly IntPtr _ptr;
		private readonly int _bitmapByteSize;
		private readonly int _stride;

		public BitmapEditor(Bitmap bitmap)
		{
			_bitmap = bitmap;
			Rectangle rect = new Rectangle(0, 0, _bitmap.Width, _bitmap.Height);
			_bmpData = _bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, _bitmap.PixelFormat);

			// Get the address of the first line.
			_ptr = _bmpData.Scan0;

			// Declare an array to hold the bytes of the bitmap.
			_stride = Math.Abs(_bmpData.Stride);
			_bitmapByteSize = _stride * _bitmap.Height;
			_rgbValues = new byte[_bitmapByteSize];

			// Copy the RGB values into the array.
			System.Runtime.InteropServices.Marshal.Copy(_ptr, _rgbValues, 0, _bitmapByteSize);
		}

		public void Dispose()
		{
			// Copy the RGB values back to the bitmap
			System.Runtime.InteropServices.Marshal.Copy(_rgbValues, 0, _ptr, _bitmapByteSize);

			
			_bitmap.Save("new.bmp");

			// Unlock the bits.
			_bitmap.UnlockBits(_bmpData);
		}

		public void SetPixel(int x, int y, byte r, byte g, byte b)
		{
			var index = y*_stride + x*3;

			_rgbValues[index] = b;
			_rgbValues[index+1] = g;
			_rgbValues[index+2] = r;
		}
	}
}