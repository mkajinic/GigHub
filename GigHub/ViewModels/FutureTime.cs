﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    public class FutureTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;

            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                 "HH:mm",
                 CultureInfo.CurrentCulture,
                 DateTimeStyles.None,
                 out dateTime);

            //make sure date is in the future (bool expression)
            return (isValid);

        }
    }
}