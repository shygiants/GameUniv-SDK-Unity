using System;
using UnityEngine;
using System.Collections;

namespace GameUniv {
	public class Request {

		public enum Method {
			GET,
			POST, 
			PUT, 
			DELETE
		};

		private HTTP.Request request;
		private Method method;
		private string url;
		private string route;
	
		public Request(Method method, string route) {
			this.method = method;
			this.route = route;
			url = Sdk.url + route;
			request = new HTTP.Request(GetMethodString(), url);
		}

		public Request(Method method, string route, WWWForm form) : this(method, route) {
			SetBody(form);
		}

		public void Send(Action<Hashtable> callback) {
			this.request.AddHeader("Authorization", LoginManager.GetInstance().GetAccessToken());

			this.request.Send((request) => {
				bool result = false;
				Hashtable body;
				try {
					body = (Hashtable)JSON.JsonDecode(request.response.Text, ref result);
				} catch (NullReferenceException e) {
					Debug.Log(e.ToString());
					return;
				}

				if (!result) {
					Debug.LogWarning("There is something wrong");
					return;
				}

				callback(body);
			});
		}

		public void SetBody(WWWForm form) {
			request = new HTTP.Request(GetMethodString(), url, form);
		}

		private string GetMethodString() {
			switch(method) {
			case Method.GET: return "get";
			case Method.POST: return "post";
			case Method.PUT: return "put";
			case Method.DELETE: return "delete";
			// TODO: Throw exception
			default: return null;
			}
		}
	}
}

