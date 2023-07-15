using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq.Expressions;

namespace API.Controllers
{
    public class ShipsController : BaseController
    {
        private readonly IShipRepository _shipRepository;

        public ShipsController(ILogger<ShipsController> logger, IShipRepository shipRepository) : base(logger)
        {
            _shipRepository = shipRepository;
        }

        [HttpGet()]
        /// <summary>
        /// Returns a list of Ships based on filters
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Ship list</returns>
        public async Task<IActionResult> ListAll()
        {
            try
            {
                var ships = await _shipRepository.ListAll();

                return Ok(ships);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        /// <summary>
        /// Returns a Ship based on its identification
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ship info</returns>
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var ship = await _shipRepository.GetById(id);

                return Ok(ship);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        /// <summary>
        /// Add a new Ship
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Execution status</returns>
        public IActionResult Create(Ship ship)
        {
            try
            {
                _shipRepository.Create(ship);

                return Ok(ship);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut()]
        /// <summary>
        /// Update a Ship
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Execution status</returns>
        public async Task<IActionResult> Update(Ship ship)
        {
            try
            {
                 await _shipRepository.Update(ship);

                return Ok(ship);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        /// <summary>
        /// Remove a Ship
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Execution status</returns>
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _shipRepository.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }
    }
}
