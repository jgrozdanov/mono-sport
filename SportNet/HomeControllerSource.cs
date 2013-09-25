using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SportNet
{
	public class HomeControllerSource : UITableViewSource
	{
		private NewsCellModel[] featured;
		private PreferenceModel[] items;
		private NSString cellId = (NSString)"homecell";
		private NSString featuredCellId = (NSString)"featuredcell";

		public HomeControllerSource (NewsCellModel[] feat, PreferenceModel[] cats)
		{
			featured = feat;
			items = cats;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return items.Length + 1;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			if (indexPath.Row != 0) {
				var cell = tableView.DequeueReusableCell (cellId);
				if (cell == null) {
					cell = new UITableViewCell (UITableViewCellStyle.Default, cellId);
				}
				cell.SelectionStyle = UITableViewCellSelectionStyle.None;
				cell.TextLabel.Text = items [indexPath.Row - 1].Title;
				cell.TextLabel.Font = UIFont.FromName ("Helvetica-Bold", 14f);
				cell.TextLabel.TextColor = UIColor.White;
				cell.TextLabel.BackgroundColor = UIColor.Clear;
				cell.ContentView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("./Assets/cell.png"));
			
				return cell;
			} 
			else {
				var cell = tableView.DequeueReusableCell(featuredCellId) as FeaturedCell;
				if (cell == null) {
					cell = new FeaturedCell (featuredCellId);
				}
				cell.SetFeaturedCell (featured);
				cell.ContentView.BackgroundColor = UIColor.FromRGB (26, 26, 26);
				return cell;
			}
		}

		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			if (indexPath.Row == 0) {
				return 300;
			} else {
				return 44;
			}
		}
	}
}

