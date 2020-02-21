using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class MarkdownRepository : IMarkdownRepository
    {
        private readonly ShopContext shopContext;

        public MarkdownRepository(DbContextOptions<ShopContext> connection)
        {
            shopContext = new ShopContext(connection);
        }

        public void Add(Markdown markdown)
        {
            shopContext.Markdowns.Add(markdown);
        }

        public void Delete(int id)
        {
            Markdown markdown = shopContext.Markdowns.Find(id);
            if (markdown != null)
                shopContext.Markdowns.Remove(markdown);
        }

        public void Edit(Markdown markdown)
        {
            shopContext.Entry(markdown).State = EntityState.Modified;
        }

        public Markdown Get(int id)
        {
            return shopContext.Markdowns.Find(id);
        }

        public IEnumerable<Markdown> GetList()
        {
            return shopContext.Markdowns.ToList();
        }

        public void Save()
        {
            shopContext.SaveChanges();
        }
    }
}