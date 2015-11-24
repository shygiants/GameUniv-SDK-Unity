using UnityEngine;
using System.Collections;

public class GameUnivLogin : AndroidJavaProxy {

//	class AccessTokenCallback : AndroidJavaProxy {
//		public AccessTokenCallback() : base("kr.ac.korea.ee.shygiants.gameunivlogin.AccessTokenCallback") {}
//
//		void onGettingAccessToken(string accessToken) {
//
//		}
//	}

	public interface AccessTokenCallback {
		void OnGettingAccessToken(string accessToken);
	}

	public GameUnivLogin() : base("kr.ac.korea.ee.shygiants.gameunivlogin.AccessTokenCallback") {}

	private static string gameId = "56483348e036805d66989c37";
	private static string gameSecret = "qaYa86jN6QcKM1WOVUbE";

	private static GameUnivLogin singleton;

	private AccessTokenCallback callback;

	private AndroidJavaObject activity;

	public static void AttemptLogin(AccessTokenCallback callback) {
		singleton = new GameUnivLogin();

		AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
		singleton.activity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); 
		singleton.activity.Call("attemptLogin", gameId, gameSecret, singleton);
		singleton.callback = callback;
	}

	void onGettingAccessToken(string accessToken) {
		callback.OnGettingAccessToken(accessToken);
	}
}
