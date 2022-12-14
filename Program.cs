using System;
using System.Collections.Generic;
using System.Linq;

namespace SuncoastHRDB
{
  class Program
  {
    static string PromptForString(string prompt) 
    {
Console.WriteLine(prompt);
var userInput = Console.ReadLine();
return userInput;
    }

    static int PromptForInteger(string prompt)
    {
Console.WriteLine(prompt);
int userInput;
var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);
if(isThisGoodInput)
{
  return userInput;
}
else 
{
  Console.WriteLine("Sorry not valid. 0 will be used");
  return 0;
}
    }

    static void Greeting()
    {
      Console.WriteLine();
      Console.WriteLine();
      Console.WriteLine("**************************");
      Console.WriteLine("**************************");
      Console.WriteLine("************WELCOME*******");
      Console.WriteLine("**************************");
      Console.WriteLine("**************************");
      Console.WriteLine();
      Console.WriteLine();
        }

    static void Main(string[] args)
    {

      var database = new EmployeeDatabase();
      // var employees = new List<Employee>();

      Greeting();

      var keepGoing = true;

      while(keepGoing)
      {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("[A]dd employee");
        Console.WriteLine("[S]how All Employees");
        Console.WriteLine("[F]ind an Employee");
        Console.WriteLine("[D]elete an Employee");
        Console.WriteLine("[Q]uit");

        var choice = Console.ReadLine().ToUpper();

        if(choice == "A")
{

                    var employee = new Employee();

                    employee.Name = PromptForString("What is your name?");
                    employee.Department = PromptForInteger("What is your department?");
                    employee.Salary = PromptForInteger("What is your salary?");

                    database.AddEmployee(employee);

                    Console.WriteLine();
                    Console.WriteLine($"Hello {employee.Name}, your department is {employee.Department} and your salary is {employee.MonthlySalary()} per month");
                    Console.WriteLine();


        }        else if(choice =="S") {

          var employees = database.GetAllEmployees();
  foreach(var employee in employees)
  {
    Console.WriteLine($"Employee {employee.Name} is in department {employee.Department} and makes a salary of {employee.Salary} per month");
  }


} else if(choice =="F") {
var nameToSearchFor = PromptForString("What name are you searching for?");
// Employee foundEmployee = null;
Employee foundEmployee = database.FindOneEmployee(nameToSearchFor);

// foreach(var employee in employees) {
// if(employee.Name == nameToSearchFor) {
//   foundEmployee = employee;
// }
// }
if(foundEmployee == null) {
  Console.WriteLine();
  Console.WriteLine("No employee by that name found.");
                        Console.WriteLine();
} else {
                        Console.WriteLine();
  Console.WriteLine($"{foundEmployee.Name} is in department {foundEmployee.Department} and makes a salary of {foundEmployee.MonthlySalary()} per month");
                        Console.WriteLine();
}

}

else if(choice =="D") {
var name = PromptForString("What name are you searching for?");
Employee foundEmployee = database.FindOneEmployee(name);

if(foundEmployee ==null)
{
  Console.WriteLine("Sorry, that employee does not exist.");

}else{
  Console.WriteLine($"{foundEmployee.Name} was found.");
  var confirm = PromptForString("Are you sure you'd like to delete this employee? [Y/N]").ToUpper();

  if(confirm == "Y")
  {
    database.DeleteEmployee(foundEmployee);
    Console.WriteLine();
    Console.WriteLine($"{foundEmployee.Name} succesfully removed from database.");
    Console.WriteLine();
    // Console.Clear();
  }
}

}


else
{
  keepGoing=false;
}
      }

     
    }
  }
}
