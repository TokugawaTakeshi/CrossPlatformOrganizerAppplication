namespace BusinessRules.Enterprise;


public class Location
{
  
  public string LocalizedName { get; set; }
  
  public double Latitude { get; set; }
  public double Longitude { get; set; }

  public enum Category
  {
    RailwayStation,
    ApartmentHouse
  }
  
}