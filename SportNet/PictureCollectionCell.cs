using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;

namespace SportNet
{
	public class PictureCollectionCell : UICollectionViewCell
	{
		public static NSString CellId = (NSString)"picturesCollectionCell";

		public UIImageView Image { get; set; }

		[Export ("initWithFrame:")]
		public PictureCollectionCell (RectangleF frame) : base(frame)
		{
			this.Image = new UIImageView (new RectangleF (0, 0, this.ContentView.Bounds.Width, this.ContentView.Bounds.Height));
			this.Image.ContentMode = UIViewContentMode.ScaleToFill;
			this.ContentView.AddSubview (Image);

			BackgroundView = new UIView{BackgroundColor = UIColor.Clear};

			SelectedBackgroundView = new UIView{BackgroundColor = UIColor.Red};

			ContentView.Layer.BorderWidth = 0.0f;
//			ContentView.BackgroundColor = UIColor.White;
//			ContentView.Transform = CGAffineTransform.MakeScale (0.9f, 0.9f);
//
//			image.Center = ContentView.Center;
//			image.Transform = CGAffineTransform.MakeScale (0.8f, 0.8f);
		}
	}
}

