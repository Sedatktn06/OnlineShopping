﻿using OnlineShopping.Order.Apllication.Features.CQRS.Results.AddressResults;
using OnlineShopping.Order.Apllication.Interfaces;
using OnlineShopping.Order.Apllication.Models.AddressModels;
using OnlineShopping.Order.Domain.Entities;

namespace OnlineShopping.Order.Apllication.Features.CQRS.Queries.AddressQueries;

public class GetAddressByIdQuery
{
    public int Id { get; set; }

    public GetAddressByIdQuery(int id)
    {
        Id = id;
    }
}

public class GetAddressByIdQueryHandler
{
    private readonly IRepository<Address> _addressRepository;

    public GetAddressByIdQueryHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<AddressModel> HandleAsync(GetAddressByIdQuery query)
    {
        var address = await _addressRepository.GetByIdAsync(query.Id);
        return address.ToModel();
    }
}
