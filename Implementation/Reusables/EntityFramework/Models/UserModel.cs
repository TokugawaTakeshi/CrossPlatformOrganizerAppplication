using User = CommonSolution.Entities.AccessControl.User;
using Microsoft.EntityFrameworkCore;
using DataAnnotations = System.ComponentModel.DataAnnotations; 

namespace EntityFramework.Models;


[Microsoft.EntityFrameworkCore.EntityTypeConfiguration(typeof(UserModel.Configuration))]
public class UserModel
{

  /* ━━━ Properties ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [DataAnnotations.Key]
  [DataAnnotations.MaxLength(36)]
  public required string ID { get; set; }

  [DataAnnotations.MaxLength(User.EmailAddress.MAXIMAL_ONE_BYTE_CHARACTERS_COUNT)]
  public required string EmailAddress { get; set; }

  [DataAnnotations.MaxLength(User.DisplayingName.MAXIMAL_ONE_BYTE_CHARACTERS_COUNT)]
  public required string DisplayingName { get; set; }

  [DataAnnotations.MaxLength(User.PhoneNumber.MAXIMAL_ONE_BYTE_CHARACTERS_COUNT)]
  public required string PhoneNumber { get; set; }
  
  public required User.AuthorityRoles AuthorityRole { get; set; }
  
  [DataAnnotations.MaxLength(User.HashedPassword.MAXIMAL_ONE_BYTE_CHARACTERS_COUNT)]
  public required string HashedPassword { get; set; }
  
  
  /* ━━━ Compatibility with Business Rules ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public static UserModel FromBusinessRulesEntity(User user)
  {
    return new UserModel
    {
      ID = user.ID,
      EmailAddress = user.emailAddress,
      DisplayingName = user.displayingName,
      PhoneNumber = user.phoneNumber,
      AuthorityRole = user.authorityRole,
      HashedPassword = user.hashedPassword
    };
  }
  
  public static IEnumerable<UserModel> FromBusinessRulesEntities(IEnumerable<User> users)
  {
    return users.Select(UserModel.FromBusinessRulesEntity);
  }
  
  public User ToBusinessRulesEntity()
  {
    return new User
    {
      ID = this.ID,
      emailAddress = this.EmailAddress,
      displayingName = this.DisplayingName,
      phoneNumber = this.PhoneNumber,
      authorityRole = this.AuthorityRole,
      hashedPassword = this.HashedPassword
    };
  }
  
  public static IEnumerable<User> ToBusinessRuleEntities(IEnumerable<UserModel> usersModels)
  {
    return usersModels.Select((UserModel userModel) => userModel.ToBusinessRulesEntity());
  }


  /* ━━━ Configuration ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public class Configuration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<UserModel>
  {

    private const string TABLE_NAME = "Users";
    
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserModel> builder)
    {

      builder.ToTable(Configuration.TABLE_NAME);

      builder.Property(userModel => userModel.EmailAddress).IsRequired(User.EmailAddress.IS_REQUIRED);
      builder.Property(userModel => userModel.DisplayingName).IsRequired(User.DisplayingName.IS_REQUIRED);
      builder.Property(userModel => userModel.PhoneNumber).IsRequired(User.PhoneNumber.IS_REQUIRED);
      builder.Property(userModel => userModel.AuthorityRole).IsRequired(User.AuthorityRole.IS_REQUIRED);
      builder.Property(userModel => userModel.HashedPassword).IsRequired(User.HashedPassword.IS_REQUIRED);
      
    }
    
  }

}