using UnityEngine;
using System;
using System.Collections;

namespace GameUniv {
	public abstract class Moment {
		public abstract WWWForm ToWWWForm();
		protected abstract string GetRoute();

		protected Request request;

		public void Save(Action<string> callback) {
			request = new Request(Request.Method.POST, GetRoute(), ToWWWForm());
			request.Send((hashTable) => {
				callback((string)hashTable["moment_id"]);
			});
		}
	}
}

