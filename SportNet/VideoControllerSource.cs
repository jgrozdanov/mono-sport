using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SportNet
{
	public class VideoControllerSource : UITableViewSource
	{
		private NewsCellModel[] items;
		private NSString cellId = (NSString)"videocell";

		public VideoControllerSource (NewsCellModel[] items)
		{
			this.items = items;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return items.Length;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellId) as VideoCell;
			if (cell == null) {
				cell = new VideoCell (cellId);
			}
			cell.SetVideoCell (items [indexPath.Row].Heading, items [indexPath.Row].Category, items [indexPath.Row].ImageSource);
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow (indexPath, true);
		}

		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 171f;
		}
	}
}

