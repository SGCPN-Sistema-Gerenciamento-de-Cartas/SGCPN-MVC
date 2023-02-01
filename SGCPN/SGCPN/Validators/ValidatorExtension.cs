
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SGCPN.Validators
{
    public static class ValidatorExtension
    {
        //add erros ao model state que podem ser vistos pela view: https://docs.fluentvalidation.net/en/latest/aspnet.html

        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
