using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MoneyMindManager.Domain.Abstractions;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs;

namespace MoneyMindManager.Application.Services
{
    public class PersonService
    {
        private readonly IPersonRepository _repo;

        enum enMode { AddNew, Update };
        //private enMode Mode { get; set; } = enMode.AddNew;
        public PersonService(IPersonRepository personRepository)
        {
            this._repo = personRepository;
        }

        private Person _getPersonFromDTO(PersonDTO personDTO)
        {
            if (personDTO is null)
                return null;

            return new Person(personDTO.PersonID, personDTO.PersonName, personDTO.Address, personDTO.Email, personDTO.Phone, personDTO.AccountID, personDTO.Notes,
                personDTO.CreatedByUserID, personDTO.CreatedDate, personDTO.Receivable, personDTO.Payable);
        }
        private PersonDTO _getPersonDTOFromPerson(Person person)
        {
            if (person is null)
                return null;

            return new PersonDTO(person.PersonID, person.PersonName, person.Address, person.Email, person.Phone, person.AccountID, person.Notes,
                person.CreatedByUserID, person.CreatedDate, person.Receivable, person.Payable);
        }
        public async Task<PersonDTO> Add(PersonDTO personDTO,int currentUserID)
        {
            if (personDTO is null)
                return null;

            var person = _getPersonFromDTO(personDTO);

            person.CreatedByUserID = currentUserID;
            person.CreatedDate = DateTime.Now;

            
            int? id =  await _repo.Add(person);

            if (id is null)
                return null;

            person.PersonID = id;

            return _getPersonDTOFromPerson(person);

            //return (PersonID != null);
        }

        public async Task<bool> _Update(PersonDTO personDTO,int currentUserID)
        {
            if (personDTO is null)
                return false;

            var person = _getPersonFromDTO(personDTO);

            return await _repo.Update(person,currentUserID);
        }

        public async Task<PersonDTO> Save(PersonDTO personDTO,int currentUserID)
        {
            if (personDTO is null)
                return null;

            var mode = personDTO.PersonID != null ? enMode.Update : enMode.AddNew;

            //if (!clsUser.CheckLogedInUserPermissions_RaiseErrorEvent(clsUser.enPermissions.AddUpdatePerson,
            //    "ليس لديك صلاحية إضافة/تعديل شخص."))
            //    return false;

            switch (mode)
            {
                case enMode.AddNew:
                    {
                        //if (await _Add())
                        //{
                        //    Mode = enMode.Update;
                        //    await _RefeshCompositionObjects();
                        //    return true;
                        //}
                        //else
                        //    return false;

                        return await Add(personDTO,currentUserID);
                    }
                case enMode.Update:
                    if (await _Update(personDTO, currentUserID))
                    {
                        return personDTO;
                    }
                    else
                        return null;
            }

            return null;
        }
    }
}
