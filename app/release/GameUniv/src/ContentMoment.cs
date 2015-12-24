using UnityEngine;
using System.Collections;

namespace GameUniv {
	public class ContentMoment {

		private string content;

		public ContentMoment(string content) {
			this.content = content;
		}

		public WWWForm ToWWWForm() {
			WWWForm form = new WWWForm();
			form.AddField("content", content);
			return form;
		}
	}
}