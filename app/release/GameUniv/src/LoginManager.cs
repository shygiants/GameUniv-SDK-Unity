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
		
		private Action<LoginResult> target;
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
		
		public void Login(Action<LoginResult> callback = null) {
			// TODO: Throw exception
			if (callback == null) return;
			target = callback;
			mainActivity.Call("attemptLogin", gameId, gameSecret, this);
		}
		
		// Callback function for java interface
		void onGettingAccessToken(string accessToken) {
			this.accessToken = accessToken;
			Request getUser = new Request(Request.Method.GET, "/users");
			getUser.Send((hashTable) => {
				LoginResult loginResult = new LoginResult();
				loginResult.SetAccessToken(accessToken);
				loginResult.SetUser(new User(hashTable));

				target(loginResult);
			});
		}

		public string GetAccessToken() {
			// TODO: If access token is null, throw exception
			return accessToken;
		}
	}
}
