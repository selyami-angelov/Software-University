
using System;

class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;
    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }
    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        private set
        {
            if (value.Length < 3)
            {
                //todo
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }
            else
            {
                this.firstName = value;
            }
        }
    }
    public string LastName
    {
        get
        {
            return this.lastName;
        }
        private set
        {

            if (value.Length >= 3)
            {
                this.lastName = value;
                //todo
            }
            else
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }

        }
    }
    public int Age
    {
        get
        {
            return this.age;
        }
        private set
        {
            if (value <= 0)
            {
                //todo
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            else
            {
                this.age = value;
            }
        }
    }
    public decimal Salary
    {
        get
        {
            return this.salary;
        }
        private set
        {
            if (value < 460)
            {
                //todo
                throw new ArgumentException("Salary cannot be less than 460 leva!");
            }
            else
            {
                this.salary = value;
            }
        }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} gets {this.Salary:f2} leva.";
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

