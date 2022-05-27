using System;
using System.Collections.Generic;
using System.Text;

namespace e_library.UserException
{
    [Serializable]
    public class ISBNAlreadyExistsException: Exception
    {
        public ISBNAlreadyExistsException(){}
        public ISBNAlreadyExistsException(string message) : base (message){}
        public ISBNAlreadyExistsException(string message, Exception exception) : base(message, exception){}
    }
}
