﻿namespace Kemet.ERP.Contracts.Response
{
    public class ApiResponse
    {
        public ApiResponse(bool _status, object _data)
        {
            status = _status;
            data = _data;
        }

        public bool status { get; }
        public object data { get; } = new object();
    }
}
