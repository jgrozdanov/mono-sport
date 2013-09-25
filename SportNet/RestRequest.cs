using Newtonsoft.Json;
using System;
using System.Net;

namespace SportNet
{
	public class RequestEndedArgs : EventArgs
	{
		public string Result { get; set; }
	}

	public class RestRequest
	{
		public delegate void RequestFinish(object sender, RequestEndedArgs e);
		public event RequestFinish RequestFinished;

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
			if (RequestFinished != null) {
				RequestFinished (this, new RequestEndedArgs { Result = e.Result });
			}
		}

		void downloadStringCompleted (object sender, DownloadStringCompletedEventArgs e)
		{
			if (RequestFinished != null) {
				RequestFinished (this, new RequestEndedArgs { Result = e.Result });
			}
		}
	}
}

