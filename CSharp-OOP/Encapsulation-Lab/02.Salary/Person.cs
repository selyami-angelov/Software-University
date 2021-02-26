
public class Person
{
    //private string firstName;
    //private string lastName;
    //private int age;
    private decimal salary;
    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int Age { get; private set; }
    public decimal Salary
    {
        get
        {
            return this.salary;
        }
        private set
        {
            this.salary = value;
        }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
    }
        
    public void IncreaseSalary(decimal percentage)
    {
        if (this.Age < 30)
        {
            this.Salary += (percentage / 200) * this.Salary;
        }
        else
        {
            this.Salary += (percentage / 100) * this.Salary;
        }
        
    }
}

