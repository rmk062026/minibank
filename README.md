# Mini Bank Terminal

## Description

Mini Bank Terminal is a simple C# console application that simulates basic banking operations.

The user can log in with a username and PIN code. After a successful login, the user can check their balance, deposit money, withdraw money, view account information, or exit the program.

The application was created as a beginner project to practise input validation, lists, indexes, conditional statements, and switch statements in C#.

---

## Features

* Login using a username and PIN code
* Validate PIN codes using `int.TryParse`
* Find users with `IndexOf`
* Check the balance of the logged-in user
* Deposit money into an account
* Withdraw money from an account
* Prevent withdrawals that exceed the available balance
* Display account information
* Handle invalid usernames, PIN codes, menu choices, and amounts
* Store user information in parallel lists

---

## Technologies

* C#
* .NET
* Console Application
* Visual Studio Code

---

## How to Run

1. Clone or download this repository.
2. Open the project in Visual Studio Code or Visual Studio.
3. Open a terminal in the project folder.
4. Run the application:

```bash
dotnet run
```

5. Log in using one of the fictional test accounts below.

---

## Test Users

These accounts are fictional and are only used for testing.

| Username |  PIN | Starting Balance | Account Number |
| :------- | ---: | ---------------: | -------------: |
| Admin    | 1234 |       10,000 NOK |       84578746 |
| Ola      | 3452 |        5,000 NOK |       54236663 |
| Nordmann | 8372 |       30,000 NOK |       19428764 |

> **Note:** Usernames are case-sensitive. For example, `Admin` is valid, while `admin` is not.

---

## Program Flow

1. The application asks the user to enter a username.
2. The application searches for the username using `IndexOf()`.
3. The user enters a PIN code.
4. The PIN is validated with `int.TryParse()`.
5. If the username exists and the PIN is correct, the main menu is displayed.
6. The user selects one of the available menu options.
7. The selected action is performed.

### Main Menu

```text
1. Check balance
2. Deposit money
3. Withdraw money
4. Account information
5. Exit program
```

---

## How User Data Is Connected

The application stores user information in parallel lists.

Information stored at the same index belongs to the same user.

```text
Index 0

userNames[0]      -> Admin
pinCodes[0]       -> 1234
balances[0]       -> 10000
accountNumbers[0] -> 84578746
```

The application uses:

```csharp
int userIndex = userNames.IndexOf(userName);
```

The value stored in `userIndex` is then used to retrieve the correct PIN code, balance, and account number.

---

## What I Learned

During this project I learned how to:

* Create and use `List<T>`
* Connect multiple lists using the same index
* Find data with `IndexOf()`
* Understand that `IndexOf()` returns `-1` if an item is not found
* Read user input with `Console.ReadLine()`
* Validate numbers using `int.TryParse()` and `decimal.TryParse()`
* Use nested `if`, `else if`, and `else` statements
* Create menus using a `switch` statement
* Use logical operators such as `&&`
* Update values inside a list using `+=` and `-=`
* Validate user input before processing it
* Display user-specific information using indexes

---

## Test Cases

| Test                                 | Expected Result                       |  Status  |
| :----------------------------------- | :------------------------------------ | :------: |
| Correct username and PIN             | Main menu is displayed                | ✅ Passed |
| Incorrect username                   | Login rejected                        | ✅ Passed |
| Incorrect PIN                        | Login rejected                        | ✅ Passed |
| Letters entered as PIN               | Error message displayed               | ✅ Passed |
| Letters entered as menu choice       | Error message displayed               | ✅ Passed |
| Invalid menu option                  | Error message displayed               | ✅ Passed |
| Valid deposit                        | Balance increases                     | ✅ Passed |
| Negative deposit                     | Rejected                              | ✅ Passed |
| Valid withdrawal                     | Balance decreases                     | ✅ Passed |
| Withdrawal greater than balance      | Rejected                              | ✅ Passed |
| Letters entered as withdrawal amount | Error message displayed               | ✅ Passed |
| Account information                  | Correct account information displayed | ✅ Passed |
| Exit program                         | Application closes                    | ✅ Passed |

---

## Current Limitations

* The application performs one menu action before exiting.
* Data is not saved after the program closes.
* User information is hardcoded.
* PIN codes are stored in plain text.
* PIN codes are visible while typing.
* Parallel lists are used instead of classes and objects.

---

## Future Improvements

* Allow multiple menu actions before exiting
* Add a logout option
* Return to the main menu after each action
* Hide the PIN code while typing
* Limit login attempts
* Use classes instead of parallel lists
* Store users in a database
* Save account information to a file
* Add transaction history
* Support transfers between accounts
* Create new accounts
* Hash PIN codes instead of storing them in plain text
* Make username searches case-insensitive

---

## Disclaimer

This project was created for educational purposes only.

It is **not** a real banking system and should **not** be used to store real usernames, PIN codes, account numbers, or financial information.
