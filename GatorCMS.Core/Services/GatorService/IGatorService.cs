using System.Collections.Generic;
using GatorCMS.Core.Models;

namespace GatorCMS.Core.Services.GatorService
{
    public interface IGatorService
    {
         List<GatorBoii> Get();
         GatorBoii Get(string id);
         GatorBoii Create(GatorBoii book);
         void Update(string id, GatorBoii bookIn);
         void Remove(GatorBoii bookIn,string id);
    }
}