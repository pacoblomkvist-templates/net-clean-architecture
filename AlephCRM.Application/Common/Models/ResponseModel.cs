﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blmk.Application.Common.Models
{
    public class ResponseModel
    {
        public bool IsSuccessful { get; set; }
        public string? Message { get; set; }


        public static ResponseModel Success(string? message = null)
        {
            return new ResponseModel()
            {
                IsSuccessful = true,
                Message = message ?? "Request was Successful",

            };
        }

        public static ResponseModel Failure(string? message = null) // , Dictionary<string, string> errors = null
        {
            return new ResponseModel()
            {
                Message = message ?? "Request was not completed",

                //Errors = errors
            };

        }

        public static ResponseModel AuthorizationFailure(string? message = null) // , Dictionary<string, string> errors = null
        {
            return new ResponseModel()
            {
                Message = message ?? "Request was not completed",
                //Errors = errors
            };

        }
        public static ResponseModel ValidationError(string? message = null) // , Dictionary<string, string> errors = null
        {
            return new ResponseModel()
            {
                Message = message ?? "One or more validation error occurred",
                //Errors = errors
            };

        }
    }

    public class ResponseModel<T> : ResponseModel
    {
        public T Data { get; set; }

        public static ResponseModel<T> Success(T data, string? message = null)
        {
            return new ResponseModel<T>()
            {
                IsSuccessful = true,
                Message = message ?? "Request was Successful",
                Data = data,
            };
        }
        public static ResponseModel<T> Failure(T data, string? message = null)
        {
            return new ResponseModel<T>()
            {
                IsSuccessful = false,
                Message = message ?? "Request failed",
                Data = data,
            };
        }
    }




    public class ResponseErrorModel : ResponseModel
    {
        public IDictionary<string, string[]>? Errors { get; set; }

        public static ResponseModel Failure(IDictionary<string, string[]>? errors = null, string? message = null)
        {
            return new ResponseErrorModel()
            {
                Message = message ?? "Request was not completed",
                Errors = errors ?? new Dictionary<string, string[]>(),
            };
        }
    }
}
