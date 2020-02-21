using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class MarkdownRepository : IMarkdownRepository
    {
        private readonly OrderContext _orderContext;

        public MarkdownRepository(DbContextOptions<OrderContext> connection)
        {
            _orderContext = new OrderContext(connection);
        }

        public void Add(Markdown markdown)
        {
            _orderContext.Markdowns.Add(markdown);
        }

        public void Del(int id)
        {
            Markdown markdown = _orderContext.Markdowns.Find(id);
            if (markdown != null)
                _orderContext.Markdowns.Remove(markdown);
        }

        public void Edit(Markdown markdown)
        {
            _orderContext.Entry(markdown).State = EntityState.Modified;
        }

        public Markdown Get(int id)
        {
            return _orderContext.Markdowns.Find(id);
        }

        public IEnumerable<Markdown> GetList()
        {
            return _orderContext.Markdowns.ToList();
        }

        public void Save()
        {
            _orderContext.SaveChanges();
        }
    }
}