using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;

namespace SportNet
{
	public class NewsCell : UITableViewCell
	{
		private UILabel heading;
		private UILabel category;
		private UIImageView image;


		public NewsCell (NSString cellId) : base(UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.None;

			heading = new UILabel ();
			heading.TextColor = UIColor.White;
			heading.Font = UIFont.FromName ("Helvetica-Bold", 16f);
			heading.BackgroundColor = UIColor.Clear;
			//heading.TextRectForBounds (new RectangleF (), 4);
			heading.Lines = 3;

			category = new UILabel ();
			category.TextColor = UIColor.Red;
			category.Font = UIFont.FromName ("Helvetica", 12f);
			category.BackgroundColor = UIColor.Clear;

			image = new UIImageView ();
			image.ContentMode = UIViewContentMode.ScaleAspectFill;
			image.ClipsToBounds = true;


			ContentView.Add (heading);
			ContentView.Add (category);
			ContentView.Add (image);

			
		}

		public void SetNewsCell(string heading, string category, string image)
		{
			this.heading.Text = heading;
			this.category.Text = category;
			this.image.Image = UIImage.FromFile (image);

		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			image.Frame = new RectangleF(18, 0, 100, 100);
			category.Frame = new RectangleF(128, 10, ContentView.Bounds.Width - 136, 12);
			heading.Frame = new RectangleF(128, 25, ContentView.Bounds.Width - 145, 16);
			heading.SizeToFit ();
			image.Frame = new RectangleF(18, 0, 100, 100);

		}
	}
}

