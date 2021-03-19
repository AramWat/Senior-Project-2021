using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    [Serializable]
    public class DslParserException : Exception
    {
        public DslParserException(string message)
            : base(message)
        {

        }
    }
}