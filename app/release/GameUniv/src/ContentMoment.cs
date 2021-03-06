﻿using UnityEngine;
using System.Collections;

namespace GameUniv {
	public class ContentMoment : Moment {

		private string content;

		public ContentMoment(string content) {
			this.content = content;
		}

		public override WWWForm ToWWWForm() {
			WWWForm form = new WWWForm();
			form.AddField("content", content);
			return form;
		}

		protected override string GetRoute() {
			return "/moments";
		}
	}
}