using CommonSolution.Fundamentals;


namespace Client.LocalDataBase.Models;


[System.ComponentModel.DataAnnotations.Schema.Table("People")]
public class PersonModel
{
  
  /* [ Theory ] `Guid.NewGuid()` return the string of 36 characters. See https://stackoverflow.com/a/4458925/4818123 */
  [System.ComponentModel.DataAnnotations.Key]
  [System.ComponentModel.DataAnnotations.Required]
  [System.ComponentModel.DataAnnotations.MinLength(36)]
  [System.ComponentModel.DataAnnotations.MaxLength(36)]
  public string ID { get; set; } = Guid.NewGuid().ToString();
  
  
  /* ━━━ Name ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [System.ComponentModel.DataAnnotations.Required]
  [System.ComponentModel.DataAnnotations.MinLength(CommonSolution.Entities.Person.FamilyName.MINIMAL_CHARACTERS_COUNT)]
  [System.ComponentModel.DataAnnotations.MaxLength(CommonSolution.Entities.Person.FamilyName.MINIMAL_CHARACTERS_COUNT)]
  public string FamilyName { get; set; } = null!;
  
  [System.ComponentModel.DataAnnotations.MinLength(CommonSolution.Entities.Person.GivenName.MINIMAL_CHARACTERS_COUNT)]
  [System.ComponentModel.DataAnnotations.MaxLength(CommonSolution.Entities.Person.GivenName.MAXIMAL_CHARACTERS_COUNT)]
  public string GivenName { get; set; } = null!;
  
  [System.ComponentModel.DataAnnotations.MinLength(CommonSolution.Entities.Person.FamilyNameSpell.MINIMAL_CHARACTERS_COUNT)]
  [System.ComponentModel.DataAnnotations.MaxLength(CommonSolution.Entities.Person.FamilyNameSpell.MAXIMAL_CHARACTERS_COUNT)]
  public string FamilyNameSpell { get; set; } = null!;
  
  [System.ComponentModel.DataAnnotations.MinLength(CommonSolution.Entities.Person.GivenNameSpell.MINIMAL_CHARACTERS_COUNT)]
  [System.ComponentModel.DataAnnotations.MaxLength(CommonSolution.Entities.Person.GivenNameSpell.MAXIMAL_CHARACTERS_COUNT)]
  public string GivenNameSpell { get; set; } = null!;
  
  
  public Genders? Gender { get; set; }

}