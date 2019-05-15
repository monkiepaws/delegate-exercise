using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ObjectLibrary;


namespace FileParserNetStandard {
    
    // public class Person { }  // temp class delete this when Person is referenced from dll
    
    public class PersonHandler {
        public List<Person> People;

        /// <summary>
        /// Converts List of list of strings into Person objects for People attribute.
        /// </summary>
        /// <param name="people"></param>
        public PersonHandler(List<List<string>> people)
        {
            People = people.Skip(1).Select((person, index) => new Person(
                int.Parse(person[0]), 
                person[1], 
                person[2], 
                new DateTime(long.Parse(person[3]))))
                .ToList();
        }

        /// <summary>
        /// Gets oldest people
        /// </summary>
        /// <returns></returns>
        public List<Person> GetOldest()
        {
            return People
                .OrderBy(p => p.Dob)
                .TakeWhile(p => 
                    People.Min(people => people.Dob.Date) == p.Dob.Date)
                .ToList(); //-- return result here
        }

        /// <summary>
        /// Gets string (from ToString) of Person from given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetString(int id) {

            return People
                .FirstOrDefault(p => p.Id == id)
                .ToString();  //-- return result here
        }

        public List<Person> GetOrderBySurname() {
            return People.OrderBy(p => p.Surname).ToList();  //-- return result here
        }

        /// <summary>
        /// Returns number of people with surname starting with a given string.  Allows case-sensitive and case-insensitive searches
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public int GetNumSurnameBegins(string searchTerm, bool caseSensitive) {

            return People.Count(p => caseSensitive 
                ? p.Surname.StartsWith(searchTerm) 
                : p.Surname.ToLower().StartsWith(searchTerm.ToLower()));  //-- return result here
        }
        
        /// <summary>
        /// Returns a string with date and number of people with that date of birth.  Two values seperated by a tab.  Results ordered by date.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAmountBornOnEachDate() {
            List<string> result = People.OrderBy(p => p.Dob.Date).Select(p => p.Dob.Date.ToString()).Distinct().ToList();
            return result.Select(r => $"{r}\t{People.Count(p => p.Dob.Date.ToString() == r)}").ToList();  //-- return result here
        }
    }
}