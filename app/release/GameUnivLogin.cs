using UnityEngine;
using System.Collections;

public class GameUnivLogin : MonoBehaviour {

	private static string gameId = "56483348e036805d66989c37";
	private static string gameSecret = "qaYa86jN6QcKM1WOVUbE";

	private static GameUnivLogin singleton;

	private AndroidJavaObject activity;

	public static void AttemptLogin() {
		singleton = new GameUnivLogin();

		AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
		singleton.activity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); 
		singleton.activity.Call("attemptLogin", gameId, gameSecret);

		singleton.StartCoroutine(singleton.GetAccessToken());
	}

	private IEnumerator GetAccessToken() {
		string accessToken = null;
		while((accessToken = activity.Call<string>("getAccessToken")) == null) {
			yield return null;
		}
		
		Debug.Log("AccessToken: " + accessToken);
	}
}
