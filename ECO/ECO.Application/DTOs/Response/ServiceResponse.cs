using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Response
{
    public class ServiceResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public object? Data { get; set; }
        public DateTime ServerTime { get; set; } = DateTime.Now;

        public ServiceResponse Onsuccess(object? data = null)
        {
            if (data != null)
            {
                Data = data;
            }
            return this;
        }

        public ServiceResponse OnException(Exception ex)
        {
            if (ex != null)
            {
                Success = false;
                Message = ex.Message;
            }
            return this;
        }

        public ServiceResponse OnError(object? data = null, string message = "Error while procees request.")
        {
            Success = false;
            if (data != null)
            {
                Data = data;
            }
            if (string.IsNullOrEmpty(Message))
            {
                Message = message;
            }

            return this;
        }

    }
}
