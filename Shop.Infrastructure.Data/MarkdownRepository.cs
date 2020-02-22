using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class MarkdownRepository : IMarkdownRepository
    {
        private readonly ShopContext _shopContext;

        public MarkdownRepository(DbContextOptions<ShopContext> connection)
        {
            _shopContext = new ShopContext(connection);
        }

        public void Add(Markdown markdown)
        {
            _shopContext.Markdowns.Add(markdown);
        }

        public void Delete(int id)
        {
            Markdown markdown = _shopContext.Markdowns.Find(id);
            if (markdown != null)
                _shopContext.Markdowns.Remove(markdown);
        }

        public void Edit(Markdown markdown)
        {
            _shopContext.Entry(markdown).State = EntityState.Modified;
        }

        public Markdown GetById(int id)
        {
            return _shopContext.Markdowns.Find(id);
        }

        public IEnumerable<Markdown> GetList()
        {
            return _shopContext.Markdowns.ToList();
        }

        public void Save()
        {
            _shopContext.SaveChanges();
        }
    }
}