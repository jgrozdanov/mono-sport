using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace SportNet
{
	public class MenuControllerSource : UITableViewSource
	{
		private string[] categories;
		private NSString cellid = (NSString)"category";

		public MenuControllerSource (string[] categories)
		{
			this.categories = categories;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return categories.Length;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellid);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellid);
			}
			cell.BackgroundColor = UIColor.Black;
			cell.ContentView.BackgroundColor = UIColor.Black;
			cell.TextLabel.BackgroundColor = UIColor.Clear;
			cell.TextLabel.Text = categories [indexPath.Row];
			cell.TextLabel.Font = UIFont.FromName ("Helvetica-Bold", 17f);
			cell.TextLabel.TextColor = UIColor.FromRGB (102, 102, 102);
			cell.TextLabel.Frame = new RectangleF (60, 0, 100, 20);
			cell.SelectionStyle = UITableViewCellSelectionStyle.None;
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			tableView.CellAt (indexPath).TextLabel.TextColor = UIColor.White;
			tableView.DeselectRow (indexPath, true);
		}

		public override void RowDeselected (UITableView tableView, NSIndexPath indexPath)
		{
			tableView.CellAt(indexPath).TextLabel.TextColor = UIColor.FromRGB (102, 102, 102);
		}

		public override int IndentationLevel (UITableView tableView, NSIndexPath indexPath)
		{
			return 2;
		}
	}
}

