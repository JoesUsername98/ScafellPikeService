using System;
using System.Threading.Tasks;
using ScaffelPikeLib;

namespace ScaffelPikeLib
{
    public class ScaffelPikeService : IScaffelPikeService
    {
        public PasswordDto LogIn(string username, string password)
        {
            var a = Task.Run(() => doLogInAsync(username, password));
            a.Wait();
            return a.Result;
        }

        private PasswordDto doLogInAsync(string username, string password)
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
        // Implement this for Log In 
        public IAsyncResult BeginLogIn2AsyncMethod(string username, string password, AsyncCallback callback, object asyncState)
        {
            Console.WriteLine("BeginLogInAsyncMethod called with: {0} {1}", username, password);
            return new CompletedAsyncResult<PasswordDto>(doLogInAsync(username, password));
        }

        public PasswordDto EndLogIn2AsyncMethod(IAsyncResult r)
        {
            CompletedAsyncResult<PasswordDto> result = r as CompletedAsyncResult<PasswordDto>;
            Console.WriteLine("EndLogInAsyncMethod called with result: {0}", result.Data.Success);
            return result.Data;
        }

        public async Task<PasswordDto> LogIn3TaskAsync(string username, string password)
        {
            return await Task<PasswordDto>.Factory.StartNew(() =>
            {
                return doLogInAsync(username, password);
            });
        }
    }
}
