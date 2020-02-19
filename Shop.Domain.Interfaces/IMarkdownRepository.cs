using Shop.Domain.Core;
using System.Collections.Generic;

namespace Shop.Domain.Interfaces
{
    public interface IMarkdownRepository
    {
        void Add(Markdown product);
        void Del(int id);
        void Edit(Markdown product);
        Markdown Get(int id);
        IEnumerable<Markdown> GetList();
        void Save();
    }
}