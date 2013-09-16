using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace SportNet
{
	public class PicturesCellModel
	{
		public string Heading { get; set; }
		public string Category { get; set; }
		public string ImageSource { get; set; }
		public string PhotoSource { get; set; }
		public int PicturesCount { get; set;}

		public PicturesCellModel ()
		{
		}
	}
}
