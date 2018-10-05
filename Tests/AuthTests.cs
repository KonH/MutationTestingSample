using Xunit;
using Library;

namespace Tests {
	public class AuthTests {
		const string ValidName = "userName";
		const string ValidPassword = "passwd";

		[Fact]
		void IsAuthorizedUserGetsData() {
			var repo = new Repository<string>(new Auth(ValidName, ValidPassword), "secret");
			var data = repo.GetData(ValidName, ValidPassword);
			Assert.Equal("secret", data);
		}

		[Fact]
		void IsUnauthorizedUserGetsException() {
			var repo = new Repository<string>(new Auth(ValidName, ValidPassword), "secret");
			Assert.Throws<AccessDeniedException>(() => repo.GetData("AnotherUser", "AnotherPassword"));
		}

		[Fact]
		void IsUserWithoutCorrectPasswordGetsException() {
			var repo = new Repository<string>(new Auth(ValidName, ValidPassword), "secret");
			Assert.Throws<AccessDeniedException>(() => repo.GetData(ValidName, "AnotherPassword"));
		}

		[Fact]
		void IsUserWithoutCorrectNameGetsException() {
			var repo = new Repository<string>(new Auth(ValidName, ValidPassword), "secret");
			Assert.Throws<AccessDeniedException>(() => repo.GetData("AnotherUser", ValidPassword));
		}

		[Fact]
		void IsPublicAllowedForEveryone() {
			var repo = new Repository<string>(new Auth(string.Empty, string.Empty), "secret");
			var data = repo.GetData("SomeUser", "SomePassword");
			Assert.Equal("secret", data);
		}
	}
}
