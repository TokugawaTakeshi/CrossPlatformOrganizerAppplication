/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

namespace GeneratorOfAssetsForStaticPreview.StringResources.Pages.Person.Management;


internal abstract record PeopleManagementPageLocalization
{

  internal abstract string pageTitle { get; }
  
  
  internal abstract string personManagerActivationGuidance { get; }
  
  
  internal record SuccessMessages
  {
    internal required string personAddingSucceeded { get; init; }
    internal required string personUpdatingSucceeded { get; init; }
    internal required string personDeletingSucceeded { get; init; }
  }
  
  internal abstract SuccessMessages successMessages { get; init; }
  
  
  internal record ErrorMessages
  {
    internal required string personAddingFailed { get; init; }
    internal required string personUpdatingFailed { get; init; }
    internal required string personDeletingFailed { get; init; }
  }
  
  internal abstract ErrorMessages errorMessages { get; init; }
  
}