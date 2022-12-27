using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Platform.Service.Data;
using Platform.Service.Dtos;
using Platform.Service.Models;
using System;
using System.Collections.Generic;

namespace Platform.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatFormsController : ControllerBase
    {
        private readonly IPlatFormRepo _platFormRepository;
        private readonly IMapper _mapper;

        public PlatFormsController(IPlatFormRepo platFormRepository, IMapper mapper)
        {
            _platFormRepository = platFormRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatFormReadDto>> GetPlatForms()
        {
            Console.WriteLine("--> Getting Platforms...");

            var platFormsItens = _platFormRepository.GetAllPlatForms();

            return Ok(_mapper.Map<IEnumerable<PlatFormReadDto>>(platFormsItens));
        }

        [HttpGet("{id}", Name = "GetPlatFormById")]
        public ActionResult<PlatFormReadDto> GetPlatFormById(int id)
        {
            var platFormItem = _platFormRepository.GetPlatFormId(id);

            if (platFormItem != null)
            {
                return Ok(_mapper.Map<PlatFormReadDto>(platFormItem));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<PlatFormReadDto> CreatePlatForm(PlatFormCreateDto platFormCreateDto)
        {
            var platFormCreate = _mapper.Map<PlatForm>(platFormCreateDto);

            _platFormRepository.CreatePlatForm(platFormCreate);
            _platFormRepository.SaveChanges();

            var platFormReadDto = _mapper.Map<PlatFormReadDto>(platFormCreate);

            return CreatedAtRoute(nameof(GetPlatFormById), new { Id = platFormReadDto.Id }, platFormReadDto);

        }

    }
}
