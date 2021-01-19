using ChainOfResponsibilityApp.Business.Exceptions;
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
        }

        protected override bool hook()
        {
            return request.CitizenshipRegion.TwoLetterISORegionName == "NO";
        }

        protected override void throwException()
        {
            throw new UserValidationException("We currently do not support Norwegians");
        }
    }
}
