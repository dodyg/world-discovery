using System;
using System.Collections.Generic;
using System.Text;

namespace WorldDiscovery.Core.Features.Identity
{
    public interface IGraph<T>
    {
        T ConvertTo();
    }

    public class PersonNewInput : IGraph<Person>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Person ConvertTo()
        {
            return new Person()
            {
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }

    public class Person
    {
        public long Uid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
