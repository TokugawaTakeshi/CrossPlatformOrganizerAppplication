using BusinessRules.Enterprise;


namespace Client
{
  public partial class App : Application
  {
    public App()
    {

      InitializeComponent();

      Person testPerson = new Person(
        ID: 1,
        name: "Jon Davis",
        email: "jon_davis@jmail.com",
        phoneNumber: "5555555555"
      )
      {
        Age = 30
      };

      Console.WriteLine("======================================================");
      Console.WriteLine(testPerson);

      MainPage = new AppShell();
    }
  }
}