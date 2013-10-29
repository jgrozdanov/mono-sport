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

		private TouchScrollView zoomPicture;
		private UIImageView image;
//		private UIView helpView;
//		private UILabel heading;
//		private UILabel category;

		// TODO:
		// IMPLEMENT THE HELP VIEW AND SHIT

		private class TouchScrollView : UIScrollView
		{
			public UIView Target { get; set; }

			public TouchScrollView(RectangleF frame) : base(frame)
			{
			}

//			public override void TouchesEnded (NSSet touches, UIEvent evt)
//			{
//				if (Target.Hidden) {
//					Target.Hidden = false;
//				} 
//				else {
//					Target.Hidden = true;
//				}
//			}
		}

		[Export ("initWithFrame:")]
		public PictureBigCollectionCell (RectangleF frame) : base(frame)
		{
			this.zoomPicture = new TouchScrollView (new RectangleF(0, 0, this.ContentView.Bounds.Width, this.ContentView.Bounds.Height));
			this.zoomPicture.ZoomScale = 1f;

			//this.image = new UIImageView (new RectangleF (0, 0, this.ContentView.Bounds.Width, this.ContentView.Bounds.Height));
			//this.image.ContentMode = UIViewContentMode.ScaleAspectFit;

			this.image = new UIImageView ();

//			helpView = new UIView (new RectangleF (0, this.ContentView.Frame.Bottom - 170, this.ContentView.Bounds.Width, 170));
//			helpView.BackgroundColor = UIColor.FromRGBA (0, 0, 0, 120);
//			heading = new UILabel (new RectangleF (20, 30, this.ContentView.Bounds.Width - 40, 80));
//			heading.TextColor = UIColor.White;
//			heading.Font = UIFont.FromName ("Helvetica-Bold", 16f);
//			heading.Text = "Straight, Why Pree?";
//			heading.Lines = 3;
//			category = new UILabel (new RectangleF (20, 10 , this.ContentView.Bounds.Width - 40, 20));
//			category.TextColor = UIColor.Red;
//			category.Text = "Football";
//			category.Font = UIFont.FromName ("Helvetica", 12f);
//			helpView.AddSubview (heading);
//			helpView.AddSubview (category);
//
//			zoomPicture.Target = helpView;
//
//			this.ContentView.AddSubview (helpView);
//			heading.SizeToFit ();v
		}

		public UIImageView Image 
		{
			get {
				return image;
			}

			set {
				this.image = value;
			}
		}

		public void resetScale()
		{
			this.zoomPicture.ZoomScale = 1f;
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			zoomPicture.Center = ContentView.Center;
			zoomPicture.AddSubview (image);
			zoomPicture.MaximumZoomScale = 3f;
			zoomPicture.MinimumZoomScale = 1f;
			zoomPicture.ZoomScale = 1f;
			zoomPicture.ClipsToBounds = true;
			zoomPicture.ViewForZoomingInScrollView += (UIScrollView sv) => { return image; };
			this.ContentView.AddSubview (zoomPicture);

			float ratio = this.zoomPicture.Bounds.Width / this.image.Image.Size.Width;

			this.image.Bounds = new RectangleF(0, 0, this.ContentView.Bounds.Width, this.image.Image.Size.Height * ratio);
			this.image.Center = new PointF (this.zoomPicture.Bounds.GetMidX(), this.zoomPicture.Bounds.GetMidY());
			this.zoomPicture.ContentSize = new SizeF (this.image.Bounds.Size); 

			// adjust the panning of the zoomed picture
			zoomPicture.DidZoom += (object sender, EventArgs e) => {
				float offsetX = (this.zoomPicture.Bounds.Size.Width > this.zoomPicture.ContentSize.Width) ? (this.zoomPicture.Bounds.Size.Width - this.zoomPicture.ContentSize.Width) * 0.5f : 0.0f;
				float offsetY = (this.zoomPicture.Bounds.Size.Height > this.zoomPicture.ContentSize.Height) ? (this.zoomPicture.Bounds.Size.Height - this.zoomPicture.ContentSize.Height) * 0.5f : 0.0f;
				this.image.Center = new PointF(this.zoomPicture.ContentSize.Width * 0.5f + offsetX, this.zoomPicture.ContentSize.Height * 0.5f + offsetY);
			};
		}
	}
}