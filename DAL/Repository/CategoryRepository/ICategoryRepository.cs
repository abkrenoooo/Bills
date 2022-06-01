using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.CategoryRepository
{
    public interface ICategoryRepository
    {
        public Task<Category_VM> AddCategoryAsync(Category_VM category);
        public Task<Category_VM> EditCategoryAsync(Category_VM category);
        public Task<bool> DeleteCategoryAsync(int id);
        public Task<Category_VM> GetByCategoryAsync(string name);
        public Task<List<Category_VM>> GetAllCategoryAsync();
        public Task<List<Company_VM>> GetAllCompanyAsync();
        public Task<List<Specy_VM>> GetAllSpecyAsync();
        public Task<Category_VM> GetCategoryByIdAsync(int id);
    }
}
