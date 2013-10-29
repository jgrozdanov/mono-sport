using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SportNet.Web.Models;
using SportNet.Web.Models.LiveScore;

namespace SportNet
{
	public class TodayTableSource : UITableViewSource
	{
		private LiveScoreViewModel items;
		private List<MatchModel> matches;
		private NSString cellId = (NSString)"livescorecell";

		public TodayTableSource (LiveScoreViewModel model)
		{
			this.items = model;
			matches = new List<MatchModel>();

			var tournaments = items.Tournaments;
			foreach (var tournament in tournaments) {
				var games = tournament.Matches;
				foreach (var game in games) {
					matches.Add (game);
				}
			}
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return matches.Count;
		}

		private void setCell(LiveScoreCell cell, NSIndexPath indexPath)
		{
			cell.SetLiveScoreCell (matches [indexPath.Row].Team1, matches [indexPath.Row].Team2, matches [indexPath.Row].Result, 
			                       matches [indexPath.Row].State, matches [indexPath.Row].MatchTime);
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
