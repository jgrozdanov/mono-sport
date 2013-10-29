using System;

namespace SportNet
{
	public static class RequestConfig
	{
		public static string News() {

				if (AppDelegate.IsLoggedIn ()) 
					return "http://www.sport.net/api/View/News/{0}/{1}?user=" + AppDelegate.GetProfileId();
				else 
					return "http://www.sport.net/api/View/News/{0}/{1}";

		}

		public static string NewsPaged {
			get {
				if (AppDelegate.IsLoggedIn ())
					return "http://www.sport.net/api/List/News/{0}/{1}?user=" + AppDelegate.GetProfileId ();
				else
					return "http://www.sport.net/api/List/News/{0}/{1}";
			}
		}

		public static string Videos {
			get {
				if (AppDelegate.IsLoggedIn ())
					return "http://www.sport.net/api/View/Video/{0}/{1}?user=" + AppDelegate.GetProfileId ();
				else
					return "http://www.sport.net/api/View/Video/{0}/{1}";
			}
		}

		public static string VideosPaged {
			get {
				if (AppDelegate.IsLoggedIn ())
					return "http://www.sport.net/api/List/Video/{0}/{1}?user=" + AppDelegate.GetProfileId ();
				else
					return "http://www.sport.net/api/List/Video/{0}/{1}";
			}
		}

		public static string Pictures {
			get {
				if(AppDelegate.IsLoggedIn())
					return "http://www.sport.net/api/View/Pictures/{0}/{1}?user=" + AppDelegate.GetProfileId();
				else
					return "http://www.sport.net/api/View/Pictures/{0}/{1}";
			}
		}

		public static string PicturesPaged {
			get {
				if (AppDelegate.IsLoggedIn ())
					return "http://www.sport.net/api/List/Pictures/{0}/{1}?user=" + AppDelegate.GetProfileId ();
				else
					return "http://www.sport.net/api/List/Pictures/{0}/{1}";
			}
		}

		public static string Article = "http://www.sport.net/{0}";
		public static string Video = "http://www.sport.net/Video/{0}";
		public static string PicturesArticle = "http://www.sport.net/api/view/picturesarticle/{0}";
		public static string LiveScoreSports = "http://www.sport.net/api/view/getsports";
		public static string LiveScoreCategories = "http://www.sport.net/api/view/getcategories/{0}";
		public static string LiveScore = "http://www.sport.net/api/view/livescore/{0}/{1}?code=-1";
		public static string Login = "http://www.sport.net/api/content/login";
		public static string Facebook = "http://www.sport.net/api/content/LoginRegisterWithFacebook";
		public static string Google = "http://www.sport.net/api/content/LoginRegisterWithGoogle";
		public static string GoogleFetch = "https://www.googleapis.com/oauth2/v1/userinfo?access_token={0}";
		public static string Profile = "http://www.sport.net/api/content/profile/{0}";
		public static string MainCategories = "http://www.sport.net/api/content/MainCategories?user={0}";
		public static string SubCategories = "http://www.sport.net/api/content/GetCategories/{0}?user=" + AppDelegate.GetProfileId();
		public static string AddContent = "http://www.sport.net/api/content/AddContent?user=" + AppDelegate.GetProfileId();
	}
}

