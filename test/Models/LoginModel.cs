namespace test.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string addStrings(string username, string password)
        {
            string total = username + ":" + password;
            return total;
        }
    }
}
