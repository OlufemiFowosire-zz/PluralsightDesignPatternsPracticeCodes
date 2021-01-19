﻿using ChainOfResponsibilityApp.Business.Exceptions;
using ChainOfResponsibilityApp.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityApp.Business.Handlers.UserValidation
{
    public class CitizenshipRegionValidationHandler : Handler<User>
    {
        public CitizenshipRegionValidationHandler(User user)
        {
            this.request = user;
            predicate = (user) => user.CitizenshipRegion.TwoLetterISORegionName == "NO";
        }

        protected override void hookException()
        {
            throw new UserValidationException("We currently do not support Norwegians");
        }
    }
}
