using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            var result = BusinessRules.Run(CheckIfEmailIsAlreadyRegistered(user.Email));
            if (!result.Success) return result;

            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }


        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(result);
        }


        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(u => u.Id == id);
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            return new SuccessDataResult<User>(result);
        }


        public IDataResult<UserDto> GetDtoById(int id)
        {
            var result = _userDal.GetDto(u => u.Id == id);
            return new SuccessDataResult<UserDto>(result);
        }


        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(result);
        }


        public IResult UpdateFirstAndLastName(UpdateFirstAndLastNameDto updateFirstAndLastNameDto)
        {
            var result = _userDal.Get(u => u.Id == updateFirstAndLastNameDto.Id);
            result.FirstName = updateFirstAndLastNameDto.FirstName;
            result.LastName = updateFirstAndLastNameDto.LastName;
            _userDal.Update(result);
            return new SuccessResult(Messages.FirstAndLastNameUpdated);
        }


        public IResult UpdateEmail(UpdateEmailDto updateEmailDto)
        {
            var rulesResult = BusinessRules.Run(CheckIfEmailIsAlreadyRegistered(updateEmailDto.Email));
            if (!rulesResult.Success) return rulesResult;

            var result = _userDal.Get(u => u.Id == updateEmailDto.Id);
            result.Email = updateEmailDto.Email;
            _userDal.Update(result);
            return new SuccessResult(Messages.EmailUpdated);
        }


        private IResult CheckIfEmailIsAlreadyRegistered(string email)
        {
            var userResult = _userDal.Get(u => u.Email == email);
            if (userResult != null) return new ErrorResult(Messages.EmailIsAlreadyRegistered);

            return new SuccessResult();
        }
    }
}
