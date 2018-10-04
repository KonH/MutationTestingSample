using System;

namespace Library {
	public class AccessDeniedException : Exception { }

	public class Repository<T> {

		Auth Auth { get; }
		T Data { get; }

		public Repository(Auth auth, T data) {
			Auth = auth;
			Data = data;
		}

		public T GetData(string userName, string password) {
			if ( Auth.IsUserAllowed(userName, password) ) {
				return Data;
			}
			throw new AccessDeniedException();
		}
	}
}
