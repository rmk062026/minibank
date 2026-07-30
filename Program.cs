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
    834532,
    5325,
    29342
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
        Console.WriteLine($"Account name: {userNames[userIndex]}");
        Console.WriteLine($"Balance: {balances[userIndex]}");
    }
    else
    {
        Console.WriteLine("Account not found...");
    }
}
else
{
    Console.WriteLine("PIN must be a number...");
}