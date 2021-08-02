using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp1
{
    public class Person
    {
        internal Guid Id { get; set; }
        public string Name { get; set; }
        public Person Spouse { get; set; }
    }

    public class GuidReferenceResolver : ReferenceResolver
    {
        private readonly IDictionary<Guid, Person> _people = new Dictionary<Guid, Person>();

        public override object ResolveReference(string referenceId)
        {
            Guid id = new Guid(referenceId);

            _people.TryGetValue(id, out Person p);

            return p;
        }

        public override string GetReference(object value, out bool alreadyExists)
        {
            Person p = (Person)value;

            if (!(alreadyExists = _people.ContainsKey(p.Id)))
            {
                _people[p.Id] = p;
            }

            return p.Id.ToString();
        }

        public override void AddReference(string reference, object value)
        {
            Guid id = new Guid(reference);
            Person person = (Person)value;
            person.Id = id;
            _people[id] = person;
        }
    }

    internal static class Program
    {
        public static void Main()
        {
            Person tyler = new() { Id = Guid.NewGuid(), Name = "Tyler" };
            Person adrian = new() { Id = Guid.NewGuid(), Name = "Adrian" };
            tyler.Spouse = adrian;
            adrian.Spouse = tyler;
            var people = new List<Person> { tyler, adrian };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = new ReferenceHandler<GuidReferenceResolver>()
            };

            string json = JsonSerializer.Serialize(people, options);
            Console.WriteLine($"Output JSON {json}");

            List<Person> peopleDeserialized =
                JsonSerializer.Deserialize<List<Person>>(json, options);

            Person tylerDeserialized = people[0];
            Person adrianDeserialized = people[1];

            Console.WriteLine($"Adrian is Tyler's spouse: {tylerDeserialized.Equals(adrianDeserialized.Spouse)}");
            Console.WriteLine($"Tyler is Adrian's spouse: {adrianDeserialized.Equals(tylerDeserialized.Spouse)}");
        }
    }
}
