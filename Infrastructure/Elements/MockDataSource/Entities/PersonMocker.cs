using BusinessRules.Enterprise;

using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using Utils;


namespace MockDataSource.Entities;


internal abstract class PersonMocker
{
  
  public static Person Generate(Options options)
  {

    uint ID = options.ID ?? GenerateID();

    
    string name;

    if (options.Name == null)
    {
      name = (options.NamePrefix ?? "") +
          RandomizerFactory.GetRandomizer(new FieldOptionsFirstName()).Generate() +
          " " + RandomizerFactory.GetRandomizer(new FieldOptionsLastName()).Generate();
    }
    else
    {
      name = options.Name;
    }


    byte? age = null;

    if (options.Age != null)
    {
      age = options.Age;
    }
    else if (options.AllOptionals || RandomValuesGenerator.GetRandomBoolean())
    {
      age = RandomValuesGenerator.GetRandomByte(minimalValue: 18, maximalValue: 80);
    }


    string email = options.EmailAddress ?? RandomValuesGenerator.GetRandomEmailAddress();

    string phoneNumber = options.PhoneNumber ?? RandomValuesGenerator.GenerateRandomJapanesePhoneNumber();

    return new Person(ID, name, email, phoneNumber) { Age = age };
    
  }


  public class Options
  {
    internal uint? ID;
    internal string? Name;
    internal string? EmailAddress;
    internal string? PhoneNumber;
    internal byte? Age;
    internal string? NamePrefix;
    internal bool AllOptionals = false;
  }

  private static uint counterForID_Generating;

  private static uint GenerateID()
  {
    counterForID_Generating++;
    return counterForID_Generating;
  }
}
