using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SanctionExpense.Core.Models.DTO
{
    public class CustomResponseDTO<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<string> ErrorList  { get; set; }

        public static CustomResponseDTO<T> Success(int statusCode,T data)
        {
            return new CustomResponseDTO<T>{ StatusCode = statusCode, Data = data, ErrorList = null };
        }

        public static CustomResponseDTO<T> Success(int statusCode)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode };
        }

        public static CustomResponseDTO<T> Error(int statusCode, List<string> errors)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode, ErrorList = errors };
        }
        public static CustomResponseDTO<T> Error(int statusCode, string error)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode, ErrorList = new List<string> { error } };
        }
    }
}
