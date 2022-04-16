using System.ComponentModel;

namespace Asp.netCore_MVC_.Common.Messaging
{
    public enum ErrorType
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("خطا")]
        Error = 0,

        /// <summary>
        /// 
        /// </summary>
        [Description("اخطار")]
        Warning = 0,

        /// <summary>
        /// 
        /// </summary>
        [Description("خارج از اعتبار")]
        NotValid = 1
    }
}
