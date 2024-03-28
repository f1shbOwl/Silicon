﻿using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class AddressEntity
{
    [Key]
    public int Id { get; set; }

    public string? AddressLine_1 { get; set; }

    public string? AddressLine_2 { get; set; }

    public string? PostalCode { get; set; }

    public string? City { get; set; }

    public ICollection<UserEntity> Users { get; set; } = [];
}
