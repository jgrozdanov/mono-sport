using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SportNet
{
	public class PicturesFeaturedCell : UITableViewCell
	{
		private UIImageView image;
		private UILabel heading;
		private UILabel category;
		private UIImageView photo;
		private UILabel number;
		private UIImageView shadow;


		public PicturesFeaturedCell (NSString cellId) : base(UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.None;

			heading = new UILabel ();
			heading.TextColor = UIColor.White;
			heading.Font = UIFont.FromName ("Helvetica-Bold", 17f);
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

			photo = new UIImageView ();
			photo.ContentMode = UIViewContentMode.ScaleAspectFill;
			photo.ClipsToBounds = true;

			shadow = new UIImageView ();
			shadow.BackgroundColor = UIColor.FromRGBA (0, 0, 0, 180);

			number = new UILabel ();
			number.TextColor = UIColor.White;
			number.Font = UIFont.FromName ("Helvetica-Bold", 14f);
			number.TextAlignment = UITextAlignment.Center;
			number.BackgroundColor = UIColor.Clear;

			ContentView.Add (image);
			ContentView.Add (shadow);
			ContentView.Add (heading);
			ContentView.Add (category);
			ContentView.Add (photo);
			ContentView.Add (number);

		}
		public void SetPicturesFeaturedCell(string heading, string category, string imageSource, string photo, int number)
		{
			this.heading.Text = heading;
			this.category.Text = category;
			this.image.Image = UIImage.FromFile (imageSource);
			this.photo.Image = UIImage.FromFile (photo);
			this.number.Text = string.Format("{0}", number);
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			image.Frame = new RectangleF (18, 10, ContentView.Bounds.Width - 36, ContentView.Bounds.Height - 20);
			shadow.Frame = new RectangleF (18, ContentView.Bounds.Height - 100, ContentView.Bounds.Width - 36 ,90);
			category.Frame = new RectangleF(28, ContentView.Bounds.Height - 95, ContentView.Bounds.Width - 56, 12);
			heading.Frame = new RectangleF(28, ContentView.Bounds.Height - 85, ContentView.Bounds.Width - 56, 18);
			heading.SizeToFit ();
			photo.Frame = new RectangleF(ContentView.Bounds.Width - 58, 10, 40, 40);
			number.Frame = new RectangleF(ContentView.Bounds.Width - 58, 12, 40, 14);
		}
	}
}


