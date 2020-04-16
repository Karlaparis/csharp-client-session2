using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using Homework2.Models;


namespace Homework2
{
    class Program
    {
        private static List<User> _users = GetUsers();
        private static List<User> GetUsers()
        {
            var users = new List<Models.User>();
            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });
            return users;
        }

        private static void DisplayAllHelloPasswords()
        {
            Console.WriteLine("Step 1: Here are all the passwords that are 'hello':");

            _users.Where(u => u.Password == "hello").AsEnumerable().Select(u => { Console.WriteLine($"Password:{u.Password}"); return false; }).ToList();
        }

        //second solution but this is using a ForEach
        private static void DisplayAllUsersWithHelloPassword()
        {
            var helloUsers = _users.Where(w => w.Password == "hello")
                                        .Select(w => w);

            Console.WriteLine("Step1: Here is the list of users with a password = hello:");
            helloUsers?.ToList().ForEach(u => { Console.WriteLine($"Name:{u.Name}, Password:{u.Password}"); });
        }

        private static void DeletePasswordThatEqualLowerCaseUserName()
        {
            var matchingWordsquery = from u in _users
                                     where (u.Password == u.Name.ToLower())
                                     select u;

            List<Models.User> lst = matchingWordsquery.ToList<Models.User>();
            Console.WriteLine("Step2: Here is the list of users whose password is deleted :");
            lst.Select(people => { people.Password = string.Empty; return false; }).ToList();
            lst.Select(people => { Console.WriteLine($"Name:{people.Name}, Password:{people.Password}"); return false; }).ToList();
        }

        private static void DeleteFirstHelloPasswordUser()
        {   //Other solution:
            // int firstHelloIndex = users.FindIndex(users => users.Password == "hello");
            // users.RemoveAt(firstHelloIndex);
            // Console.WriteLine($"User with the first hello password was removed");


            var firstHello = _users.FirstOrDefault(x => x.Password == "hello");
            if (firstHello != null)

            {
                _users.Remove(firstHello);
                Console.WriteLine($"Step 3: User {firstHello?.Name} with the first hello password was removed");
            }
        }


        static void Main(string[] args)
        {
            //************* 1. Display to the console, all the passwords that are "hello". ***********************
            DisplayAllHelloPasswords();
            DisplayAllUsersWithHelloPassword();

            // ***************** 2 - Deleting the passwords that are the lower-case version of the user name *************
            DeletePasswordThatEqualLowerCaseUserName();

            //**************** 3.Deleting the First User whose Password is Hello ***************************
            DeleteFirstHelloPasswordUser();

            //**************** 4.List of Remaining Users ***************************
            Console.WriteLine("Step 4: The list of remaining users is:");
            _users.Select(u => { Console.WriteLine($"Name:{u.Name}, Password:{u.Password}"); return false; })?.ToList();
        }
    }
}



