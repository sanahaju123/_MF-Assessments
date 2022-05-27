using System;
using System.Collections.Generic;
using System.Text;

namespace e_library.UserException
{
    [Serializable]
    public class ISBNDoesNotExistsException : Exception
    {
        public ISBNDoesNotExistsException() { }
        public ISBNDoesNotExistsException(string message) : base(message) { }
        public ISBNDoesNotExistsException(string message, Exception exception) : base(message, exception) { }
    }
}
