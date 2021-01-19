using ChainOfResponsibilityApp.Business.Exceptions;
using ChainOfResponsibilityApp.Business.Models;
using ChainOfResponsibilityApp.Business.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityApp.Business.Handlers.UserValidation
{
    public class SocialSecurityNumberValidatorHandler : Handler<User>
    {
        private SocialSecurityNumberValidator socialSecurityNumberValidator
            = new SocialSecurityNumberValidator();

        public SocialSecurityNumberValidatorHandler(User user)
        {
            this.request = user;
            predicate = (user) => !socialSecurityNumberValidator.Validate(user.SocialSecurityNumber,
                user.CitizenshipRegion);
        }

        protected override void hookException()
        {
            throw new UserValidationException("Social secuirty number could not be validated");
        }
    }
}
