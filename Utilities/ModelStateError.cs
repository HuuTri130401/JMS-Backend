using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class ModelStateError
    {
        /// <summary>
        /// Lấy thông tin lỗi dữ liệu model
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static string GetErrorMessage(this ModelStateDictionary modelState)
        {
            string ResultMessage = string.Empty;
            var result = new List<Error>();
            var erroneousFields = modelState.Where(ms => ms.Value.Errors.Any())
                                            .Select(x => new { x.Key, x.Value.Errors });

            foreach (var erroneousField in erroneousFields)
            {
                var fieldKey = erroneousField.Key;
                var fieldErrors = erroneousField.Errors
                                   .Select(error => new Error(fieldKey, error.ErrorMessage));
                result.AddRange(fieldErrors);
            }
            if (result.Any())
            {
                ResultMessage = string.Join("; ", result.Select(x => x.Message).ToArray());
            }
            return ResultMessage;
        }

        public class Error
        {
            public Error(string key, string message)
            {
                Key = key;
                Message = message;
            }
            public string Key { get; set; }
            public string Message { get; set; }
        }
    }
}
