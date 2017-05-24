namespace Blog.Tests.Models
{
    public class RegistrationPageModel
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string RememberMe { get; set; }

        public string ExpectedError { get; set; }

    }
}
