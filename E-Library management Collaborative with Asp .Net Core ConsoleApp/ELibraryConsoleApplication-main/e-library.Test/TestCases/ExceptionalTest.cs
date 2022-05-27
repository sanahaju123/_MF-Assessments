using e_library.Test;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace e_library.Test.TestCases
{
    public class ExceptionalTest
    {
        /// <summary>
        /// Creating referance variable and injecting in constructor
        /// </summary>
        private readonly ITestOutputHelper _output;
        private Book _book;
        private Issue _issue;
        private static string type = "Exceptional";
        public ExceptionalTest(ITestOutputHelper output)
            {
            _output = output;
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
        /// test for add book passed null should return null
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> testFor_AddNewBookReturnNullOrNot()
        {
            //Arrange
            bool res = false;
            string testName;string status;
            _book = null;
            List<Book> books = new List<Book>();
            testName = CallAPI.GetCurrentMethodName();
            BookInventory inventory = new BookInventory();
            try
            {
                books = inventory.AddBook(_book);
                //Act
                if (books[0] == null)
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
