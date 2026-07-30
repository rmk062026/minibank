# Oppgave: Mini Bank Terminal

## Bakgrunn

Du skal lage en C#-konsollapplikasjon som simulerer en enkel minibank.

Oppgaven bygger på grunnleggende konsepter i C#:

- Variabler
- `Console.ReadLine()`
- `if`, `else if` og `else`
- `switch`
- `TryParse`
- Lister og indekser
- Boolske operatorer som `&&`
- Tydelige feilmeldinger

Du trenger ikke bruke løkker, metoder, klasser, filer eller database i hovedoppgaven.

---

## Oppgavebeskrivelse

En bruker skal kunne logge inn med brukernavn og PIN-kode.

Etter godkjent innlogging skal brukeren velge én handling fra en meny:

```text
1. Check balance
2. Deposit money
3. Withdraw money
4. Account information
```

Programmet skal utføre valgt handling og deretter avsluttes.

---

# Krav

## 1. Opprett testbrukere

Lag minst tre lister som hører sammen:

```csharp
List<string> usernames = ...
List<string> pinCodes = ...
List<decimal> balances = ...
```

Eksempel på sammenhengen mellom listene:

```text
Index 0:
Username -> martin
PIN      -> 1234
Balance  -> 1500

Index 1:
Username -> admin
PIN      -> 9999
Balance  -> 5000
```

Du bestemmer selv testbrukernavn, PIN-koder og saldo.

Alle listene må:

- Ha samme antall elementer
- Bruke samme rekkefølge
- Koble informasjon om samme bruker gjennom samme index

---

## 2. Innlogging

Programmet skal spørre etter:

```text
Username:
PIN:
```

Finn brukeren med:

```csharp
usernames.IndexOf(...)
```

Programmet skal kontrollere:

- Om brukeren finnes
- Om PIN-koden tilhører riktig bruker
- Om innloggingen feiler

Ved feil innlogging skal programmet vise en generell feilmelding:

```text
Invalid username or PIN.
```

Programmet skal ikke fortelle om det var brukernavnet eller PIN-koden som var feil.

---

## 3. Hovedmeny

Ved godkjent innlogging skal programmet vise en meny:

```text
Welcome, Martin!

1. Check balance
2. Deposit money
3. Withdraw money
4. Account information

Choose an option:
```

Bruk `TryParse` for å kontrollere menyvalget.

Bruk deretter en `switch` for alternativene `1` til `4`.

---

# Menyhandlinger

## Alternativ 1: Check balance

Vis saldoen til den innloggede brukeren.

Eksempel:

```text
Your current balance is 1500.00 NOK.
```

---

## Alternativ 2: Deposit money

Spør hvor mye brukeren ønsker å sette inn:

```text
Enter deposit amount:
```

Bruk:

```csharp
decimal.TryParse(...)
```

Beløpet må være større enn `0`.

Oppdater riktig verdi i saldolisten:

```csharp
balances[userIndex] = ...
```

Vis deretter en bekreftelse:

```text
Deposit completed.
New balance: 2000.00 NOK
```

---

## Alternativ 3: Withdraw money

Spør hvor mye brukeren ønsker å ta ut.

Programmet må kontrollere:

- At input er et tall
- At beløpet er større enn `0`
- At brukeren har nok penger

Ved for lav saldo:

```text
Insufficient funds.
```

Ved godkjent uttak skal saldoen oppdateres og den nye saldoen vises.

---

## Alternativ 4: Account information

Vis informasjon om den innloggede brukeren:

```text
Username: martin
Account number: 1001
Balance: 1500.00 NOK
```

Til denne delen kan du lage en fjerde liste:

```csharp
List<int> accountNumbers = ...
```

Kontonummeret på index `0` skal tilhøre brukeren på index `0`.

---

# Ugyldig input

Hvis brukeren skriver et tall utenfor `1` til `4`:

```text
Invalid menu option.
```

Hvis brukeren skriver bokstaver som menyvalg:

```text
Menu option must be a number.
```

Ved ugyldig beløp skal programmet vise en tydelig feilmelding.

---

# Begrensninger

I hovedversjonen skal du ikke bruke:

- `while`
- `for`
- `foreach`
- Egne metoder
- Klasser
- Database
- Lagring til fil

Du kan bruke dokumentasjon eller søke opp syntaks du ikke husker.

Målet er å kombinere konsepter du allerede har lært.

---

# Forslag til programflyt

Skriv gjerne pseudokode før du begynner:

```text
Start

Create user lists

Ask for username
Ask for PIN

Find username index

Is user found and PIN correct?

No:
    Show login error
    End

Yes:
    Show menu
    Read menu choice

Is menu choice a number?

No:
    Show number error
    End

Yes:
    Switch on menu choice

    Case 1:
        Show balance

    Case 2:
        Read deposit
        Validate amount
        Update balance

    Case 3:
        Read withdrawal
        Validate amount
        Check balance
        Update balance

    Case 4:
        Show account information

    Default:
        Show invalid option

End
```

---

# Tips

## Finne brukeren

```csharp
int userIndex = usernames.IndexOf(username);
```

Hvis brukeren ikke finnes:

```csharp
userIndex == -1
```

Ikke forsøk å hente en PIN-kode før du vet at `userIndex` er gyldig.

Denne koden vil krasje dersom `userIndex` er `-1`:

```csharp
pinCodes[userIndex]
```

---

## Kontrollere bruker og PIN

Betingelsen bør først kontrollere at brukeren finnes, og deretter kontrollere PIN-koden:

```text
Brukeren må finnes
OG
PIN-koden på samme index må være riktig
```

C# evaluerer en `&&`-betingelse fra venstre mot høyre. Derfor bør kontrollen av `userIndex` stå først.

---

## Oppdatere saldo

Hent saldoen slik:

```csharp
decimal currentBalance = balances[userIndex];
```

Oppdater saldoen slik:

```csharp
balances[userIndex] = newBalance;
```

---

## Pengeverdier

Bruk helst:

```csharp
decimal
```

i stedet for `double` når du arbeider med penger.

Eksempel:

```csharp
decimal balance = 1500.00m;
```

Bokstaven `m` forteller C# at tallet er en `decimal`.

---

# Testkrav

Programmet skal testes med minst disse situasjonene:

| Test | Forventet resultat |
|---|---|
| Riktig bruker og PIN | Menyen vises |
| Feil brukernavn | Innlogging avvises |
| Feil PIN | Innlogging avvises |
| Bokstaver som menyvalg | Feilmelding vises |
| Menyvalg `7` | Ugyldig menyvalg |
| Gyldig innskudd | Saldo øker |
| Negativt innskudd | Beløpet avvises |
| Gyldig uttak | Saldo reduseres |
| Uttak større enn saldo | Uttaket avvises |
| Bokstaver som beløp | Feilmelding vises |

---

# Dokumentasjon

Prosjektet skal inneholde en egen `README.md`.

Forslag til struktur:

```md
# Mini Bank Terminal

## Description

## Features

## Technologies

## How to Run

## Test Users

## Program Flow

## What I Learned

## Test Cases

## Future Improvements
```

Testbrukerne er fiktive og skal bare brukes i programmet.

Skriv gjerne dette i README-filen:

```text
These accounts are fictional and are only used for testing.
```

Ikke bruk ekte passord, PIN-koder eller personlig informasjon.

---

# Ekstra utfordringer

Gjør disse først etter at hovedoppgaven fungerer.

## Nivå 1: Skjul PIN-koden

Undersøk hvordan man kan lese ett tegn om gangen med:

```csharp
Console.ReadKey(...)
```

Dette er valgfritt og krever litt mer kode.

---

## Nivå 2: Uttaksgebyr

Legg til et gebyr på for eksempel `10 NOK` ved uttak.

Programmet må kontrollere at brukeren har nok penger til:

```text
Uttaksbeløp + gebyr
```

---

## Nivå 3: Kontotype

Lag en ny liste:

```csharp
List<string> accountTypes = ...
```

Eksempler:

```text
Savings
Checking
Business
```

Vis kontotypen under `Account information`.

---

# Læringsmål

Etter oppgaven skal du kunne:

- Bruke flere parallelle lister
- Koble informasjon sammen med samme index
- Finne et element med `IndexOf`
- Kontrollere input med `TryParse`
- Bruke `if`, `else` og `switch` i samme program
- Oppdatere et bestemt element i en liste
- Kontrollere at brukeren har nok saldo
- Skrive tydelige feilmeldinger
- Dokumentere et prosjekt med Markdown

---

# Viktig prinsipp

Informasjon på samme index tilhører samme bruker:

```text
usernames[1]
pinCodes[1]
balances[1]
accountNumbers[1]
```

Alle verdiene på index `1` skal høre sammen.

Senere kan denne løsningen erstattes med klasser og objekter, men parallelle lister er riktig nivå for denne oppgaven.
