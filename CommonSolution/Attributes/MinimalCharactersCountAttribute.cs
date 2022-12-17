namespace CommonSolution.Attributes;


[AttributeUsage(AttributeTargets.Property)]
public class MinimalCharactersCountAttribute : Attribute
{

  public readonly uint Value;

  public MinimalCharactersCountAttribute(uint minimalCharactersCount)
  {
    Value = minimalCharactersCount;
  }
}