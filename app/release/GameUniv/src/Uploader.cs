using UnityEngine;
using System.Collections;
using System;

namespace GameUniv {
	public class Uploader {

		private static string accessToken;

		private static string GetUrl(string route) {
			return Sdk.url + route;
		}

		public static void Upload(ContentMoment moment) {
			WWWForm form = moment.ToWWWForm();

			HTTP.Request postRequest = new HTTP.Request("post", GetUrl("/moments"), form);
			postRequest.AddHeader("Authorization", accessToken);
			
			postRequest.Send((request) => {
				bool result = false;
				try {
					Hashtable thing = (Hashtable)JSON.JsonDecode(request.response.Text, ref result);
				} catch (NullReferenceException e) {
					Debug.Log(e.ToString());
					return;
				}
				
				if (!result) {
					Debug.LogWarning("There is something wrong");
					return;
				}
				Debug.Log("Moment uploaded");
			});
		}
	}
}
