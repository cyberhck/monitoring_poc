using System;

namespace Rooft.Responses.Users
{
    public class CreateUserResponse
    {
        public CreateUserResponse(bool? success)
        {
            this.Success = success;
        }

        public bool? Success { set; get; }
    }
}