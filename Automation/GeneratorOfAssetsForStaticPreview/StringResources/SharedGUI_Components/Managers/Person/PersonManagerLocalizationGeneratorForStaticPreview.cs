using System.Text.Json.Nodes;
using YamatoDaiwa.PugCSharpStaticPreview;
using LanguageKey = string;
using JSON_Value = string;


namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Managers.Person;


internal static class PersonManagerLocalizationGeneratorForStaticPreview
{

  public static void Generate(JsonObject outputObjectWorkpiece)
  {
    
    LocalizationsGeneratorForStaticPreview.Generate(
      outputObjectWorkpiece,
      outputObjectDotSeparatedPathCommonPart: "components.managers.person",
      languageKeysAndLocalizations: new Dictionary<LanguageKey, PersonManagerLocalization>
      {
        { "$$english", new PersonManagerEnglishLocalization() },
        { "$$japanese", new PersonManagerJapaneseLocalization() }
      },
      properties: new Dictionary<string, Func<PersonManagerLocalization, JSON_Value>>
      {
        
        {
          "heading",
          localization => localization.heading
        },

        
        /* ━━━ Buttons ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
        {
          "buttons.personEditing.label",
          localization => localization.buttons.personEditing.label
        },
        {
          "buttons.personDeleting.label",
          localization => localization.buttons.personDeleting.label
        },
        {
          "buttons.personSaving.label",
          localization => localization.buttons.personSaving.label
        },
        {
          "buttons.terminatingOfEditing.label",
          localization => localization.buttons.terminatingOfEditing.label
        },
        
        
        /* ━━━ Metadata Keys ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
        { "metadataKeys.name", localization => localization.metadataKeys.name },
        { "metadataKeys.nameSpell", localization => localization.metadataKeys.nameSpell },
        { "metadataKeys.gender", localization => localization.metadataKeys.gender },
        { "metadataKeys.birthDate", localization => localization.metadataKeys.birthDate },
        { "metadataKeys.emailAddress", localization => localization.metadataKeys.emailAddress },
        { "metadataKeys.phoneNumber", localization => localization.metadataKeys.phoneNumber },
        
        
        /* ━━━ Controls ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
        { "controls.familyName.label", localization => localization.controls.familyName.label },
        { "controls.familyName.guidance", localization => localization.controls.familyName.guidance },
        { "controls.givenName.label", localization => localization.controls.givenName.label },
        { "controls.givenName.guidance", localization => localization.controls.givenName.guidance },
        { "controls.familyNameSpell.label", localization => localization.controls.familyNameSpell.label },
        { "controls.familyNameSpell.guidance", localization => localization.controls.familyNameSpell.guidance },
        { "controls.givenNameSpell.label", localization => localization.controls.givenNameSpell.label },
        { "controls.givenNameSpell.guidance", localization => localization.controls.givenNameSpell.guidance },
        { "controls.gender.label", localization => localization.controls.gender.label },
        { "controls.gender.optionsLabels.male", localization => localization.controls.gender.optionsLabels.male },
        { "controls.gender.optionsLabels.female", localization => localization.controls.gender.optionsLabels.female },
        
        { "controls.emailAddress", localization => localization.controls.emailAddress },
        { "controls.phoneNumber", localization => localization.controls.phoneNumber },
        
        
        /* ━━━ Person Deleting Confirmation Modal Dialog ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
        { "personDeletingConfirmationModalDialog.title", localization => localization.personDeletingConfirmationModalDialog.title },
        { "personDeletingConfirmationModalDialog.question", localization => localization.personDeletingConfirmationModalDialog.question }
        
      },
      objectTypeNameForJSDoc: nameof(PersonManagerLocalization)
    );
    
  }
  
}