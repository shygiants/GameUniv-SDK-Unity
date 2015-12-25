using UnityEngine;
using System.Collections;

namespace GameUniv {
	public class ScoreMoment : Moment {

		private string score;

		public ScoreMoment(string score) {
			this.score = score;
		}

		public override WWWForm ToWWWForm() {
			WWWForm form = new WWWForm();
			form.AddField("score", score);
			return form;
		}

		protected override string GetRoute() {
			return "/moments/score";
		}
	}
}