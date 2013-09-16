using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SportNet
{
	public class PicturesControllerCell : UITableViewCell
	{
		private UIImageView image;
		private UILabel heading;
		private UILabel category;
		private UIImageView photo;
		private UILabel number;

		public PicturesControllerCell (NSString cellId) : base(UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.None;

			heading = new UILabel ();
			heading.TextColor = UIColor.White;
			heading.Font = UIFont.FromName ("Helvetica-Bold", 14f);
			heading.BackgroundColor = UIColor.Clear;
			//heading.TextRectForBounds (new RectangleF (), 4);
			heading.Lines = 4;

			category = new UILabel ();
			category.TextColor = UIColor.Red;
			category.Font = UIFont.FromName ("Helvetica", 12f);
			category.BackgroundColor = UIColor.Clear;

			image = new UIImageView ();
			image.ContentMode = UIViewContentMode.ScaleAspectFill;
			image.ClipsToBounds = true;

			number = new UILabel ();
			number.TextColor = UIColor.White;
			number.Font = UIFont.FromName ("Helvetica", 8f);
			number.TextAlignment = UITextAlignment.Center;
			number.BackgroundColor = UIColor.Clear;

			photo = new UIImageView ();
			photo.ContentMode = UIViewContentMode.ScaleAspectFill;
			photo.ClipsToBounds = true;


			ContentView.Add (heading);
			ContentView.Add (category);
			ContentView.Add (image);
			ContentView.Add (photo);
			ContentView.Add (number);
		}
		public void SetPictureCell(string heading, string category, string imageSource, string photo, int picturesCount)
		{
			this.heading.Text = heading;
			this.category.Text = category;
			this.image.Image = UIImage.FromFile (imageSource);
			this.number.Text = string.Format("{0}", picturesCount);
			this.photo.Image = UIImage.FromFile (photo);
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			image.Frame = new RectangleF(18, 0, 100, 100);
			category.Frame = new RectangleF(128, 10, ContentView.Bounds.Width - 136, 12);
			heading.Frame = new RectangleF(128, 25, ContentView.Bounds.Width - 145, 16);
			heading.SizeToFit ();
			photo.Frame = new RectangleF(97, 0, 21, 21);
			number.Frame = new RectangleF(97, 1, 21, 8);

		}
	}
}

