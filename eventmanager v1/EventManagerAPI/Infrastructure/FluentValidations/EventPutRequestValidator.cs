﻿using EventManagerAPI.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagerAPI.Infrastructure.FluentValidations
{
    public class EventPutRequestValidator : AbstractValidator<EventPutRequest>
    {
        public EventPutRequestValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();

            RuleFor(x => x.StartDate)
                .NotEmpty()
                .GreaterThanOrEqualTo(x => DateTime.Now)
                .WithMessage("Start Time is incorrect");

            RuleFor(x => x.Title)
                .NotEmpty();


        }
    }
}
