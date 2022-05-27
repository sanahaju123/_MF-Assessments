using e_library.Test;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace e_library.Test.TestCases
{
    public class FunctionalTests
    {
        /// <summary>
        /// Creating referance variable of ITestOutputHelper and injecting in constructor
        /// </summary>
        private readonly ITestOutputHelper _output;
        private Book _book;
        private Issue _issue;
        private static string type = "Functional";
        public FunctionalTests(ITestOutputHelper output)
            {
            _output = output;
            _book = new Book()
            {
                ISBN = "10029",
                BookName = "C in action",
                Issue = false,
                PublicationName = "M C Hill",
                Category = "Science"
            };
            _issue = new Issue()
            {
                ISBN = "10029",
                StudentName = "Uma Kumar",
                IssueDate = DateTime.Now
            };
        }
       
        /// <summary>
        /// Test for add new book if book is added return true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> testFor_AddNewBookReturnTrueOrFalse()
        {
            //Arrange
            bool res = false;
            string testName;string status;
            List<Book> books = new List<Book>();
            testName = CallAPI.GetCurrentMethodName();
            BookInventory inventory = new BookInventory();
            try
            {
                books = inventory.AddBook(_book);
                //Act
                if (books.Count != 0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                ///Write test result if any exception occur
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
              }
            ///Assert
            ///Write final test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// Test to issue new book for student
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> testFor_IssueNewBookReturnTrueOrFalse()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            BookInventory inventory = new BookInventory();
            try
            {
                inventory.AddBook(_book);
                List<Issue> issues = new List<Issue>();
                issues = inventory.IssueBook(_issue);
                //Act
                if (issues.Count > 0)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
              ///Write test result if any exception occur
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }
            ///Assert
            ///Write final test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        /// <summary>
        /// test for show inventory
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> testFor_ShowInventoryReturnListOfBooks()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            BookInventory inventory = new BookInventory();
            try
            {
                inventory.AddBook(_book);
                res = inventory.ShowInventory();
                //Act
                if (res == true)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
              ///Write test result if any exception occur
              status = Convert.ToString(res);
              _output.WriteLine(testName + ":Failed");
              await CallAPI.saveTestResult(testName, status, type);
              return false;
            }
            ///Assert
            ///Write final test result
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
    }
}
