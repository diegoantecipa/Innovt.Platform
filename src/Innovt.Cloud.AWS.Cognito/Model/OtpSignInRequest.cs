﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Innovt.Cloud.AWS.Cognito.Resources;
using Innovt.Core.Collections;

namespace Innovt.Cloud.AWS.Cognito.Model
{
    public class OtpSignInRequest: SignInRequestBase 
    {
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (UserName.IsNullOrEmpty())
            {
                yield return new ValidationResult(Messages.UserNameIsRequired, new[] { nameof(UserName) });
            }
        }
    }
}
