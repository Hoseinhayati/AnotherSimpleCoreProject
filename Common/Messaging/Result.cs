using System.Collections.Generic;
using System.Linq;

namespace Asp.netCore_MVC_.Common.Messaging
{
    public class Result
    {
        /// <summary>
        /// retun 'true' when that no errors
        /// </summary>
        public bool Success { get; private set; }

        /// <summary>
        /// return entity Id
        /// </summary>
        public object ReturnValue { get; set; }

        /// <summary>
        /// to set 'Success = true'
        /// </summary>
        public Result()
        {
            Success = true;
        }

        /// <summary>
        /// List of error! If no error then retun null
        /// </summary>
        public List<Error> Errors { get; private set; }

        /// <summary>
        /// Add error to errors collection and set 'Success' to false
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="errorType"></param>
        public void AddError(string title, string message, ErrorType? errorType = ErrorType.Error)
        {
            if (Errors == null)
                Errors = new List<Error>();

            if (Errors.Any(a => a.Title.ToLower() == title.ToLower() && a.Message.ToLower() == message.ToLower()))
                return;
            if (!errorType.HasValue)
                errorType = ErrorType.Error;
            Errors.Add(new Error(title, message, (ErrorType)errorType));
            Success = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorsDictionary"></param>
        public void AddErrors(Dictionary<string, string> errorsDictionary)
        {
            foreach (var error in errorsDictionary)
            {
                AddError(error.Key, error.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messages"></param>
        public void AddErrors(List<Error> messages)
        {
            foreach (var error in messages)
            {
                AddError(error.Title, error.Message);
            }
        }

    }
}
