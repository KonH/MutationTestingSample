namespace Library {
    public class Auth {
		string WantedName     { get; }
		string WantedPassword { get; }

		bool IsPublic => string.IsNullOrEmpty(WantedName) && string.IsNullOrEmpty(WantedPassword);

		public Auth(string wantedName, string wantedPassword) {
			WantedName     = wantedName;
			WantedPassword = wantedPassword;
		}

		public bool IsUserAllowed(string name, string password) {
			return IsPublic || ((name == WantedName) && (password == WantedPassword));
		}
	}
}
