using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixClass
{
    [Serializable] 
    public class DifferentMatricesException : ArgumentException
    {
        private long? lineNumber;

        public DifferentMatricesException(string message)
            : base(message)
        {

        }

        public override string Message
        {
            get
            {
                if (lineNumber != null)
                {
                    string result = string.Format("{0}",
                        base.Message, this.lineNumber);
                    return result;
                }
                else
                {
                    string result = string.Format("{0}",
                       base.Message);
                    return result;
                }
            }
        }
    }
}
