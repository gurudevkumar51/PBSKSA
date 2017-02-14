using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminDal.Entity;
using AdminDal.DataAccess;

namespace AdminDal.Manager
{
    public class News_SchemesManager
    {
        News_SchemesRepository _objNewsReps = new News_SchemesRepository();
        AdminRepository _objAdminReps = new AdminRepository();
        public List<SchemeModel> GetScheme()
        {
            return _objNewsReps.GetScheme();
        }
      
        public int AddScheme(SchemeModel sch)
        {
            return _objNewsReps.AddScheme(sch);
        }
        public int DeleteScheme(int? id)
        {
            return _objNewsReps.DeleteScheme(id);
        }

        public int DefaultScheme(int? id)
        {
            return _objNewsReps.DefaultScheme(id);
        }
   
        public SchemeModel GetSchemeByID(int? id)
        {
            return _objNewsReps.GetSchemeByID(id);
        }
        public List<SchemeModel> GetSchemeByUserType(string Ut)
        {
            var objScheme= _objNewsReps.GetSchemeByUserType(Ut);
            var objAdmin = _objAdminReps.GetAllAdmin();
            return _objNewsReps.GetSchemeWithAdmin(objScheme, objAdmin);
        }
        public List<NewsModel> Getnews()
        {
            var objNews = _objNewsReps.GetNews();
            var objAdmin = _objAdminReps.GetAllAdmin();
            return _objNewsReps.GetNewsWithAdmin(objNews, objAdmin);
        }
        public int EditNews(NewsModel news)
        {
            return _objNewsReps.EditNews(news);
        }
        public int DeleteNews(int? id)
        {
            return _objNewsReps.DeleteNews(id);
        }
        public int AddNews(NewsModel news)
        {
            return _objNewsReps.AddNews(news);
        }
        public NewsModel GetnewsByID(int? id)
        {
            return _objNewsReps.GetnewsByID(id);
        }
        public int NewsStatusChange(int? id)
        {
            return _objNewsReps.NewsStatusChange(id);
        }
    }
}
