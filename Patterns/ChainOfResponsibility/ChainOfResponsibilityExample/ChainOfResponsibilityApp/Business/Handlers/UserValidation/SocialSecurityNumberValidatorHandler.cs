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
        }

        protected override bool hook()
        {
            return !socialSecurityNumberValidator.Validate(request.SocialSecurityNumber,
                request.CitizenshipRegion);
        }

        protected override void throwException()
        {
            throw new UserValidationException("Social secuirty number could not be validated");
        }
    }
}
