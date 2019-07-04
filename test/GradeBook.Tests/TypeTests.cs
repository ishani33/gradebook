using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void PassIntByRef()
        {
            var x = GetInt1();
            SetInt1(ref x);  
            Assert.Equal(42,x);
        }

        private void SetInt1(ref int x)
        {
            x=42;
        }

        private int GetInt1()
        {
            return 3;
        }

        [Fact]
        public void PassIntByValue()
        {
            var x = GetInt();
            SetInt(x);  //Csharp always uses pass by value so x won't change- when we change in the function to 42; it's only the param value that changes
            Assert.Equal(3,x);
        }

        private void SetInt(int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");  //passing by reference means that the value in the variable can be changed

            Assert.Equal("New Name",book1.Name);
            
        }

        private void GetBookSetName(ref Book book, string name) //passing by reference - where the variable is stored
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1",book1.Name);
            
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name",book1.Name);
            
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void StringBehaveLikeValueTypes()
        {
            string name = "Scott";
            var upper = MakeUpperCase(name);

            Assert.Equal("Scott",name);
            Assert.Equal("SCOTT", upper);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();    //returns a COPY of string in uppercase
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1",book1.Name);
            Assert.Equal("Book 2",book2.Name);
            Assert.NotSame(book1,book2);
            
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));  //tells if the values of both objects are pointing to the same reference
            
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
