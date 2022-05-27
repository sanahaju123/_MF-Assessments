using e_library.UserException;
using System;
using System.Collections.Generic;
using System.Linq;

namespace e_library
{
    public class BookInventory
    {
        List<Book> books = new List<Book>();
        List<Issue> issues = new List<Issue>();
        /// <summary>
        /// Add a book in book collection and store
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public List<Book> AddBook(Book book)
        {
            //do code here
            return books;
        }
        /// <summary>
        /// Issue new book from book collection and calculate remening.
        /// </summary>
        /// <param name="issue"></param>
        public List<Issue> IssueBook(Issue issue)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Show Inventory after book issue
        /// </summary>
        public bool ShowInventory()
        {
            //do code here
            throw new NotImplementedException();
        }
    }
}
