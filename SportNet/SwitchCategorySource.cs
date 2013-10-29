using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.Collections.Generic;
using SportNet.Web.Models;
using SportNet.Web.Models.LiveScore;
using Newtonsoft.Json;

namespace SportNet
{
	public class SwitchCategorySource : UITableViewSource
	{
		private List<LiveScoreSportModel> items;
		private List<LiveScoreCategoryModel> categories;
		private NSString cellId = (NSString)"switchcell";
		private bool root;
		private int currentSport;
		private UITableView target;

		public SwitchCategorySource (List<LiveScoreSportModel> items, UITableView target)
		{
			this.items = items;
			this.target = target;
			root = true;
		}

		public SwitchCategorySource (List<LiveScoreCategoryModel> items, UITableView target, int sport)
		{
			this.categories = items;
			this.target = target;
			root = false;
			currentSport = sport;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellId, indexPath);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellId);
			}

			if (root) {
				cell.TextLabel.Text = items [indexPath.Row].Name;
			} 
			else {
				cell.TextLabel.Text = categories [indexPath.Row].Name;
			}

			cell.TextLabel.Font = UIFont.FromName ("Helvetica", 12f);
			return cell;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			if (root) {
				return items.Count;
			} 
			else {
				return categories.Count;
			}
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var request = new RestRequest ();
			var tab = (MainTabController)UIApplication.SharedApplication.Delegate.Window.RootViewController;

			if (indexPath.Row == 0 && !root) {
				request.RequestFinished += (object sender, RequestEndedArgs e) => {
					InvokeOnMainThread(delegate {
						var data = (List<LiveScoreSportModel>)JsonConvert.DeserializeObject(e.Result, typeof(List<LiveScoreSportModel>));
						tableView.Source = new SwitchCategorySource(data, target);
						tableView.ReloadData();
					});
				};
				request.Send (RequestConfig.LiveScoreSports, "GET");

				var request2 = new RestRequest ();
				request2.RequestFinished += (object sender, RequestEndedArgs e) => {
					InvokeOnMainThread(delegate {
						var data = (LiveScoreViewModel)JsonConvert.DeserializeObject(e.Result, typeof(LiveScoreViewModel));
						this.target.Source = new TodayTableSource(data);
						this.target.ReloadData();
					});
				};
				request2.Send (string.Format (RequestConfig.LiveScore, categories [indexPath.Row].Id, 0), "GET");
				//tab.LiveScore.SportToday.Text = "All Sports";
			} 
			else {
				request.RequestFinished += (object sender, RequestEndedArgs e) => {
					InvokeOnMainThread(delegate {
						var data = (List<LiveScoreCategoryModel>)JsonConvert.DeserializeObject(e.Result, typeof(List<LiveScoreCategoryModel>));
						data.Insert(0, new LiveScoreCategoryModel { Name = "Back" });
						tableView.Source = new SwitchCategorySource(data, target, currentSport);
						tableView.ReloadData();
					});
				};

				var request2 = new RestRequest ();
				request2.RequestFinished += (object sender, RequestEndedArgs e) => {
					InvokeOnMainThread(delegate {
						var data = (LiveScoreViewModel)JsonConvert.DeserializeObject(e.Result, typeof(LiveScoreViewModel));
						this.target.Source = new TodayTableSource(data);
						this.target.ReloadData();
					});
				};

				if (root) {
					request.Send (string.Format (RequestConfig.LiveScoreCategories, items [indexPath.Row].Id), "GET");
					request2.Send (string.Format (RequestConfig.LiveScore, items[indexPath.Row].Id, 0), "GET");
					//tab.LiveScore.SportToday.Text = items [indexPath.Row].Name;
				} 
				else {
					request2.Send (string.Format (RequestConfig.LiveScore, currentSport, categories [indexPath.Row].Id), "GET");
				}
			}
		}
	}
}

