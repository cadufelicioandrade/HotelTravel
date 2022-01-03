using AutoMapper;
using FluentResults;
using HotelTravelMemories.API.DTO.Checkout;
using HotelTravelMemories.Data.Interfaces;
using HotelTravelMemories.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTravelMemories.API.Services
{
    public class CheckoutService
    {
        private ICheckoutRepository _checkoutRepository;
        private IMapper _mapper;

        public CheckoutService(ICheckoutRepository checkoutRepository, IMapper mapper)
        {
            _checkoutRepository = checkoutRepository;
            _mapper = mapper;
        }

        public List<ReadCheckoutDto> GetAll()
        {
            return _mapper.Map<List<ReadCheckoutDto>>(_checkoutRepository.GetAll());
        }

        public ReadCheckoutDto GetById(int id)
        {
            Checkout checkout = _checkoutRepository.GetById(id);
            if (checkout is null)
                return null;
            return _mapper.Map<ReadCheckoutDto>(checkout);
        }

        public ReadCheckoutDto Create(CreateCheckoutDto createCheckout)
        {
            Checkout checkout = _mapper.Map<Checkout>(createCheckout);
            _checkoutRepository.Add(checkout);
            return _mapper.Map<ReadCheckoutDto>(checkout);
        }

        public Result Update(int id, UpdateCheckoutDto updateCheckout)
        {
            Checkout checkout = _checkoutRepository.GetById(id);
            if (checkout is null)
                return Result.Fail("Conta não localizada.");

            _mapper.Map(updateCheckout, checkout);
            _checkoutRepository.Update(checkout);
            return Result.Ok();
        }

        public Result Delete(int id)
        {
            if(!_checkoutRepository.Delete(id))
                return Result.Fail("Conta não localizada.");

            return Result.Ok();
        }
    }
}
