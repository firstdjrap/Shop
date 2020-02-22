using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IMarkdownRepository
    {
        void Add(Markdown markdown);
        void Delete(int id);
        void Edit(Markdown markdown);
        Markdown GetById(int id);
        IEnumerable<Markdown> GetList();
        void Save();
    }
}