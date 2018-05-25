using System;
using LogicLayer.DTO;
using LogicLayer.Interfaces;
using Data.Interfaces;
using AutoMapper;
using Data.Entities;
using System.Collections.Generic;
using LogicLayer.Infrastructure;
using System.Threading.Tasks;

namespace LogicLayer.Services
{
    public class RubricService : IRubricService
    {
        IUnitOfWork Database { get; set; }

        public RubricService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));


            Database = unitOfWork;
        }

        public void CreateRubric(RubricDTO rubricDTO)
        {
            Database.Rubrics.Create(Mapper.Map<RubricDTO, Rubric>(rubricDTO));
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void EditRubric(RubricDTO rubricDTO)
        {
            Rubric rubric = Database.Rubrics.Get(rubricDTO.Id);

            rubric.Name = rubricDTO.Name;

            Database.Rubrics.Update(rubric);
            Database.Save();
        }

        public void RemoveRubric(RubricDTO rubricDTO)
        {
            Database.Rubrics.Delete(rubricDTO.Id);
            Database.Save();
        }

        public IEnumerable<RubricDTO> GetAllRubrics()
        {
            return Mapper.Map<IEnumerable<Rubric>, List<RubricDTO>>(Database.Rubrics.GetAll());
        }

        public RubricDTO GetRubricById(int id)
        {
            return Mapper.Map<Rubric, RubricDTO>(Database.Rubrics.Get(id));
        }

        public void RemoveRubric(int id)
        {
            Database.Rubrics.Delete(id);
            Database.Save();
        }
    }
}
