using System;
using System.Collections.Generic;
using System.Text;

namespace e_library.UserException
{
    [Serializable]
    public class BookNotAvailableException : Exception
    {
        public BookNotAvailableException() { }
        public BookNotAvailableException(string message) : base(message) { }
        public BookNotAvailableException(string message, Exception exception) : base(message, exception) { }
    }
}
