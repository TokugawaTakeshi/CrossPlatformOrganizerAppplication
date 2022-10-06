using BusinessRules.Enterprise;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Client.LocalDataBase.Models;


// TODO 情報収集の上完成 https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/3
[Table("People")]
public class PersonModel : Person
{
  
  [Key]
  [Required]
  public readonly uint ID;

  [Required]
  public string Name;
  
  [Required]
  public string Email { get; set; }
  
  [Required]
  public string PhoneNumber { get; set; }

  public byte? Age { get; set; }
  
  public PersonModel(
    uint ID,
    string name,
    string email,
    string phoneNumber
  ) : base(
     ID,
     name,
     email,
     phoneNumber
  ) {}

}