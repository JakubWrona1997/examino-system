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

        public static Dictionary<int, string> CommonResponse { get; set; } = new Dictionary<int, string>()
        {
            //don t add 400 bad request(validation give that ),401 unathorized
            { 204,"No Content Response , operation succeed"},
            { 403,"Forbidden"},
            { 404,"Not found"}
           
        };
       
    }

   
}
