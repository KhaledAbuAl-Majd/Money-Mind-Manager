using System;
using System.Linq;
using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Handlers;
using MoneyMindManager.Application.Abstractions.Mappers;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Shared.DTOs;
using MoneyMindManager.Shared.DTOs.Person;
namespace MoneyMindManager.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonMapper _personMapper;
        private readonly IResultFactory _resultFactory;
        private readonly IAuthorizationService _authorizationService;
        public PersonService(IPersonRepository personRepository, IPersonMapper personMapper, IResultFactory resultFactory, IAuthorizationService authorizationService)
        {
            this._personRepository = personRepository;
            this._personMapper = personMapper;
            this._resultFactory = resultFactory;
            this._authorizationService = authorizationService;
        }

        public async Task<IResult<PersonDTO>> Add(PersonDTO personDTO, int currentUserID)
        {
            var handler = _resultFactory.Create<PersonDTO>();

            if (personDTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.AddUpdatePerson);
            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية إضافة/تعديل شخص.");

            var person = _personMapper.DTOToEntity(personDTO);

            person.CreatedByUserID = currentUserID;
            person.CreatedDate = DateTime.Now;

            var result = await _personRepository.Add(person);

            if (result is null || result.Data is null)
                return handler.Failure("failed to add person!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            int id = Convert.ToInt32(result.Data);

            person.PersonID = id;

            return handler.Success(_personMapper.EntityToDTO(person));

        }

        public async Task<IResult<bool>> Update(PersonDTO personDTO, int currentUserID)
        {
            var handler = _resultFactory.Create<bool>();

            if (personDTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.AddUpdatePerson);
            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية إضافة/تعديل شخص.");

            var person = _personMapper.DTOToEntity(personDTO);

            var result = await _personRepository.Update(person, currentUserID);

            if (result is null)
                return handler.Failure("failed to update person!");

            return result;
        }

        public async Task<IResult<PersonDTO>> Get(int personID, int currentUserID)
        {
            var result = await _personRepository.Get(personID, currentUserID);

            var handler = _resultFactory.Create<PersonDTO>();


            if (result is null || result.Data is null)
                return handler.Failure("failed to get person!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            var personDTO = _personMapper.EntityToDTO(result.Data);
            return handler.Success(personDTO);
        }

        public async Task<IResult<bool>> Delete(int personID, int currentUserID)
        {
            var handler = _resultFactory.Create<bool>();

            var accessResult = await _authorizationService.CheckAccess(currentUserID, enPermissions.DeletePerson);
            if (accessResult is null)
                return handler.Failure("failed to check permissions!");

            if (!accessResult.IsSuccess)
                return handler.Failure(accessResult.ErrorMessage);

            if (!accessResult.Data)
                return handler.Failure("ليس لديك صلاحية حذف شخص.");

            var result = await _personRepository.Delete(personID, currentUserID);

            if (result is null)
                return handler.Failure("failed to delete person!");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            return result;
        }

        public async Task<IResult<bool>> IsExist(int personID)
        {
            var handler = _resultFactory.Create<bool>();

            var result = await _personRepository.IsExist(personID);

            if (result is null)
                return handler.Failure("failed to check person existence");

            return result;
        }

        public async Task<IResult<PagedResultDTO<PersonDTO>>> GetAll(PersonFilterDTO personFilterDTO, int currentUserID)
        {
            var handler = _resultFactory.Create<PagedResultDTO<PersonDTO>>();
            if (personFilterDTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var personSearchCriteria = _personMapper.PersonFilterDTOTOPersonSearchCriteria(personFilterDTO);
            personSearchCriteria.rowsPerPage = 15;
            var result = await _personRepository.GetAll(personSearchCriteria, currentUserID);

            if (result is null || result.Data is null)
                return handler.Failure("failed to get all people");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            PagedResultDTO<PersonDTO> returnResult = new PagedResultDTO<PersonDTO>(result.Data.Data.Select(entity => _personMapper.EntityToDTO(entity)),
                result.Data.TotalPages, result.Data.TotalRecords);

            return handler.Success(returnResult);
        }

        public async Task<IResult<PagedResultDTO<PersonDTO>>> GetAllForSelectOne(PersonSelectFilterDTO personFilterDTO, int currentUserID)
        {
            var handler = _resultFactory.Create<PagedResultDTO<PersonDTO>>();
            if (personFilterDTO is null)
                return handler.Failure("البيانات المرسلة غير صالحة");

            var personSearchCriteria = _personMapper.PersonSelectFilterDTOTOPersonSelectSearchCriteria(personFilterDTO);
            personSearchCriteria.rowsPerPage = 15;
            var result = await _personRepository.GetAllForSelectOne(personSearchCriteria, currentUserID);

            if (result is null || result.Data is null)
                return handler.Failure("failed to get all people");

            if (!result.IsSuccess)
                return handler.Failure(result.ErrorMessage);

            PagedResultDTO<PersonDTO> returnResult = new PagedResultDTO<PersonDTO>(result.Data.Data.Select(entity => _personMapper.EntityToDTO(entity)),
                result.Data.TotalPages, result.Data.TotalRecords);

            return handler.Success(returnResult);
        }
    }
}
