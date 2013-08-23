using System;

namespace SportNet
{
	public class PreferenceModel
	{
		public PreferenceModel ()
		{
		}

		public string Title { get; set; }
		public bool Selected { get; set; }
		public bool HasChild { get; set; }
	}
}

