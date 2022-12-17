namespace CommonSolution.Entities;


public class Person
{

  public required string ID { get; init; }

  public required string FamilyName { get; set; }
  
  public required string GivenName { get; set; }

  public byte? Age { get; set; }
  
  public string? EmailAddress { get; set; }

  public string? PhoneNumber { get; set; }

  
  public Person Clone()
  {

    return new Person
    {
      ID = ID,
      FamilyName = FamilyName,
      GivenName = GivenName,
      EmailAddress = EmailAddress,
      PhoneNumber = PhoneNumber,
      Age = Age
    };
  }
  
}