﻿using Domain.Entities.Abstractions;
using Domain.Entities.Apartments.Enums;
using Domain.Entities.Apartments.ValueObjects;
using Domain.Shared;

namespace Domain.Entities.Apartments;

public sealed class Apartment : Entity<ApartmentId>
{
    public Apartment(
        ApartmentId id,
        string name, 
        string description,
        Address address,
        Money price,
        Money cleaningFee,
        List<Amenity> amenities)
            : base(id)
    {
        Name = name;
        Description = description;
        Address = address;
        Price = price;
        CleaningFee = cleaningFee;
        Amenities = amenities;
    }
    //Used for entity framework migrations or other scenarios requiring parameterless construction
    private Apartment() { }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public Address Address { get; private set; }
    public Money Price { get; private set; }
    public Money CleaningFee { get; private set; }
    public DateTime? LastBookedOnUtc { get; internal set; }
    public List<Amenity> Amenities { get; private set; }
}

