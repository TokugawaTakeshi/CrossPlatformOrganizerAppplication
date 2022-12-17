namespace CommonSolution.Entities;


public class Location
{
  
  public required string LocalizedName { get; set; }
  
  public required double Latitude { get; set; }
  public required double Longitude { get; set; }

  public Categories? Category { get; set; } 
  
  public enum Categories
  {
    RailwayStation,
    MedicalFacility,
    Mall,
    Office,
    ApartmentHouse
  }
  
}