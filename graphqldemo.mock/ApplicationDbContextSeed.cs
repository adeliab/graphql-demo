using graphqldemo.core.Models;
using graphqldemo.data;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace graphqldemo.mock
{
	public static class ApplicationDbContextSeed
	{
		public static void Initialize(IServiceScope scope)
		{
			ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

			InitializeAuthors(context);

			context.SaveChanges();
		}

		private static void InitializeAuthors(ApplicationDbContext context)
		{
			for (int i = 1; i <= 5; i++)
			{
				Author author = new Author
				{
					Id = i,
					Name = $"Author {i}"
				};

				InitializeBooksForAuthor(author);

				context.Authors.Add(author);
			}
		}

		private static void InitializeBooksForAuthor(Author author)
		{
			int bookId = 0;

			for (int i = 1; i <= 100; i++)
			{
				bookId++;

				Book book = new Book
				{
					Id = bookId,
					Name = $"Book {i} of {author.Name}",
					Published = bookId % 2 == 0 ? true : false,
					Genre = $"Genre of {author.Name}"
				};

				author.Books.Add(book);
			}
		}
	}
}
