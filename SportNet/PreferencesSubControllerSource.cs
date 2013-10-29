using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Newtonsoft.Json;
using SportNet.Web.Models;

namespace SportNet
{
	public class PreferencesSubControllerSource : UITableViewSource
	{
		private NSString cellId = (NSString)"leaguecell";

		public override int RowsInSection (UITableView tableview, int section)
		{
			return AppDelegate.SubCategories.Categories.Count;
		}

		private void setCell(UITableViewCell cell, NSIndexPath indexPath)
		{
			if (AppDelegate.SubCategories.Categories[indexPath.Row].Checked) {
				cell.AccessoryView = new UIImageView (new RectangleF (0, 0, 35, cell.Bounds.Height - 1)) 
					{ Image = UIImage.FromFile ("./Assets/checkred.png"), ContentMode = UIViewContentMode.Center };

				cell.AccessoryView.BackgroundColor = UIColor.FromRGB (242, 242, 242);
				cell.TextLabel.TextColor = UIColor.FromRGB (255, 0, 0);
				cell.ContentView.BackgroundColor = UIColor.FromRGB (242, 242, 242);
				cell.TextLabel.BackgroundColor = UIColor.FromRGB (242, 242, 242);
				cell.BackgroundColor = UIColor.FromRGB (242, 242, 242);
			} 
			else {
				if (AppDelegate.SubCategories.Categories[indexPath.Row].HasChildren) {
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
				cell.BackgroundColor = UIColor.FromRGB (51, 51, 51);
			}
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellId);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellId);
			}

			cell.TextLabel.Text = AppDelegate.SubCategories.Categories [indexPath.Row].Name;
			cell.SelectionStyle = UITableViewCellSelectionStyle.None;
			cell.TextLabel.Font = UIFont.FromName ("Helvetica-Bold", 14f);

			setCell (cell, indexPath);

			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.CellAt (indexPath);

			if (indexPath.Row != 0) {
				if (AppDelegate.SubCategories.Categories [indexPath.Row].HasChildren) {
					UIStoryboard board = UIStoryboard.FromName ("MainStoryboard", null);
					var prefs = (PreferencesSubController)board.InstantiateViewController ("preferencessub");
					prefs.CategoryId = AppDelegate.SubCategories.Categories [indexPath.Row].Id;
					prefs.ParentChecked = AppDelegate.SubCategories.Categories [indexPath.Row].Checked;
					prefs.Title = AppDelegate.SubCategories.Categories [indexPath.Row].Name;
					((UINavigationController)UIApplication.SharedApplication.KeyWindow.RootViewController).PushViewController (prefs, true);
				} 
				else {
					AppDelegate.SubCategories.Categories [indexPath.Row].Checked = !AppDelegate.SubCategories.Categories [indexPath.Row].Checked;
					setCell (cell, indexPath);
					var request = new RestRequest ();
					request.RequestFailed += (object sender, EventArgs e) => {
						AppDelegate.SubCategories.Categories [indexPath.Row].Checked = !AppDelegate.SubCategories.Categories [indexPath.Row].Checked;
						setCell (cell, indexPath);
					};
					request.Send (RequestConfig.AddContent, "POST", AppDelegate.SubCategories.Categories [indexPath.Row]);
				}
			} 
			else {
				AddContentItem model = AppDelegate.MainCategories.Categories.Find (i => i.Id == AppDelegate.SubCategories.ParentCategory.Id);
				if (model == null) {
					var request2 = new RestRequest ();
					request2.RequestFinished += (object sender, RequestEndedArgs e) => {
						InvokeOnMainThread(delegate() {
							var data = (AddContentModel)JsonConvert.DeserializeObject(e.Result, typeof(AddContentModel));
							model = data.Categories.Find(i => i.Id == AppDelegate.SubCategories.ParentCategory.Id);
							model.Checked = !model.Checked;
							AppDelegate.SubCategories.Categories [0].Checked = !AppDelegate.SubCategories.Categories [0].Checked;
							setCell (cell, indexPath);

							var request = new RestRequest ();
							request.RequestFailed += (object snder, EventArgs ev) => {
								InvokeOnMainThread(delegate() {
									model.Checked = !model.Checked;
									AppDelegate.SubCategories.Categories [0].Checked = !AppDelegate.SubCategories.Categories [0].Checked;
									setCell (cell, indexPath);
								});
							};
							request.Send (RequestConfig.AddContent, "POST", model);
						});
					};
					request2.Send (string.Format (RequestConfig.SubCategories, AppDelegate.SubCategories.ParentCategory.fkParent), "GET");
				}
				else {
					model.Checked = !model.Checked;
					AppDelegate.SubCategories.Categories [0].Checked = !AppDelegate.SubCategories.Categories [0].Checked;
					setCell (cell, indexPath);
					var request = new RestRequest ();
					request.RequestFailed += (object snder, EventArgs ev) => {
						InvokeOnMainThread(delegate() {
							model.Checked = !model.Checked;
							AppDelegate.SubCategories.Categories [0].Checked = !AppDelegate.SubCategories.Categories [0].Checked;
							setCell (cell, indexPath);
						});
					};
					request.Send (RequestConfig.AddContent, "POST", model);
				}
			}
		}
	}
}

