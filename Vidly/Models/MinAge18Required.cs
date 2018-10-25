using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MinAge18Required : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Customer customer = (Customer)validationContext.ObjectInstance;

            if (customer.MemberShipTypeID == 0 || customer.MemberShipTypeID == 1)
            {
                return ValidationResult.Success;
            }
            else
            {
                if (customer.DOB == null)
                    return new ValidationResult("Birth Date required");
                else
                {
                    int AgeDiff = DateTime.Now.Year - customer.DOB.Value.Year;

                    if (AgeDiff > 18)
                        return ValidationResult.Success;
                    else
                        return new ValidationResult("Age should be greater than 18");
                }

            }
        }
    }

    public class MaxQuantity : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Movie moviemodel = (Movie)validationContext.ObjectInstance;


            if (moviemodel.NumberinStock > 20 || moviemodel.NumberinStock < 0)
            {
                return new ValidationResult("Stock should be in between 0 to 20");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}