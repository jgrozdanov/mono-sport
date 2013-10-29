using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace SportNet
{
	public class NewsCellNoPic : UITableViewCell
	{
		private UILabel heading;
		private UILabel category;

		public NewsCellNoPic (NSString cellId) : base(UITableViewCellStyle.Default, cellId)
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

			ContentView.Add (heading);
			ContentView.Add (category);
		}

		public void SetNewsCellNoPic(string heading, string category)
		{
			this.heading.Text = heading;
			this.category.Text = category;
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			this.category.Frame = new RectangleF(20, 10, ContentView.Bounds.Width - 136, 12);
			this.heading.Frame = new RectangleF(20, 25, ContentView.Bounds.Width - 40, 16);
			this.heading.SizeToFit ();
		}
	}
}

