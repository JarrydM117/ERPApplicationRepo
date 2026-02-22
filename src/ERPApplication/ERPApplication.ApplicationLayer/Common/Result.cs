using ERPApplication.DomainLayer.Models;
using Microsoft.AspNetCore.Hosting.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ERPApplication.ApplicationLayer.Common
{

    /*
     * 
     * Result Pattern class.
     * Used to handle all businesslogic errors.
     * All other technical exceptions are handled globally.
     * 
     */

    public class Result
    {
        public bool IsError { get; set; }
        public Error Error { get; set; }
        protected Result(bool isError, ErrorType errorType, string message = "")
        {
            IsError = isError;
            Error = new(errorType, message);
        }
        public static Result Success() => new(false, ErrorType.None);
        public static Result Unsuccessful(ErrorType errorType, string message) => new(true, errorType, message);
    }

    public class Result<T> : Result
    {
        private T? Value;

        private Result(bool isError, ErrorType errorType, T value, string message = ""): base(isError, errorType, message)
        {
            Value = value;
        }
        public static Result<T> Success(T value) => new (false, ErrorType.None, value);
        public new static Result<T> Unsuccessful(ErrorType errorType, string message) => new(true, errorType,default, message);

        public T GetValue()
        {
            return !IsError ? Value : throw new InvalidOperationException("Cannot retrieve a value that was never initialised");
        }
    }


}
