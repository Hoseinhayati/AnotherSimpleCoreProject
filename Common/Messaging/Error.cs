namespace Asp.netCore_MVC_.Common.Messaging
{
    public class Error
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="errorType"></param>
        public Error(string title, string message, ErrorType errorType)
        {
            Title = title;
            Message = message;
            ErrorType = errorType;
        }

        /// <summary>
        /// title of message
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// message string
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ErrorType ErrorType { get; set; }
    }
}
