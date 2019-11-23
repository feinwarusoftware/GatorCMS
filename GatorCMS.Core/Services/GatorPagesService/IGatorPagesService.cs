using System.Collections.Generic;
using GatorCMS.Core.Models.Pages;

namespace GatorCMS.Core.Services.GatorPagesService
{
    public interface IGatorPagesService
    {
         public List<BasePage> GetAllPages();
    }
}