using Microsoft.EntityFrameworkCore;
using Shop.Domain.Core;
using Shop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Infrastructure.Data
{
    public class MarkdownRepository : IMarkdownRepository
    {
        private readonly OrderContext orderContext;

        public MarkdownRepository(DbContextOptions<OrderContext> connection)
        {
            orderContext = new OrderContext(connection);
        }

        public void Add(Markdown markdown)
        {
            orderContext.Markdowns.Add(markdown);
        }

        public void Del(int id)
        {
            Markdown markdown = orderContext.Markdowns.Find(id);
            if (markdown != null)
                orderContext.Markdowns.Remove(markdown);
        }

        public void Edit(Markdown markdown)
        {
            orderContext.Entry(markdown).State = EntityState.Modified;
        }

        public Markdown Get(int id)
        {
            return orderContext.Markdowns.Find(id);
        }

        public IEnumerable<Markdown> GetList()
        {
            return orderContext.Markdowns.ToList();
        }

        public void Save()
        {
            orderContext.SaveChanges();
        }
    }
}