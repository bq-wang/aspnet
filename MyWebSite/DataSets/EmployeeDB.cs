using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections;

namespace MyWebSite.DataSets
{
  public class EmployeeDB
  {
    private string connectionString;

    public EmployeeDB()
    {
      connectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
    }

    public EmployeeDB(string connectionString)
    {
      this.connectionString = connectionString;
    }

    public int InsertEmployee(EmployeeDetails emp)
    {
      SqlConnection con = new SqlConnection(connectionString);
      SqlCommand cmd = new SqlCommand("InsertEmployee", con);
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 10));
      cmd.Parameters["@FirstName"].Value = emp.FirstName;

      cmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 20));
      cmd.Parameters["@LastName"].Value = emp.LastName;

      cmd.Parameters.Add(new SqlParameter("@TitleOfCourtesy", SqlDbType.NVarChar, 25));
      cmd.Parameters["@TitleOfCourtesy"].Value = emp.TitleOfCourtesy;

      cmd.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int, 4));
      cmd.Parameters["@EmployeeID"].Direction = ParameterDirection.Output;

      try
      {
        con.Open();
        cmd.ExecuteNonQuery();
        return (int)cmd.Parameters["@EmployeeID"].Value;
      }
      catch (Exception)
      {
        throw new ApplicationException("Data Error!");
      }
      finally
      {
        con.Close();
      }
    }

    public void DeleteEmployee(int employeeID)
    {
      SqlConnection con = new SqlConnection(connectionString);
      SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
      cmd.CommandType = CommandType.StoredProcedure;

      cmd.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int, 4));
      cmd.Parameters["@EmployeeID"].Value = employeeID;

      try
      {
        con.Open();
        cmd.ExecuteNonQuery();
      }
      catch (Exception)
      {
        throw new ApplicationException("Data Error!");
      }
      finally
      {
        con.Close();
      }
    }

    public void UpdateEmployee(int employeeID, string firstName, string lastName, string titleOfCourtesy)
    {
      SqlConnection con = new SqlConnection(connectionString);
      SqlCommand cmd = new SqlCommand("UpdateEmployee", con);
      cmd.CommandType = CommandType.StoredProcedure;

      cmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 10));
      cmd.Parameters["@FirstName"].Value = firstName;

      cmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 20));
      cmd.Parameters["@LastName"].Value = lastName;

      cmd.Parameters.Add(new SqlParameter("@TitleOfCourtesy", SqlDbType.NVarChar, 25));
      cmd.Parameters["@TitleOfCourtesy"].Value = titleOfCourtesy;

      cmd.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int, 4));
      cmd.Parameters["@EmployeeID"].Value = employeeID;

      try
      {
        con.Open();
        cmd.ExecuteNonQuery();
      }
      catch (Exception)
      {
        throw new ApplicationException("Data Error!");
      }
      finally
      {
        con.Close();
      }
    }

    public EmployeeDetails GetEmployee(int employeeID)
    {
      SqlConnection con = new SqlConnection(connectionString);
      SqlCommand cmd = new SqlCommand("GetEmployee", con);
      cmd.CommandType = CommandType.StoredProcedure;

      cmd.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int, 4));
      cmd.Parameters["@EmployeeID"].Value = employeeID;

      try
      {
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

        // check to see if it returns one records
        if (!reader.HasRows) return null;

        reader.Read();
        EmployeeDetails emp = new EmployeeDetails((int)reader["EmployeeID"], (string)reader["FirstName"], (string)reader["LastName"], (string)reader["TitleOfCourtesy"]);
        reader.Close();
        return emp;

      }
      catch (Exception)
      {
        throw new ApplicationException("Data Error!");
      }
      finally
      {
        con.Close();
      }
    }

    /// <summary>
    /// Get Employees
    /// </summary>
    /// <param name="sortExpression">sort parameters</param>
    /// <returns>sorted employees</returns>
    public EmployeeDetails[] GetEmployees(string sortExpression)
    {
      SqlConnection con = new SqlConnection(connectionString);
      SqlCommand cmd = new SqlCommand("GetAllEmployees", con);
      cmd.CommandType = CommandType.StoredProcedure;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      try
      {
        con.Open();
        adapter.Fill(ds, "Employees");

      }
      catch (Exception ex)
      {
        throw new ApplicationException("Data Error!");
      }
      finally
      {
        con.Close();
      }

      DataView view = ds.Tables[0].DefaultView;
      view.Sort = sortExpression;

      ArrayList employees = new ArrayList();
      foreach (DataRowView row in view)
      {
        EmployeeDetails emp = new EmployeeDetails(
            (int)row["EmployeeID"], (string)row["FirstName"],
            (string)row["LastName"], (string)row["TitleOfCourtesy"]);
        employees.Add(emp);
      }

      return (EmployeeDetails[])employees.ToArray(typeof(EmployeeDetails));
    }

    public List<EmployeeDetails> GetEmployees()
    {
      SqlConnection con = new SqlConnection(connectionString);
      SqlCommand cmd = new SqlCommand("GetAllEmployees", con);
      cmd.CommandType = CommandType.StoredProcedure;
      List<EmployeeDetails> employees = new List<EmployeeDetails>();
      try
      {
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
          EmployeeDetails emp = new EmployeeDetails((int)reader["EmployeeID"], (string)reader["FirstName"], (string)reader["LastName"], (string)reader["TitleOfCourtesy"]);
          employees.Add(emp);
        }
        reader.Close();
        return employees;

      }
      catch (Exception ex)
      {
        throw new ApplicationException("Data Error!");
      }
      finally
      {
        con.Close();
      }
    }

    public int CountEmployees()
    {
      SqlConnection con = new SqlConnection(connectionString);
      SqlCommand cmd = new SqlCommand("CountEmployees", con);
      cmd.CommandType = CommandType.StoredProcedure;
      try
      {
        con.Open();
        return (int)cmd.ExecuteScalar();
      }
      catch (Exception)
      {
        throw new ApplicationException("Data Error!");
      }
      finally
      {
        con.Close();
      }
    }
  }
}