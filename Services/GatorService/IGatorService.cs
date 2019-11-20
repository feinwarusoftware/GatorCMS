using System.Collections.Generic;
using GatorCms.Models;

namespace GatorCMS.Services.Interfaces
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