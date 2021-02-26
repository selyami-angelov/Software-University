using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string, bool> startWith = (x, y) => x.StartsWith(y);
            Func<string, string, bool> endWith = (x, y) => x.EndsWith(y);
            Func<string, int, bool> lenght = (x, y) => x.Length == y;
            Func<string, string, bool> contains = (x, y) => x.Contains(y);

            List<string> guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<Filter> filtersList = new List<Filter>();

            string comandData = Console.ReadLine();

            while (comandData != "Print")
            {
                string comand = comandData.Split(";", StringSplitOptions.RemoveEmptyEntries)[0];
                string criteria = comandData.Split(";", StringSplitOptions.RemoveEmptyEntries)[1];
                string parameter = comandData.Split(";", StringSplitOptions.RemoveEmptyEntries)[2];

                if (comand == "Add filter")
                {
                    if (criteria == "Starts with")
                    {
                        Filter filter = new Filter();
                        filter.Criteria = criteria;
                        filter.Parameter = parameter;
                        filtersList.Add(filter);
                    }
                    else if (criteria == "Ends with")
                    {
                        Filter filter = new Filter();
                        filter.Criteria = criteria;
                        filter.Parameter = parameter;
                        filtersList.Add(filter);
                    }
                    else if (criteria == "Length")
                    {
                        Filter filter = new Filter();
                        filter.Criteria = criteria;
                        filter.Parameter = parameter;
                        filtersList.Add(filter);
                    }
                    else if (criteria == "Contains")
                    {
                        Filter filter = new Filter();
                        filter.Criteria = criteria;
                        filter.Parameter = parameter;
                        filtersList.Add(filter);
                    }
                }
                else if (comand == "Remove filter")
                {
                    if (criteria == "Starts with")
                    {
                        for (int i = 0; i < filtersList.Count; i++)
                        {
                            if (filtersList[i].Criteria == criteria && filtersList[i].Parameter == parameter)
                            {
                                filtersList.Remove(filtersList[i]);
                            }
                        }
                    }
                    else if (criteria == "Ends with")
                    {
                        for (int i = 0; i < filtersList.Count; i++)
                        {
                            if (filtersList[i].Criteria == criteria && filtersList[i].Parameter == parameter)
                            {
                                filtersList.Remove(filtersList[i]);
                            }
                        }
                    }
                    else if (criteria == "Length")
                    {
                        for (int i = 0; i < filtersList.Count; i++)
                        {
                            if (filtersList[i].Criteria == criteria && filtersList[i].Parameter == parameter)
                            {
                                filtersList.Remove(filtersList[i]);
                            }
                        }
                    }
                    else if (criteria == "Contains")
                    {
                        for (int i = 0; i < filtersList.Count; i++)
                        {
                            if (filtersList[i].Criteria == criteria && filtersList[i].Parameter == parameter)
                            {
                                filtersList.Remove(filtersList[i]);
                            }
                        }
                    }
                }

                comandData = Console.ReadLine();
            }

            var filteredGuests = new List<string>(guests);

            foreach (var item in filtersList)
            {
                if (item.Criteria == "Starts with")
                {
                    filteredGuests = filteredGuests.Where(x => !x.StartsWith(item.Parameter)).ToList();
                }
                else if (item.Criteria == "Ends with")
                {
                    filteredGuests = filteredGuests.Where(x => !x.EndsWith(item.Parameter)).ToList();
                }
                else if (item.Criteria == "Length")
                {
                    filteredGuests = filteredGuests.Where(x => !(x.Length == int.Parse(item.Parameter))).ToList();
                }
                else if (item.Criteria == "Contains")
                {
                    filteredGuests = filteredGuests.Where(x => !x.Contains(item.Parameter)).ToList();
                }
            }

            Console.WriteLine(string.Join(" ", filteredGuests));

        }

        class Filter
        {
            public string Criteria { get; set; }
            public string Parameter { get; set; }
        }
    }
}

