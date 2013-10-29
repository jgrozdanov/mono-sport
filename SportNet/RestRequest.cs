using Newtonsoft.Json;
using System;
using System.Net;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SportNet
{
	public class RequestEndedArgs : EventArgs
	{
		public string Result { get; set; }
	}

	public class RestRequest : NSObject
	{
		public delegate void RequestFinish(object sender, RequestEndedArgs e);
		public event RequestFinish RequestFinished;

		public delegate void RequestFail (object sender, EventArgs e);
		public event RequestFail RequestFailed;

		public RestRequest ()
		{
		}

		public void Send(string url, string verb, object obj)
		{
			var webClient = new WebClient ();
			webClient.Headers [HttpRequestHeader.ContentType] = "application/json";
			webClient.UploadStringCompleted += this.uploadStringCompleted;

			var data = JsonConvert.SerializeObject (obj, Formatting.None);
			webClient.UploadStringAsync (new Uri(url), verb, data);
		}

		public void Send(string url, string verb)
		{
			var webClient = new WebClient ();
			webClient.DownloadStringCompleted += this.downloadStringCompleted;
			webClient.DownloadStringAsync (new Uri (url), verb);
		}

		void uploadStringCompleted (object sender, UploadStringCompletedEventArgs e)
		{
			try {
				if (RequestFinished != null) {
					RequestFinished (this, new RequestEndedArgs { Result = e.Result });
				}
			}
			catch(Exception ex) {
				if (RequestFailed != null) {
					RequestFailed (this, null);
				}
				InvokeOnMainThread (delegate {
					new UIAlertView ("Sorry", ex.Message, null, "OK", null).Show();
				});
			}
		}

		void downloadStringCompleted (object sender, DownloadStringCompletedEventArgs e)
		{
			try {
				if (RequestFinished != null) {
					RequestFinished (this, new RequestEndedArgs { Result = e.Result });
				}
			}
			catch(Exception ex) {
				if (RequestFailed != null) {
					RequestFailed (this, null);
				}
				InvokeOnMainThread (delegate {
					new UIAlertView ("Sorry", ex.Message, null, "OK", null).Show();
				});
			}
		}
	}
}

