using System.Collections.Generic;

namespace DefiningClasses
{
    class Family
    {
        List<Person> people = new List<Person>();

        public Family()
        {
            
        }

        public void AddMember(Person person)
        {
            this.people.Add(person);
        }

        public Person GetOldestMember()
        {
            int bigestAge = int.MinValue;
            Person oldesOne = new Person();

            foreach (var item in people)
            {
                if (item.Age>bigestAge)
                {
                    bigestAge = item.Age;
                    oldesOne = item;
                }
            }

            return oldesOne;
        }
    }
}
