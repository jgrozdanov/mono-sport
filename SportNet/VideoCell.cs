using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SportNet
{
	public class VideoCell : UITableViewCell
	{
		private UIImageView image;
		private UIImageView play;
		private UILabel heading;
		private UILabel category;
		private UIView headingView;

		public VideoCell (NSString cellId) : base(UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.None;

			heading = new UILabel ();
			heading.TextColor = UIColor.White;
			heading.Font = UIFont.FromName ("Helvetica-Bold", 14f);
			heading.BackgroundColor = UIColor.Clear;
			heading.Lines = 2;

			category = new UILabel ();
			category.TextColor = UIColor.Red;
			category.Font = UIFont.FromName ("Helvetica", 12f);
			category.BackgroundColor = UIColor.Clear;

			image = new UIImageView ();
			image.ContentMode = UIViewContentMode.ScaleAspectFill;
			image.ClipsToBounds = true;

			play = new UIImageView ();

			headingView = new UIView ();
			headingView.BackgroundColor = UIColor.FromRGBA (0, 0, 0, 120);
			headingView.AddSubviews (new UIView[] { play, heading, category });

			ContentView.Add (image);
			ContentView.Add (headingView);
		}

		public void SetVideoCell(string heading, string category, string imageSource)
		{
			this.heading.Text = heading;
			this.category.Text = category;
			AppDelegate.MakeImageFromURL (this.image, imageSource);
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			image.Frame = new RectangleF (18, 10, ContentView.Bounds.Width - 36, 161);
			headingView.Frame = new RectangleF (18, 101, ContentView.Bounds.Width - 36, 70);
			play.Frame = new RectangleF (7, 15, 25, 25);
			play.Image = UIImage.FromFile ("./Assets/play.png");
			category.Frame = new RectangleF(38, 50, ContentView.Bounds.Width - 66, 12);
			heading.Frame = new RectangleF (38, 13, ContentView.Bounds.Width - 76, 18);
			heading.SizeToFit ();
		}
	}
}

