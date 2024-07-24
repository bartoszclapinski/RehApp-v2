﻿namespace RehApp.Domain.Entities;

public class Address
{
	public string Street { get; set; } = default!;
	public string City { get; set; } = default!;
	public string ZipCode { get; set; } = default!;
	public string Country { get; set; } = default!;
}