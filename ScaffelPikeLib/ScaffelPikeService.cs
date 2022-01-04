using System;
using System.Threading.Tasks;
using ScaffelPikeLib;

namespace ScaffelPikeLib
{
    public class ScaffelPikeService : IScaffelPikeService
    {
        public async Task<PasswordDto> LogIn(string username, string password)
        {
            return await Task<PasswordDto>.Factory.StartNew(() =>
            {
                return doLogIn(username, password);
            });
        }
        private PasswordDto doLogIn(string username, string password)
        {
            Console.WriteLine($"Recieved Log In Request with Username: {username}, Password: {password}");

            if (username == "Joe" && password == "password123")
            {
                Console.WriteLine("Successful");
                return new PasswordDto() { Success = true, OtherData = "Joe Osborne" };
            }

            Console.WriteLine("Failed");
            return new PasswordDto() { Success = false, OtherData = "" };
        }
    }
}
