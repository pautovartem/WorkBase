using System;
using LogicLayer.DTO;
using LogicLayer.Interfaces;
using Data.Interfaces;
using AutoMapper;
using Data.Entities;
using System.Collections.Generic;
using LogicLayer.Infrastructure;

namespace LogicLayer.Services
{
    public class RubricService : IRubricService
    {
        IUnitOfWork Database { get; set; }

        public RubricService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
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
            Database.Rubrics.Update(Mapper.Map<RubricDTO, Rubric>(rubricDTO));
            Database.Save();
        }

        public void RemoveRubric(RubricDTO rubricDTO)
        {
            Rubric rubric = Mapper.Map<RubricDTO, Rubric>(rubricDTO);
            Database.Rubrics.Delete(rubric.Id);
            Database.Save();
        }

        public IEnumerable<RubricDTO> GetAllRubrics()
        {
            return Mapper.Map<IEnumerable<Rubric>, List<RubricDTO>>(Database.Rubrics.GetAll());
        }
    }
}
