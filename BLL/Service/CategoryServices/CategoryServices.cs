using BLL.Helper;
using DAL.Repository.CategoryRepository;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.CategoryServices
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<ResponseBody<Category_VM>> AddCategoryAsync(Category_VM category)
        {
            ResponseBody<Category_VM> response = new ResponseBody<Category_VM>();
            var categoryName = await _categoryRepository.GetByCategoryAsync(category.ItemName);
            if (categoryName is not null && category.CategoryId != categoryName.CategoryId)
            {
                response.message = "CATEGORY NAME has already existed before";
                response.data = new List<Category_VM>() { category };
                response.status_code = 1;
            }
            else if (await _categoryRepository.AddCategoryAsync(category) is not null)
            {
                response.message = "CATEGORY has been Added successfully";
                response.data = new List<Category_VM>() { await _categoryRepository.GetByCategoryAsync(category.ItemName) };
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = new List<Category_VM>() { category };
                response.status_code = -1;
            }
            return response;
        }

        public async Task<ResponseBody<Category_VM>> DeleteCategoryAsync(int id)
        {
            ResponseBody<Category_VM> response = new ResponseBody<Category_VM>();
            var res = await _categoryRepository.DeleteCategoryAsync(id);
            if (!res)
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = 1;
            }
            else
            {
                response.message = "CATEGORY has been Deleted successfully";
                response.data = null;
                response.status_code = 0;
            }
            return response;
        }
        public async Task<ResponseBody<Category_VM>> EditCategoryAsync(Category_VM category)
        {
            ResponseBody<Category_VM> response = new ResponseBody<Category_VM>();
            var categoryName = await _categoryRepository.GetByCategoryAsync(category.ItemName.ToString());
            if (categoryName is not null && category.CategoryId != categoryName.CategoryId)
            {
                response.message = "CATEGORY NAME has already existed before";
                response.data = new List<Category_VM>() { category };
                response.status_code = 1;
            }
            else if (await _categoryRepository.EditCategoryAsync(category) is not null)
            {
                response.message = "CATEGORY has been Edit successfully";
                response.data = new List<Category_VM>() { category };
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = response.data = new List<Category_VM>() { category };
                response.status_code = -1;
            }
            return response;
        }
        public async Task<ResponseBody<Category_VM>> GetAllCategoryAsync()
        {
            ResponseBody<Category_VM> response = new ResponseBody<Category_VM>();
            if (await _categoryRepository.GetAllCategoryAsync() is not null)
            {
                response.message = null;
                response.data = await _categoryRepository.GetAllCategoryAsync();
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = -1;
            }
            return response;
        }

        public async Task<ResponseBody<Category_VM>> GetByCategoryAsync(string name)
        {
            ResponseBody<Category_VM> response = new ResponseBody<Category_VM>();
            if (await _categoryRepository.GetByCategoryAsync(name) is not null)
            {
                response.message = null;
                response.data = new List<Category_VM>() { await _categoryRepository.GetByCategoryAsync(name) };
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = -1;
            }
            return response;
        }
        public async Task<ResponseBody<Category_VM>> GetCategoryByIdAsync(int id)
        {
            ResponseBody<Category_VM> response = new ResponseBody<Category_VM>();
            if (await _categoryRepository.GetCategoryByIdAsync(id) is not null)
            {
                response.message = null;
                response.data = new List<Category_VM>() { await _categoryRepository.GetCategoryByIdAsync(id) };
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = -1;
            }
            return response;
        }
        public async Task<ResponseBody<Company_VM>> GetAllCompanyAsync()
        {
            ResponseBody<Company_VM> response = new ResponseBody<Company_VM>();
            if (await _categoryRepository.GetAllCompanyAsync() is not null)
            {
                response.message = null;
                response.data = await _categoryRepository.GetAllCompanyAsync();
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = -1;
            }
            return response;
        }
        public async Task<ResponseBody<Specy_VM>> GetAllSpecyAsync()
        {
            ResponseBody<Specy_VM> response = new ResponseBody<Specy_VM>();
            if (await _categoryRepository.GetAllSpecyAsync() is not null)
            {
                response.message = null;
                response.data = await _categoryRepository.GetAllSpecyAsync();
                response.status_code = 0;
            }
            else
            {
                response.message = "Unknown error";
                response.data = null;
                response.status_code = -1;
            }
            return response;
        }
    }
}
