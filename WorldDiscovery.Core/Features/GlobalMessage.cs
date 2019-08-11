using System;
using System.Collections.Generic;
using System.Text;

namespace WorldDiscovery.Core.Features
{
    public class GlobalMessage
    {
        readonly LayoutDataService _layout;

        public GlobalMessage(LayoutDataService layout)
        {
            _layout = layout;
        }

        public void Success(string txt)
        {
            _layout.Message = new Message
            {
                Value = txt,
                Type = MessageType.Success
            };
        }
        public void Error(string txt)
        {
            _layout.Message = new Message
            {
                Value = txt,
                Type = MessageType.Error
            };
        }

        public void Info(string txt)
        {
            _layout.Message = new Message
            {
                Value = txt,
                Type = MessageType.Info
            };
        }

        public void Warning(string txt)
        {
            _layout.Message = new Message
            {
                Value = txt,
                Type = MessageType.Warning
            };
        }
    }
}
