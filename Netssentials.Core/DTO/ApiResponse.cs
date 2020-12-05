using System;
using System.Collections.Generic;
using System.Text;

namespace Netssentials.Core.DTO
{
    public class ApiResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }
    }
}
