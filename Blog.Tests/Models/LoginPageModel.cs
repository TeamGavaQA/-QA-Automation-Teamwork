namespace Blog.Tests.Models
{
    public class LoginPageModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string RememberMe { get; set; }

        public string ExpectedError { get; set; }
    }
}
