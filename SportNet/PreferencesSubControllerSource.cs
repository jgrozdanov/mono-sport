using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SportNet
{
	public class PreferencesSubControllerSource : UITableViewSource
	{
		private PreferenceModel[] items;
		private NSString cellId = (NSString)"leaguecell";

		public PreferencesSubControllerSource (PreferenceModel[] items)
		{
			this.items = items;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return items.Length;
		}

		private void setCell(UITableViewCell cell, NSIndexPath indexPath)
		{
			if (items[indexPath.Row].Selected) {
				cell.AccessoryView = new UIImageView (new RectangleF (0, 0, 35, cell.Bounds.Height - 1)) 
					{ Image = UIImage.FromFile ("./Assets/checkred.png"), ContentMode = UIViewContentMode.Center };

				cell.AccessoryView.BackgroundColor = UIColor.FromRGB (242, 242, 242);
				cell.TextLabel.TextColor = UIColor.FromRGB (255, 0, 0);
				cell.ContentView.BackgroundColor = UIColor.FromRGB (242, 242, 242);
				cell.TextLabel.BackgroundColor = UIColor.FromRGB (242, 242, 242);
			} 
			else {
				if (items [indexPath.Row].HasChild) {
					cell.AccessoryView = new UIImageView (new RectangleF (0, 0, 35, cell.Bounds.Height - 1))
						{ Image = UIImage.FromFile ("./Assets/disclosure.png"), ContentMode = UIViewContentMode.Center };
				} 
				else {
					cell.AccessoryView = new UIImageView (new RectangleF (0, 0, 35, cell.Bounds.Height - 1))
					{ Image = UIImage.FromFile ("./Assets/pluswhite.png"), ContentMode = UIViewContentMode.Center };
				}

				cell.TextLabel.TextColor = UIColor.White;
				cell.ContentView.BackgroundColor = UIColor.FromRGB (51, 51, 51);
				cell.TextLabel.BackgroundColor = UIColor.FromRGB (51, 51, 51);
				cell.AccessoryView.BackgroundColor = UIColor.FromRGB (51, 51, 51);
			}
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellId);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellId);
			}

			cell.TextLabel.Text = items [indexPath.Row].Title;
			cell.SelectionStyle = UITableViewCellSelectionStyle.None;
			cell.TextLabel.Font = UIFont.FromName ("Helvetica-Bold", 14f);

			setCell (cell, indexPath);

			if (items [indexPath.Row].Selected) {
				// i think this doesnt call RowSelected so we're cool
				tableView.SelectRow (indexPath, false, UITableViewScrollPosition.None);	
			}

			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.CellAt (indexPath);

			// change the selection in the model
			if (indexPath.Row != 0) {
				items [indexPath.Row].Selected = items [indexPath.Row].Selected ? false : true;
				setCell (cell, indexPath);
			} 
			else {
				// select all
				for (int i = 0; i < items.Length; i++) {
					items [i].Selected = true;
				}
				tableView.ReloadData ();
			}
		}

		public override void RowDeselected (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.CellAt (indexPath);
			
			// change the selection in the model
			if (indexPath.Row != 0) {
				items [indexPath.Row].Selected = items [indexPath.Row].Selected ? false : true;
				setCell (cell, indexPath);
			} 
			else {
				// select all
				for (int i = 0; i < items.Length; i++) {
					items [i].Selected = false;
				}
				tableView.ReloadData ();
			}
		}
	}
}

