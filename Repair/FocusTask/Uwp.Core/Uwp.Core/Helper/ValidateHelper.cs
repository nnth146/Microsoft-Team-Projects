using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uwp.Core.Helper
{
    public class ValidateHelper : ObservableObject
    {
        private string _error;
        public string Error { get { return _error; } set { SetProperty(ref _error, value); } }

        private bool _isError;
        public bool IsError { get { return _isError; } set { SetProperty(ref _isError, value); } }

        public ValidateHelper()
        {
            Error = String.Empty;
            IsError = false;
        }

        public void CheckUsername(string username)
        {
            string noError = "";
            string errorMessageOfMinLengthError = "Username can't be less than 8 characters";
            string errorMessageOfNullError = "Username can't be blank";
            string errorMessageOfSpaceError = "Username can't have space";
            string errorMessageOfMaxLengthError = "Username cannot be larger than 30 characters";

            if (string.IsNullOrEmpty(username))
            {
                IsError = true;
                Error = errorMessageOfNullError;
                return;
            }

            if (username.Length < 8)
            {
                IsError = true;
                Error = errorMessageOfMinLengthError;
                return;
            }

            if (username.Length > 30)
            {
                IsError = true;
                Error = errorMessageOfMaxLengthError;
                return;
            }

            if (username.Contains(" "))
            {
                IsError = true;
                Error = errorMessageOfSpaceError;
                return;
            }

            IsError = false;
            Error = noError;
            return;
        }

        public void CheckPassword(string password)
        {
            string noError = "";
            string errorMessageOfLengthError = "Password can't be less than 8 characters";
            string errorMessageOfNullError = "Password can't be blank";
            string errorMessageOfMaxLengthError = "Password cannot be larger than 30 characters";

            if (string.IsNullOrEmpty(password))
            {
                IsError = true;
                Error = errorMessageOfNullError;
                return;
            }

            if (password.Length < 8)
            {
                IsError = true;
                Error = errorMessageOfLengthError;
                return;
            }

            if (password.Length > 30)
            {
                IsError = true;
                Error = errorMessageOfMaxLengthError;
                return;
            }

            IsError = false;
            Error = noError;
            return;
        }
    }
}
