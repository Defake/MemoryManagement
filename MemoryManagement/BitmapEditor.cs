using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace MemoryManagement
{
	// Code fully from mdsn
	public class BitmapEditor : IDisposable
	{
		private readonly Bitmap _bitmap;
		private readonly BitmapData _bmpData;

		private readonly List<Pixel> _modifiedPixels;

		public BitmapEditor(Bitmap bitmap)
		{
			_bitmap = bitmap;
			Rectangle rect = new Rectangle(0, 0, _bitmap.Width, _bitmap.Height);
			_bmpData = _bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, _bitmap.PixelFormat);

			_modifiedPixels = new List<Pixel>();
		}

		public void Dispose()
		{
			// Get the address of the first line.
			var ptr = _bmpData.Scan0;

			// Declare an array to hold the bytes of the bitmap.
			var stride = Math.Abs(_bmpData.Stride);

			// Write each changed pixel
			foreach (var pixel in _modifiedPixels)
			{
				var ptrAddValue = pixel.Y*stride + pixel.X*3;
				var rgbPixel = new byte[] {pixel.B, pixel.G, pixel.R};
				System.Runtime.InteropServices.Marshal.Copy(rgbPixel, 0, ptr + ptrAddValue, 3);
			}
			
			_bitmap.Save("new.bmp");

			// Unlock the bits.
			_bitmap.UnlockBits(_bmpData);
		}

		public void SetPixel(int x, int y, byte r, byte g, byte b) => 
			_modifiedPixels.Add(new Pixel {X = x, Y = y, R = r, G = g, B = b});

		private struct Pixel
		{
			public int X;
			public int Y;
			public byte R;
			public byte G;
			public byte B;

		}

	}
}