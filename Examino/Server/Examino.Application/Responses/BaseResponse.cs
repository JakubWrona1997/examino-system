using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Examino.Application.Responses
{
    public class BaseResponse
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        

        public BaseResponse()
        {            
            Success = true;
        }
        public BaseResponse(string message = null)
        {
           
            Success = true;
            Message = message;
        }

        public BaseResponse(int statusCode,bool success)
        {
            Success = success;
            StatusCode = statusCode;
            Message = CommonResponse[statusCode].ToString();
        }

        public BaseResponse(int statusCode, string message,bool success)
        {          
            Success = success;
            Message = message;
            StatusCode = statusCode;
        }

        private static Dictionary<int, string> CommonResponse { get; } = new Dictionary<int, string>()
        {
            { 204,"No Content Response , operation succeed"},
            { 201,"Created"},
            { 400,"Bad request"},
            { 403,"Forbidden"},
            { 404,"Not found"},
            { 500 ,"Something went wrong"}
        };
       
    }

   
}
