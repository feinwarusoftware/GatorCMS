using System.Collections.Generic;
using GatorCMS.Core.Models;

namespace GatorCMS.Core.Services.LemonService
{
    public interface ILemonService
    {
         List<Lemon> Get();
         Lemon Get(string id);
         Lemon Create(Lemon lemon);
         void Update(string id, Lemon lemon);
         void Remove(string id);
    }
}
