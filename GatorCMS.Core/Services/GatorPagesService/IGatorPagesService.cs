using System;
using System.Collections.Generic;
using GatorCMS.Core.Models.Pages;
using MongoDB.Bson;

namespace GatorCMS.Core.Services.GatorPagesService {
    public interface IGatorPagesService {
        List<T> GetAllPages<T> ();
        T GetPage<T> (Guid id) where T : IBasePage;
        T CreatePage<T>(T page);
        List<T> GetPages<T>() where T : IBasePage;
        void UpdatePage<T> (string id, T pageIn);
        void RemovePage<T> (string id);
        void RemovePage<T> (T pageIn);
    }
}