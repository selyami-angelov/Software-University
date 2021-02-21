using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.Books = books.ToList();
        }
        public List<Book> Books { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            Books.Sort(new BookComparator());
            return new LibraryIterator(Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        private class LibraryIterator : IEnumerator<Book>
        {
            private int curIndex = -1;
            private  List<Book> books;

            public LibraryIterator(List<Book> books)
            {
                this.books = books;
            }

            public Book Current => books[curIndex];

            object IEnumerator.Current => Current;

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                curIndex++;
                if (curIndex >= books.Count)
                {
                    return false;
                }

                return true;
            }

            public void Reset()
            {
                curIndex = -1;
            }
        }
    }
}


