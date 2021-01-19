using ChainOfResponsibilityApp.Business.Exceptions;
using ChainOfResponsibilityApp.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityApp.Business.Handlers.UserValidation
{
    public class AgeValidationHandler : Handler<User>
    {
        public AgeValidationHandler(User user)
        {
            this.request = user;
            predicate = (user) => user.Age < 18;
        }

        protected override void hookException()
        {
            throw new UserValidationException("You have to be 18 years or older");
        }
    }
}
