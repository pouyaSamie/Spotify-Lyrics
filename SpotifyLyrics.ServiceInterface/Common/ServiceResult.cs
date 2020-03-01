using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyLyrics.ServiceInterface.Common
{
    public class ServiceResult<T>
    {

        public T Date { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public ServiceResult(T date, string message, bool isSuccess)
        {
            Date = date;
            Message = message;
            IsSuccess = isSuccess;
        }

        public static ServiceResult<T> Success(T date) => new ServiceResult<T>(date, "Success", true);
        public static ServiceResult<T> Failed(string error) => new ServiceResult<T>(default(T), error,false);

    }
}
