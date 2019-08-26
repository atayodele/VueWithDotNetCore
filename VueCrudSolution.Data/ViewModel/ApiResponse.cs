using System;
using System.Collections.Generic;
using System.Text;

namespace VueCrudSolution.Data.ViewModel
{
    public class ApiResponse : BaseViewModel
    {
        public int Code { get; set; }
        public int Result { get; set; }
        public string Description { get; set; }
        public bool ErrorStatus
        {
            get
            {
                return base.HasError;
            }
        }
    }

    public class ApiResponse<T> : ApiResponse where T : class
    {
        public T Payload { get; set; } = default(T);
        public int TotalCount { get; set; }
    }
}
