using BusinessRules.Enterprise;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace Client.LocalDataBase.Models;


// TODO 情報収集の上完成 https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/3
[Table("People")]
[Index(nameof(Email), IsUnique = true)]
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
    string name,
    string email,
    string phoneNumber
  ) : base(
     ID, // データベースから自動的に割り当てられたIDを取る
     name,
     email,
     phoneNumber
  ) {}

}