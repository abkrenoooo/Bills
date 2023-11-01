using BLL.Helper;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.CategoryServices
{
    public interface ICategoryServices
    {
        public Task<ResponseBody<Category_VM>> AddCategoryAsync(Category_VM category);
        public Task<ResponseBody<Category_VM>> EditCategoryAsync(Category_VM category);
        public Task<ResponseBody<Category_VM>> DeleteCategoryAsync(int id);
        public Task<ResponseBody<Category_VM>> GetByCategoryAsync(string name);
        public Task<ResponseBody<Category_VM>> GetCategoryByIdAsync(int id);
        public Task<ResponseBody<Category_VM>> GetAllCategoryAsync();
        public Task<ResponseBody<Company_VM>> GetAllCompanyAsync();
        public Task<ResponseBody<Specy_VM>> GetAllSpecyAsync();
    }
}
