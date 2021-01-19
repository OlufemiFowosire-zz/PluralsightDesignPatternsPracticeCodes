using ChainOfResponsibilityApp.Business.Exceptions;
using ChainOfResponsibilityApp.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityApp.Business.Handlers.UserValidation
{
    public class NameValidationHandler : Handler<User>
    {
        public NameValidationHandler(User user)
        {
            this.request = user;
            predicate = (user) => user.Name.Length <= 1;
        }

        protected override void hookException()
        {
            throw new UserValidationException("Your name is unlikey this short.");
        }
    }
}
