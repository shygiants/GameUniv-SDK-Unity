using UnityEngine;
using System.Collections;
using System;

namespace GameUniv {
	public class LoginManager : AndroidJavaProxy {
		
		//"56483348e036805d66989c37"
		//"qaYa86jN6QcKM1WOVUbE"
		
		private static LoginManager singleton;

		private string gameId;
		private string gameSecret;

		private AndroidJavaObject mainActivity;
		
		private Action<string> accessTokenTarget;
		private string accessToken;

		public LoginManager(string gameId, string gameSecret) : base("kr.ac.korea.ee.shygiants.gameunivlogin.AccessTokenCallback") {
			if (Sdk.IsInitialized() && singleton == null) {
				singleton = this;
				this.gameId = gameId;
				this.gameSecret = gameSecret;

				// Get main activity
				AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
				mainActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); 
			}
		}

		public static LoginManager GetInstance() {
			return singleton;
		}
		
		public void Login(Action<string> callback = null) {
			accessTokenTarget = callback;
			mainActivity.Call("attemptLogin", gameId, gameSecret, this);
		}
		
		// Callback function for java interface
		void onGettingAccessToken(string accessToken) {
			this.accessToken = accessToken;
			if (accessTokenTarget != null)
				accessTokenTarget(accessToken);
		}
		
		public static void GetAccessToken(Action<string> callback) {
			if (singleton == null) return;
			
			string accessToken = singleton.accessToken;
			if (accessToken != null)
				callback(accessToken);
			else
				singleton.accessTokenTarget = callback;
		}
	}
}
