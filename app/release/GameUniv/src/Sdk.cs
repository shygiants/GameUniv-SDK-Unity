using UnityEngine;
using System.Collections;
using System;

namespace GameUniv {
	public class Sdk {
		
		//"56483348e036805d66989c37"
		//"qaYa86jN6QcKM1WOVUbE"

		private static string apiEndPoint = "192.168.0.4";
		private static string port = "3000";
		public static string url = "http://" + apiEndPoint + ":" + port;
		
		private static Sdk singleton;
		private static bool initialized;

		private AndroidJavaObject mainActivity;
		private LoginManager loginManager;

		private Sdk(string gameId, string gameSecret) {
			initialized = true;

			loginManager = new LoginManager(gameId, gameSecret);

			AndroidJavaClass RESTAPI = new AndroidJavaClass("kr.ac.korea.ee.shygiants.gameunivlogin.RESTAPI");
			RESTAPI.CallStatic("init", url);

//			// Get main activity
//			AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
//			mainActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); 
		}

		public static void Init(string gameId, string gameSecret) {
			if (singleton != null) return;
			singleton = new Sdk(gameId, gameSecret);
		}

		public static bool IsInitialized() {
			return initialized;
		}
	}
}
