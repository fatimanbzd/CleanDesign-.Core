using System.Runtime.Serialization;
using System.Linq;

namespace Ecommerce.Application.Models.Responses
{
    public class ApiResponse
    {

        protected ApiResponse() { }

        public static ApiResponse Success()
        {
            return new ApiResponse
            {
                IsSuccess = true
            };
        }

        public static ApiResponseResult<T> Success<T>(T value)
        {
            return new ApiResponseResult<T>
            {
                Result = value,
                IsSuccess = true
            };
        }
        public static ApiResponse Error(string error)
        {
            return Error(error);
        }

        public static ApiResponse Error(string[] errors, string requestId)
        {
            return new ErrorResult
            {
                Errors = errors,
                IsSuccess = false
            };
        }

        public static ApiResponseResult<T> Error<T>(string error)
        {
            return Error<T>(new[] { error });
        }

        public static ApiResponseResult<T> Error<T>(string[] errors)
        {
            return new ErrorResult<T>
            {
                Errors = errors,
                IsSuccess = false
            };
        }


        [DataMember(Name = "success")]
        public virtual bool IsSuccess { get; set; }

        [DataContract]
        public class ErrorResult : ApiResponse
        {
            [DataMember(Name = "errors")]
            public virtual string[] Errors { get; set; } = null!;
        }

        [DataContract]
        public class ApiResponseResult<T> : ApiResponse
        {
            [DataMember(Name = "result")]
            public T? Result { get; set; }
        }


        [DataContract]
        public class ErrorResult<T> : ApiResponseResult<T>
        {
            [DataMember(Name = "errors")]
            public virtual string[] Errors { get; set; } = null!;
        }
    }
}
