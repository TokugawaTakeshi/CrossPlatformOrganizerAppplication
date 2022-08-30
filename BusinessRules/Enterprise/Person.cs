using BusinessRules.Attributes;


namespace BusinessRules.Enterprise
{
  public class Person
  {

    public readonly uint ID;

    [Required]
    [MinimalCharactersCount(2)]
    public string Name { get; set; }

    [Required]
    [MinimalCharactersCount(3)]
    public string Email { get; set; }

    [Required]
    [MinimalCharactersCount(10)]
    [MaximalCharactersCount(11)]
    public string PhoneNumber { get; set; }

    public byte? Age { get; set; }


    public Person(
      uint ID,
      string name,
      string email,
      string phoneNumber
    )
    {
      this.ID = ID;
      Name = name;
      Email = email;
      PhoneNumber = phoneNumber;
    }


    internal Person Clone()
    {
      return new Person(ID, Name, Email, PhoneNumber)
      {
        Age = Age
      };
    }

    public override string ToString()
    {
      return "{\n" +
        $"  ID: {ID}\n" +
        $"  Name: {Name}\n" +
        $"  Email: {Email}\n" +
        $"  PhoneNumber: {PhoneNumber}\n" +
        $"  Age: {Age}\n" +
      "}";
    }
  }
}
