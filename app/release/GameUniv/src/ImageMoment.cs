using UnityEngine;
using System.Collections;
using System;

namespace GameUniv {
	public class ImageMoment : Moment {

		private string content;
		private byte[] bytes;
		private WWW file;

		public ImageMoment(string screenshot) {
			string path = Application.persistentDataPath + "/" + screenshot;
			file = new WWW("file://" + path);
		}

		public override WWWForm ToWWWForm() {
			WWWForm form = new WWWForm();
			bytes = file.bytes;
			if (content != null)
				form.AddField("content", content);
			form.AddBinaryData("image", bytes, "image.png", "image/png");
			return form;
		}

		protected override string GetRoute() {
			return "/moments/images";
		}

		public WWW WaitUntilLoadImage() {
			return file;
		}
	}
}