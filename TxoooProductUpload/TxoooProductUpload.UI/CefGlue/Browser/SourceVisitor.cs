using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace TxoooProductUpload.UI.CefGlue.Browser
{
    public sealed class SourceVisitor : CefStringVisitor
    {
        private readonly Action<string> _callback;

        public SourceVisitor(Action<string> callback)
        {
            _callback = callback;
        }

        protected override void Visit(string value)
        {
            _callback(value);
        }
    }
}
