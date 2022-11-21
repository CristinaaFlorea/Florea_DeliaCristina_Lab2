using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Florea_DeliaCristina_Lab2.Data;
using Florea_DeliaCristina_Lab2.Models;

namespace Florea_DeliaCristina_Lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Florea_DeliaCristina_Lab2.Data.Florea_DeliaCristina_Lab2Context _context;

        public IndexModel(Florea_DeliaCristina_Lab2.Data.Florea_DeliaCristina_Lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;
        public BookData BookD { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }
        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }
        public string CurrentFilter { get; set; }


        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            BookD = new BookData();

            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            AuthorSort = String.IsNullOrEmpty(sortOrder) ? "author_desc" : "";

            CurrentFilter = searchString;

            BookD.Books = await _context.Book
               .Include(b => b.Publisher)
               .Include(b => b.BookCategories)
               .ThenInclude(b => b.Category)
               .Include(b => b.Author)
               .AsNoTracking()
               .OrderBy(b => b.Title)
               .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                BookD.Books = BookD.Books.Where(s => s.Authors.FirstName.Contains(searchString)
                                                //daca scriu author imi da eroare
               || s.Authors.LastName.Contains(searchString) // dacda scriu author imi da eroare
               || s.Title.Contains(searchString));

                if (id != null)
                {
                    BookID = id.Value;
                    Book book = BookD.Books
                    .Where(i => i.ID == id.Value).Single();
                    BookD.Categories = book.BookCategories.Select(s => s.Category);
                }

                switch (sortOrder)
                {
                    case "title_desc":
                        BookD.Books = BookD.Books.OrderByDescending(s =>
                       s.Title);
                        break;
                    case "author_desc":
                        BookD.Books = BookD.Books.OrderByDescending(s =>
                       s.Authors.FullName); // daca scriu Author imi da eroare
                        break;
                }
            }
        }

    }
}
