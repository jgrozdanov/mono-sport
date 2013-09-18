using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;

namespace SportNet
{
	public class PictureBigCollectionCell : UICollectionViewCell
	{
		public static NSString CellId = (NSString)"picturesBigCell";

		private UIScrollView zoomPicture;
		private UIImageView image;

		[Export ("initWithFrame:")]
		public PictureBigCollectionCell (RectangleF frame) : base(frame)
		{
			this.zoomPicture = new UIScrollView (new RectangleF(0, 0, this.ContentView.Bounds.Width, this.ContentView.Bounds.Height));
			this.image = new UIImageView (new RectangleF (0, 0, this.ContentView.Bounds.Width, this.ContentView.Bounds.Height));
			this.image.ContentMode = UIViewContentMode.ScaleAspectFill;

			zoomPicture.Center = ContentView.Center;
			zoomPicture.AddSubview (image);
			zoomPicture.MaximumZoomScale = 3f;
			zoomPicture.MinimumZoomScale = 1f;
			zoomPicture.ViewForZoomingInScrollView += (UIScrollView sv) => { return image; };
			this.ContentView.AddSubview (zoomPicture);
		}

		public UIImage Image 
		{
			set {
				this.image.Image = value;
			}
		}
	}
}