namespace Client.SharedGUI_Components.Cards.Person.Localizations;


internal record PersonCardEnglishLocalization() : PersonCardLocalization(
    
  tableHeadings: 
  
      new TableHeadings(
        name: "Name",
        nameSpell: "Name Spell",
        emailAddress: "Email Address",
        phoneNumber: "Phone Number"
      )
  
);
