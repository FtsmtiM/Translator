using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Translator.Data;
using Translator.Dtos;
using Translator.Models;

namespace Translator.Controllers
{
    [Route("api/translate")]
    [ApiController]
    public class TranslateController : ControllerBase
    {
        private readonly ITranslatorRepo _repository;

        public IMapper _mapper { get; }

        public TranslateController(ITranslatorRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TranslateReadDto>> GetAllTranslations()
        {
            var translateLists = _repository.GetAllTranslators();
            return Ok(_mapper.Map<IEnumerable<TranslateReadDto>>(translateLists));
        }

        //GET api/translate/1
        [HttpGet("{id}", Name = "GetTranslatebyId")]
        public ActionResult<TranslateReadDto> GetTranslatebyId(int id)
        {
            var translateItem = _repository.GetTranslateById(id);
            if (translateItem != null)
            {
                return Ok(_mapper.Map<TranslateReadDto>(translateItem));
            }
            return NotFound();
        }

        //Post api/translate
        [HttpPost]
        public ActionResult<TranslateReadDto> CreateTranslate(TranslateCreateDto translate)
        {
            var translateModel = _mapper.Map<Translate>(translate);
            _repository.CreateTranslate(translateModel);
            _repository.SaveChanged();
            //mapping from a model data to a new object
            var tranReadItem = _mapper.Map<TranslateReadDto>(translateModel);

            return CreatedAtRoute(nameof(GetTranslatebyId), new { Id = tranReadItem.Id }, tranReadItem);
            //return Ok(tranReadItem);
        }

        //PUT api/translate/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTranslate(int id, TranslateUpdateDto translateUpdateDto)
        {
            var translateModelItemfromRepo = _repository.GetTranslateById(id);

            if (translateModelItemfromRepo == null)
            {
                return NotFound();
            }
            //mapping from a dto data to an existing repo data(this also updates the database)
            _mapper.Map(translateUpdateDto, translateModelItemfromRepo);
            //just in case for future use but currently this code does nothing
            _repository.UpdateTranslate(translateModelItemfromRepo);
            _repository.SaveChanged();

            return NoContent();
        }

        //PATCH api/translate/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialTranslateUpdate(int id, JsonPatchDocument<TranslateUpdateDto> patchTransDoc)
        {
            var transModelRepo = _repository.GetTranslateById(id);

            if(transModelRepo == null)
            {
                return NoContent();
            }

            var translateToPatch = _mapper.Map<TranslateUpdateDto>(transModelRepo);
            patchTransDoc.ApplyTo(translateToPatch, ModelState);

            if (!TryValidateModel(translateToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(translateToPatch, transModelRepo);
            _repository.UpdateTranslate(transModelRepo);
            _repository.SaveChanged();

            return NoContent();
        }

        //DELETE api/translate/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTranslate(int id)
        {
            var translateRepo = _repository.GetTranslateById(id);

            if(translateRepo == null)
            {
                return NoContent();
            }
            _repository.DeleteTranslate(translateRepo);
            _repository.SaveChanged();

            return NoContent();
        }
    }

    
}
