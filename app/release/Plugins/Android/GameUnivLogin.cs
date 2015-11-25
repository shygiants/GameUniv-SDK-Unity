using UnityEngine;
using System.Collections;

public class GameUnivLogin : AndroidJavaProxy {

	public interface AccessTokenCallback {
		void OnGettingAccessToken(string accessToken);
	}

	public GameUnivLogin() : base("kr.ac.korea.ee.shygiants.gameunivlogin.AccessTokenCallback") {}
	
//"56483348e036805d66989c37"
//"qaYa86jN6QcKM1WOVUbE"

	private static GameUnivLogin singleton;

	private AccessTokenCallback callback;
	private string accessToken;

	public static void AttemptLogin(string gameId, string gameSecret) {
		if (singleton != null) return;
		singleton = new GameUnivLogin();

		AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
		AndroidJavaObject activity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); 
		activity.Call("attemptLogin", gameId, gameSecret, singleton);
	}

	void onGettingAccessToken(string accessToken) {
		this.accessToken = accessToken;
		if (callback != null)
			callback.OnGettingAccessToken(accessToken);
	}

	public static void GetAccessToken(AccessTokenCallback callback) {
		if (singleton == null) return;

		string accessToken = singleton.accessToken;
		if (accessToken != null)
			callback.OnGettingAccessToken(accessToken);
		else
			singleton.callback = callback;
	}
}
