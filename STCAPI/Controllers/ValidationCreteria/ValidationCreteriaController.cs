using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STAAPI.Infrastructure.Repository.GenericRepository;
using STCAPI.Core.Entities.ValidationCreteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STCAPI.Controllers.ValidationCreteria
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValidationCreteriaController : ControllerBase
    {
        private readonly IGenericRepository<ValidationCreterialReportStream, int> _IValidationCreteriaRepository;

        public ValidationCreteriaController(IGenericRepository<ValidationCreterialReportStream, int> iValidationCreteriaRepository)
        {
            _IValidationCreteriaRepository = iValidationCreteriaRepository;
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> Create(ValidationCreterialReportStream model)
        {
            model.IsDeleted = false;
            model.CreatedDate = DateTime.Now;

            var response = await _IValidationCreteriaRepository.CreateEntity(new List<ValidationCreterialReportStream>() { model }.ToArray());

            return Ok(response);
        }


        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> Update(ValidationCreterialReportStream model)
        {
            var responseModel = (await _IValidationCreteriaRepository.GetAllEntities(x => x.Id == model.Id));

            responseModel.TEntities.ToList().ForEach(data =>
            {
                data.ReportName = model.ReportName;
                data.StreamName = model.StreamName;
                data.ApiURL = model.ApiURL;
                data.IsActive = model.IsActive;
                data.UpdatedDate = DateTime.Now;
                data.UpdatedBy = model.CreatedBy;
            });


            var response = await _IValidationCreteriaRepository.UpdateEntity(responseModel.TEntities.First());

            return Ok(response);
        }

        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetAll()
        {
            var responseModels = await _IValidationCreteriaRepository.GetAllEntities(x=>!x.IsDeleted);
            return Ok(responseModels);
        }

        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var responseModel = await _IValidationCreteriaRepository.GetAllEntities(x => x.Id == id && x.IsActive);
            return Ok(responseModel.TEntities.FirstOrDefault());
        }


        [HttpDelete]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> Delete(int id)
        {
            var responseModel = await _IValidationCreteriaRepository.GetAllEntities(x => x.Id == id);
            responseModel.TEntities.ToList().ForEach(data =>
            {
                data.IsDeleted = true;
                data.UpdatedDate=DateTime.Now;
                data.UpdatedBy = data.CreatedBy;
            });

            var response = await _IValidationCreteriaRepository.UpdateEntity(responseModel.TEntities.First());
            return Ok(response);
        }
    }
}
