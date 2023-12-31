﻿using HealthClinic_API.Domains;
using HealthClinic_API.Interfaces;
using HealthClinic_API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HealthClinic_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository;
        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }

        //**************************** ATUALIZAR PELO ID
        /// <summary>
        /// Endpoint que aciona o método ATUALIZAR
        /// </summary>
        /// <param name="id"></param>
        /// <param name="medico"></param>
        /// <returns> Lista com objeto atualizado </returns>
        [HttpPut("{id}")]
        //[Authorize(Roles = "Administrador")]

        public IActionResult Put(Guid id, Medico medico)
        {
            try
            {
                _medicoRepository.Atualizar(id, medico);
                return StatusCode(200);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        //********************* BUSCAR POR ID
        /// <summary>
        /// Endpoint que aciona o método BuscarPorId
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Retorna o objeto com o respectivo ID </returns>
        [HttpGet("{id}")]
        //[Authorize(Roles = "Administrador")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_medicoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        //********************* CADASTRAR
        /// <summary>
        /// EndPoint que aciona o metodo Cadastrar
        /// </summary>
        /// <param name="medico"></param>
        /// <returns> Cadastra um novo objeto na lista </returns>
        [HttpPost]
        //[Authorize(Roles = "Administrador")]

        public IActionResult Post(Medico medico)
        {
            try
            {
                if (medico != null)
                {
                    _medicoRepository.Cadastrar(medico);

                    return StatusCode(201);
                }
                return Ok("Medico não foi inserido corretamente");
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        //*************************** DELETAR PELO ID
        /// <summary>
        /// EndPoint que aciona o método Deletar
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Retorna a lista com os objetos cadastrados </returns>
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _medicoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        //********************* LISTAR
        /// <summary>
        /// Endpoint que aciona o método LISTAR
        /// </summary>
        /// <returns> lista de objetos </returns>
        [HttpGet]
        
        public IActionResult Get()
        {
            try
            {
                return Ok(_medicoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        // ********************** LISTAR POR ESPECIALIDADE
        /// <summary>
        /// Endpoint que aciona o método ListarPorEspecialidade
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Retorna a lista de objetos </returns>
        [HttpGet("Especialidade")]
        public IActionResult ListarPorEspecialidade(Guid id)
        {
            try
            {
                List<Medico> lista = _medicoRepository.ListarPorEspecialidade(id);
                return Ok(lista);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
