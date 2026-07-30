Console.WriteLine("Mini Bank");

List<string> userNames = new List<string>
{
    "Admin",
    "Ola",
    "Nordmann"
};

List<int> pinCodes = new List<int>
{
    1234,
    3452,
    8372
};

List<decimal> balances = new List<decimal>
{
    10000,
    5000,
    30000
};

List<int> accountNumbers = new List<int>
{
    84578746,
    54236663,
    19428764
};

Console.WriteLine("Welcome. Please login...");
Console.WriteLine("Enter your name:");
string userName = Console.ReadLine()!;

Console.WriteLine($"Hello {userName}, Enter your pincode:");

// Username as int to find index
int userIndex = userNames.IndexOf(userName);

if (int.TryParse(Console.ReadLine(), out int pinCode))
{
    if (userIndex != -1 && pinCode == pinCodes[userIndex])
    {
        Console.WriteLine("1. Check balance");
        Console.WriteLine("2. Deposit money");
        Console.WriteLine("3. Withdraw money");
        Console.WriteLine("4. Account information");
        Console.WriteLine("5. Exit program");
        Console.WriteLine("Choose an option:");

        if (int.TryParse(Console.ReadLine(), out int menuChoice))
        {
            switch (menuChoice)
            {
                case 1:
                    Console.WriteLine($"Your current balance is {balances[userIndex]} NOK.");
                    break;

                case 2:
                    Console.WriteLine("Enter deposit amount:");
                    if (decimal.TryParse(Console.ReadLine(), out decimal depositUser))
                    {
                        if (depositUser > 0)
                        {
                            balances[userIndex] += depositUser;
                            Console.WriteLine("Deposit completed.");
                            Console.WriteLine($"New balance: {balances[userIndex]}");
                        }
                        else
                        {
                            Console.WriteLine("Can't be below 0 NOK.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Must enter numbers only...");
                    }
                    break;

                case 3: // Withdraw money
                    Console.WriteLine("Enter amount to withdraw:");
                    if (decimal.TryParse(Console.ReadLine(), out decimal withDrawUser))
                    {
                        if (withDrawUser <= balances[userIndex])
                        {
                            balances[userIndex] -= withDrawUser;
                            Console.WriteLine("Withdraw completed.");
                            Console.WriteLine($"New balance: {balances[userIndex]} NOK.");
                        }
                        else
                        {
                            Console.WriteLine("Insufficient founds...");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Must enter numbers only...");
                    }
                    break;

                case 4:
                    Console.WriteLine($"Name: {userNames[userIndex]}");
                    Console.WriteLine($"Account number: {accountNumbers[userIndex]}");
                    Console.WriteLine($"Balance: {balances[userIndex]} NOK.");
                    break;

                case 5:
                    Console.WriteLine("Closing app...");
                    break;

                default:
                    Console.WriteLine("App is closing. Press a button...");
                    Console.ReadKey();
                    break;
            }
        }
        else
        {
            Console.WriteLine("You must enter a number between 1 and 5.");
        }
    }
    else
    {
        Console.WriteLine("Invalid username or PIN...");
    }
}
else
{
    Console.WriteLine("PIN must be a number...");
}