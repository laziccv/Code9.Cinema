using Code9.Domain.Commands;
using Code9.Domain.Interfaces;
using Code9.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code9.Domain.Handlers
{
    public class AddNewCinemaHandler : IRequestHandler<AddNewCinemaCommand, Cinema>
    {
        private readonly ICinemaRepository _cinemaRepository;
        
        
        public AddNewCinemaHandler(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }
            
        public async Task<Cinema> Handle(AddNewCinemaCommand request, CancellationToken cancellationToken)
        {
            var cinema = new Cinema { City = request.City, Name = request.Name, Street = request.Street, NumberOfAuditoriums = request.NumberOfAuditoriums };
            return await _cinemaRepository.AddNewCinema(cinema);
        }
    }
}
