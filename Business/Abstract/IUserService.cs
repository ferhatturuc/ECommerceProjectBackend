using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IDataResult<User> GetByEmail(string email);
        IDataResult<UserDto> GetDtoById(int id);

        IDataResult<List<OperationClaim>> GetClaims(User user);

        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);

        IResult UpdateFirstAndLastName(UpdateFirstAndLastNameDto updateFirstAndLastNameDto);
        IResult UpdateEmail(UpdateEmailDto updateEmailDto);
    }
}
