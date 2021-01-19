using ChainOfResponsibilityApp.Business.Exceptions;
using ChainOfResponsibilityApp.Business.Handlers;
using ChainOfResponsibilityApp.Business.Handlers.UserValidation;
using ChainOfResponsibilityApp.Business.Models;
using ChainOfResponsibilityApp.Business.Validators;
using System;

namespace ChainOfResponsibilityApp.Business
{
    public class UserProcessor
    {
        private SocialSecurityNumberValidator socialSecurityNumberValidator
            = new SocialSecurityNumberValidator();

        public void Register(User user)
        {
            try
            {
                IHandler<User> handler = new SocialSecurityNumberValidatorHandler(user);
                handler.SetNext(new AgeValidationHandler(user))
                    .SetNext(new NameValidationHandler(user))
                    .SetNext(new CitizenshipRegionValidationHandler(user));

                handler.Handle();
            }
            catch (UserValidationException ex)
            {
                throw ex;
            }
        }
    }
}