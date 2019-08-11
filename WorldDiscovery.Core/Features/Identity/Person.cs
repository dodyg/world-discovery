using System;
using System.Collections.Generic;
using System.Text;

namespace WorldDiscovery.Core.Features.Identity
{
    public interface IGraph<out T>
    {
        T ConvertTo();
    }

    public class PersonNewInput 
    {
        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";
    }

    public class Person
    {
        public long Uid { get; set; }

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";
    }
}
