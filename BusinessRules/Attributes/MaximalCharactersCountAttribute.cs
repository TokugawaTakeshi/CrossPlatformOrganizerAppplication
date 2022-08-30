namespace BusinessRules.Attributes
{

  [AttributeUsage(AttributeTargets.Property)]
  public class MaximalCharactersCountAttribute : Attribute
  {

    public readonly uint Value;

    public MaximalCharactersCountAttribute(uint maximalCharactersCount)
    {
      Value = maximalCharactersCount;
    }
  }
}