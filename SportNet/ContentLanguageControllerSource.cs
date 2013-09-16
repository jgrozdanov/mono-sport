using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SportNet
{
	public class ContentLanguageControllerSource : UITableViewSource
	{
		private PreferenceModel[] items;
		private NSString cellId = (NSString)"languagecell";
		private UIImageView delete = new UIImageView (new RectangleF (0, 0, 22, 22))
		{ Image = UIImage.FromFile("./Assets/delete.png"),ContentMode = UIViewContentMode.ScaleToFill };

		public ContentLanguageControllerSource (PreferenceModel[] items)
		{
			this.items = items;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return items.Length;
		}


		//---------------------------------------------------------------------------------------------

		private void setCell(UITableViewCell cell, NSIndexPath indexPath)
		{


			cell.AccessoryView = new UIImageView (new RectangleF (0, 0, 35, cell.Bounds.Height)) 
			{ Image = delete.Image, ContentMode = UIViewContentMode.Left };


			cell.TextLabel.TextColor = UIColor.White;
			cell.ContentView.BackgroundColor = UIColor.FromRGB (26, 26, 26);
			cell.TextLabel.BackgroundColor = UIColor.FromRGB (26, 26, 26);
			cell.AccessoryView.BackgroundColor = UIColor.FromRGB (26, 26, 26);

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
