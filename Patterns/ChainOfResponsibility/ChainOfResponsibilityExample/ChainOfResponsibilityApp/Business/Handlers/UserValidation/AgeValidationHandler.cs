﻿using ChainOfResponsibilityApp.Business.Exceptions;
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
        }

        protected override bool hook()
        {
            return request.Age < 18;
        }

        protected override void throwException()
        {
            throw new UserValidationException("You have to be 18 years or older");
        }
    }
}
