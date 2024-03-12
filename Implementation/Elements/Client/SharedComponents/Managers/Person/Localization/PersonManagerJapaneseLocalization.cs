using Client.Resources.Localizations;


namespace Client.SharedComponents.Managers.Person.Localization;


internal record PersonManagerJapaneseLocalization : PersonManagerLocalization
{
  
  internal override string heading { get; } = "人（連絡先）詳細";
  
  internal override Buttons buttons { get; init; } = new()
  {
    personEditing = new SharedStaticStrings.ButtonWithVisibleLabel { label = "人を編集"},
    personDeleting = new SharedStaticStrings.ButtonWithVisibleLabel { label = "人を削除"},
    personSaving = new SharedStaticStrings.ButtonWithVisibleLabel { label = "人を保存"},
    terminatingOfEditing = new SharedStaticStrings.ButtonWithVisibleLabel { label = "編集停止"}
  };
  
  internal override MetadataKeys metadataKeys { get; } = new()
  {
    name = "名前",
    nameSpell = "名前の読み方",
    gender = "性別",
    birthDate = "生年月日",
    emailAddress = "メールアドレス",
    phoneNumber = "電話番号"
  };
  
  internal override SharedStaticStrings.ModalDialog personDeletingConfirmationModalDialog { get; init; } = new SharedStaticStrings.ModalDialog()
  {
    title = "削除確認",
    question = "この課題の削除で宜しいでしょうか。"
  };
  
  internal override Controls controls { get; } = new()
  {
    familyName = new SharedStaticStrings.ControlWithLabelAndGuidance
    {
      label = "性",
      guidance = 
          $"上の名前を**{ CommonSolution.Entities.Person.FamilyName.MINIMAL_CHARACTERS_COUNT }~" +
          $"{ CommonSolution.Entities.Person.FamilyName.MAXIMAL_CHARACTERS_COUNT }文字内**入力して下さい。" 
          
    },
    givenName = new SharedStaticStrings.ControlWithLabelAndGuidance
    {
      label = "名",
      guidance = 
          $"上の名前を**{ CommonSolution.Entities.Person.GivenName.MINIMAL_CHARACTERS_COUNT }~" +
          $"{ CommonSolution.Entities.Person.GivenName.MAXIMAL_CHARACTERS_COUNT }文字内**入力して下さい。"
    },
    familyNameSpell = new SharedStaticStrings.ControlWithLabelAndGuidance
    {
      label = "性の読み方",
      guidance = 
          $"上の名前を**{ CommonSolution.Entities.Person.FamilyNameSpell.MINIMAL_CHARACTERS_COUNT }~" +
          $"{ CommonSolution.Entities.Person.FamilyNameSpell.MAXIMAL_CHARACTERS_COUNT }文字内**入力して下さい。" 
          
    },
    givenNameSpell = new SharedStaticStrings.ControlWithLabelAndGuidance
    {
      label = "名の読み方",
      guidance = 
          $"下の名前を**{ CommonSolution.Entities.Person.GivenNameSpell.MINIMAL_CHARACTERS_COUNT }~" +
          $"{ CommonSolution.Entities.Person.GivenNameSpell.MAXIMAL_CHARACTERS_COUNT }文字内**入力して下さい。" 
    },
    gender = new Controls.RadioButton
    {
      label = "性別",
      optionsLabels = new Controls.RadioButton.OptionsLabels
      {
        male = "男",
        female = "女"
      }
    },
    emailAddress = "メールアドレス",
    phoneNumber = "電話番号"
  };
  
}