// Core/Models/Client.cs
using System.Collections.Generic;

public class Client
{
	public int Id { get; set; }
	public int FirmId { get; set; }
	public Firm Firm { get; set; }
	public string Name { get; set; }
	public int? IndustryId { get; set; }
	public Industry Industry { get; set; }
	public int? CountryId { get; set; }
	public Country Country { get; set; }

	public ICollection<Lawyer> Lawyers { get; set; } = new List<Lawyer>();
	public ICollection<Deal> Deals { get; set; } = new List<Deal>();
}