using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Trlifaj.Choirify.Helpers
{
    public class ChoirAppException : Exception
    {
        public ChoirAppException() : base()
        {

        }

        public ChoirAppException(string message) : base(message)
        {
        }

        public ChoirAppException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ChoirAppException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override Exception GetBaseException()
        {
            return base.GetBaseException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
