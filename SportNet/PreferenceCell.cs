using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SportNet
{
	public class PreferenceCell : UICollectionViewCell
	{
		private UIImageView image;
		private UIView details;
		private UIImageView indicator;
		private UILabel category;

		public static NSString CellId = (NSString)"preferencecell";

		[Export ("initWithFrame:")]
		public PreferenceCell (RectangleF frame) : base(frame)
		{
			this.image = new UIImageView (new RectangleF (0, 0, 90, 90));
			this.image.ContentMode = UIViewContentMode.ScaleToFill;
			this.details = new UIView (new RectangleF (0, 68, 90, 22));
			this.details.BackgroundColor = UIColor.FromRGBA (0, 0, 0, 200); 

			this.indicator = new UIImageView (new RectangleF (70, 4, 15, 15));
			this.indicator.ContentMode = UIViewContentMode.Center;
			this.indicator.Image = UIImage.FromFile ("./Assets/plus.png");

			this.category = new UILabel (new RectangleF (5, 5, 60, 16));
			this.category.Text = "Football";
			this.category.TextColor = UIColor.White;
			this.category.Font = UIFont.FromName ("Helvetica", 10f);
			this.category.SizeToFit ();

			this.category.BackgroundColor = UIColor.Clear;

			this.details.AddSubview (category);
			this.details.AddSubview (indicator);

			this.ContentView.AddSubview (image);
			this.ContentView.AddSubview (details);
		}

		public void SetCellState(bool check)
		{
			if (check) {
				this.Details.BackgroundColor = UIColor.FromRGBA (255, 0, 0, 200);
				this.Indicator.Image = UIImage.FromFile ("./Assets/check.png");
			} 
			else {
				this.Details.BackgroundColor = UIColor.FromRGBA (0, 0, 0, 200);
				this.Indicator.Image = UIImage.FromFile ("./Assets/plus.png");
			}
		}

		public UIImageView Image 
		{
			get {
				return this.image;
			}
			set {
				this.image = value;
			}
		}

		public UIView Details
		{
			get {
				return this.details;
			}
		}

		public UIImageView Indicator 
		{
			get {
				return this.indicator;
			}
		}

		public string Category
		{
			get {
				return this.category.Text;
			}
			set {
				this.category.Text = value;
			}
		}
	}
}

