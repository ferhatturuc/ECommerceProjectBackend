using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            IResult result = BusinessRules.Run(
                CheckIfCategoryNameExist(category.CategoryName));

            if (result != null)
            {
                return result;
            }
            _categoryDal.Add(category);

            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
        }

        public IResult Update(Category category)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfCategoryNameExist(string categoryname)
        {
            var result = _categoryDal.GetAll(c => c.CategoryName == categoryname).Any();
            if (result == true)
            {
                return new ErrorResult(Messages.CategoryNameAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
