using System;
using System.Collections;

namespace GameUniv {
	public class LoginResult {
		private string accessToken;
		private User user;

		public void SetAccessToken(string accessToken) {
			this.accessToken = accessToken;
		}

		public void SetUser(User user) {
			this.user = user;
		}

		public string GetAccessToken() {
			return accessToken;
		}

		public User GetUser() {
			return user;
		}
	}
}

