﻿using SkiaSharp;
using System;
using System.Linq;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Platform.Skia
{
	public class Platform : IPlatform
	{
		public SizeRequest GetNativeSize(VisualElement view, double widthConstraint, double heightConstraint)
		{
			SizeRequest? result = null;

			if (view is Button || view is Label)
			{
				string text = null;
				TextDrawingData drawingData = null;
				if (view is Button button)
				{
					text = button.Text;

					drawingData = new TextDrawingData(button);
				}
				else if (view is Label label)
				{
					text = label.Text;
					drawingData = new TextDrawingData(label);
				}
				drawingData.Rect = new Rectangle(0, 0,
					double.IsPositiveInfinity(widthConstraint) ? float.MaxValue : widthConstraint,
					double.IsPositiveInfinity(heightConstraint) ? float.MaxValue : heightConstraint);

				Forms.GetTextLayout(text, drawingData, true, out var lines);

				Size size;
				if (lines.Count > 0)
					size = new Size(lines.Max(l => l.Width), lines.Sum(l => l.Height));
				else
					size = new Size();

				if (view is Button)
					size += new Size(10, 10);

				return new SizeRequest(size);
			}
			else if (view is Image image)
			{
				return new SizeRequest(new Size(100, 100));
			}

			if (result == null)
				throw new NotImplementedException();

			return result.Value;
		}
	}
}
