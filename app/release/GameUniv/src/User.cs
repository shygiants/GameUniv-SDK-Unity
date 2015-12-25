using System;
using System.Collections;

namespace GameUniv {
	public class User {

		private string id;
		private string userName;
		private string email;

		public User (Hashtable hashTable) {
			id = (string)hashTable["_id"];
			userName = (string)hashTable["userName"];
			email = (string)hashTable["email"];
		}

		public string GetUserId() {
			return id;
		}

		public string GetUserName() {
			return userName;
		}

		public string GetEmail() {
			return email;
		}
	}
}

