using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WorldDiscovery.Core.Features
{
    public enum MessageType
    {
        Success,
        Info,
        Warning,
        Error
    }

    public class Message
    {
        public string Value { get; set; } = "";

        public MessageType Type { get; set; }

        public Message()
        {
        }

        public Message(string val, MessageType type)
        {
            Value = val;
            Type = type;
        }
    }

    public class LayoutDataService : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _pageTitle = "";

        public string PageTitle
        {
            get => _pageTitle;
            set
            {
                _pageTitle = value;
                OnPropertyChanged();
            }
        }

        private Message _message = new Message();

        public Message Message { get => _message; set { _message = value; OnPropertyChanged(); } }
    }
}
