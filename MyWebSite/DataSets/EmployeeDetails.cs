namespace MyWebSite.DataSets
{
  public class EmployeeDetails
  {
    private int employeeID;
    public int EmployeeID
    {
      get
      {
        return employeeID;
      }
      set
      {
        employeeID = value;
      }
    }

    private string firstName;
    public string FirstName
    {
      get
      {
        return firstName;
      }
      set
      {
        firstName = value;
      }
    }


    private string lastName;
    public string LastName
    {
      get
      {
        return lastName;
      }
      set
      {
        lastName = value;
      }
    }


    private string titleOfCourtesy;
    public string TitleOfCourtesy
    {
      get
      {
        return titleOfCourtesy;
      }
      set
      {
        titleOfCourtesy = value;
      }
    }


    public EmployeeDetails(int employeeID, string firstName, string lastName, string titleOfCourtesy)
    {
      EmployeeID = employeeID;
      LastName = lastName;
      FirstName = firstName;
      TitleOfCourtesy = titleOfCourtesy;
    }

  }
}