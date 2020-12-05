using System;
using System.Collections.Generic;
using System.Text;

namespace Netssentials
{
    // in a pool of micro-services, this should be placed in a shared project

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
