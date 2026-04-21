//aiken
//task 1
class Student
{
    public string Name { get; set; }
    public int Grade1 { get; set; }
    public int Grade2 { get; set; }
    public int Grade3 { get; set; }

    public double GetAverage()
    {
        return (Grade1 + Grade2 + Grade3) / 3.0;
    }

    public string GetLetterGrade()
    {
        double average = GetAverage();

        if (average >= 90)
            return "A";
        else if (average >= 75)
            return "B";
        else if (average >= 60)
            return "C";
        else
            return "F";
    }

    public void Print()
    {
        Console.WriteLine($"{Name} - Average: {GetAverage():F2}, Grade: {GetLetterGrade()}");
    }
}

class Program
{
    static void Main()
    {
        Student[] roster = new Student[4];

        roster[0] = new Student { Name = "Aiken", Grade1 = 95, Grade2 = 90, Grade3 = 92 };
        roster[1] = new Student { Name = "Assylai", Grade1 = 78, Grade2 = 80, Grade3 = 75 };
        roster[2] = new Student { Name = "Arujan", Grade1 = 65, Grade2 = 60, Grade3 = 70 };
        roster[3] = new Student { Name = "Moldir", Grade1 = 88, Grade2 = 67, Grade3 = 88 };

        for (int i = 0; i < roster.Length; i++)
        {
            roster[i].Print();
        }

        Student best = roster[0];

        for (int i = 1; i < roster.Length; i++)
        {
            if (roster[i].GetAverage() > best.GetAverage())
            {
                best = roster[i];
            }
        }

        Console.WriteLine();
        Console.WriteLine("Best student:");
        best.Print();
    }
}

//task2
BankAccount acc = new BankAccount("Aiken", 100m);

acc.Deposit(50m);
acc.Withdraw(30m);
acc.PrintStatement();

try
{
    acc.Withdraw(1000m);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}


class BankAccount
{
    public string Owner { get; }
    public decimal Balance { get; private set; }

    public BankAccount(string owner, decimal initialDeposit)
    {
        if (initialDeposit < 0)
        {
            throw new ArgumentException("Initial deposit cannot be negative");
        }

        Owner = owner;
        Balance = initialDeposit;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive");
        }

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdraw amount must be positive");
        }

        if (amount > Balance)
        {
            throw new InvalidOperationException("Insufficient funds");
        }

        Balance -= amount;
    }

    public void PrintStatement()
    {
        Console.WriteLine($"Owner: {Owner}, Balance: ${Balance}");
    }
}

//task 3
Temperature temp = new Temperature(25);

temp.Print();

temp.Fahrenheit = 100;
temp.Print();

try
{
    temp.Celsius = -300;
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}

class Temperature
{
    private double _celsius;

    public double Celsius
    {
        get
        {
            return _celsius;
        }
        set
        {
            if (value < -273.15)
            {
                throw new ArgumentException("Temperature cannot be below absolute zero");
            }

            _celsius = value;
        }
    }

    public double Fahrenheit
    {
        get
        {
            return _celsius * 9 / 5 + 32;
        }
        set
        {
            Celsius = (value - 32) * 5 / 9;
        }
    }

    public Temperature(double celsius)
    {
        Celsius = celsius;
    }

    public void Print()
    {
        Console.WriteLine($"{Celsius}°C / {Fahrenheit}°F");
    }
}