/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Cards.Person;


internal abstract record PersonCardLocalization
{
  
  internal record Metadata
  {
    internal required string name { get; init; }
    internal required string nameSpell { get; init; }
    internal required string emailAddress { get; init; }
    internal required string phoneNumber { get; init; }
  }
  
  internal abstract Metadata metadata { get; init; }
  
}