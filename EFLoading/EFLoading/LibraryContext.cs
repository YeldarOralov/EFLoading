namespace EFLoading
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LibraryContext : DbContext
    {
        public LibraryContext()
            : base("name=LibraryContext")
        {
        }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
    }
}