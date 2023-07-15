using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Models.Ship;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq.Expressions;

namespace API.Controllers
{
    public class ShipsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IShipRepository _shipRepository;

        public ShipsController(IMapper mapper, 
            ILogger<ShipsController> logger, 
            IShipRepository shipRepository) : base(logger)
        {
            _mapper = mapper;
            _shipRepository = shipRepository;
        }


        /// <summary>
        /// Returns a list of all Ships
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A list of ships</returns>
        /// <response code="200">Return object **ShipListResponse**.</response>
        /// <response code="400">Return object **ErrorResponse**.</response>
        [HttpGet()]
        [ProducesResponseType(typeof(ShipListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ListAll()
        {
            try
            {
                var ships = await _shipRepository.ListAll();

                return Ok(new ShipListResponse
                {
                    Ships = _mapper.Map<IEnumerable<Ship>, List<ShipListItemResponse>>(ships),
                    Total = ships.Count()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex));
            }
        }


        /// <summary>
        /// Returns a Ship based on its Guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Single ship information</returns>
        /// <response code="200">Return object **ShipGetResponse**.</response>
        /// <response code="400">Return object **ErrorResponse**.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ShipGetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var ship = await _shipRepository.GetById(id);

                return Ok(_mapper.Map<Ship, ShipGetResponse>(ship));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex));
            }
        }


        /// <summary>
        /// Add a new Ship
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Execution status</returns>
        /// <response code="200">Return Status 200</response>
        /// <response code="400">Return object **Result**</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public IActionResult Create(Ship ship)
        {
            try
            {
                _shipRepository.Create(ship);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex));
            }
        }


        /// <summary>
        /// Update a Ship
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Execution status</returns>
        /// <response code="200">Return Status 200</response>
        /// <response code="400">Return object **Result**</response>
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Ship ship)
        {
            try
            {
                 await _shipRepository.Update(ship);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex));
            }
        }

        /// <summary>
        /// Remove a Ship
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Execution status</returns>
        /// <response code="200">Return Status 200</response>
        /// <response code="400">Return object **Result**</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _shipRepository.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse(ex));
            }
        }
    }
}
