using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone_Two
{
    class UnregisteredAdminException : Exception
    {
        public UnregisteredAdminException()
        {
        }

        public UnregisteredAdminException(string message) : base(message)
        {
           
        }

        public UnregisteredAdminException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnregisteredAdminException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message => "File path not found, register new user!";
    }
}
