using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SportNet
{
	public class TodayTableSource : UITableViewSource
	{
		private LiveScoreCellModel[] items;
		private NSString cellId = (NSString)"livescorecell";
		public TodayTableSource (LiveScoreCellModel[] events)
		{
			this.items = events;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return items.Length;
		}

		//---------------------------------------------------------------------------------------------

		private void setCell(LiveScoreCell cell, NSIndexPath indexPath)
		{
//			cell.TextLabel.TextColor = UIColor.White;
//			cell.ContentView.BackgroundColor = UIColor.FromRGB (26, 26, 26);
//			cell.TextLabel.BackgroundColor = UIColor.FromRGB (26, 26, 26);
//			cell.AccessoryView.BackgroundColor = UIColor.FromRGB (26, 26, 26);
			cell.SetLiveScoreCell (items [indexPath.Row].TeamOne, items [indexPath.Row].TeamTwo, items [indexPath.Row].Result, 
			                       items [indexPath.Row].LoaderSource,items [indexPath.Row].TimeIndicator,items [indexPath.Row].StartTime);
		}

		public virtual UITableViewCellSeparatorStyle SeparatorStyle { get; set; }

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			LiveScoreCell cell = tableView.DequeueReusableCell ("livescorecell") as LiveScoreCell;
			if (cell == null) {
				cell = new LiveScoreCell (cellId);
			};
			setCell (cell, indexPath);
			return cell;


		
		}



	}
}
