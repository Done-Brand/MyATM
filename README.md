<a name="readme-top"></a>

<div align="center">

  <h3 align="center">MyATM</h3>

  <p align="center">
    ATM with basic banking transaction functionalitites
    <br />
    <br />
    <a href="https://github.com/othneildrew/Best-README-Template">View Demo</a>
    ·
    <a href="https://github.com/othneildrew/Best-README-Template/issues">Report Bug</a>
    ·
    <a href="https://github.com/othneildrew/Best-README-Template/issues">Request Feature</a>
  </p>
</div>

<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>

## About The Project

Using C# I wrote a console application that simulated an Automated Teller Machine.

Features:
* A login screen that requires the user to enter their account number and PIN.
* An interface that displays the user's account balance and allows them to perform various transactions, such as
withdrawing funds, depositing funds, and transferring funds.
* The ability to verify that the user has sufficient funds or a valid account before completing any transactions.
* An error-handling mechanism that ensures that the program can handle unexpected input or execute without errors.
* Logging functionality that records user transactions and system exceptions for later auditing purposes.
* The program assumes there are only three pre-existing accounts, which are initialized in the accounts array.
* The program uses a do-while loop to repeatedly prompt the user to enter their account number and PIN until valid
credentials are entered.
* The program uses a switch statement to process the user's choice from the main menu. The withdraw, deposit, and
transfer functions all modify the account balance by reference, so changes made to the account balance are persistent
across menu choices.

(Account No, PIN)
(1234567890, "1234"),
(0876543210, "5678"),
(0987654321, "8765")

## Getting Started
To run this project locally follow the following steps

### Installation

1. Download the entire project folder from github
2. Paste the project folder in any directory that does not need admin privillages.
3. Open Visual studio and navigate tot the "File" -> "Open" -> "Project", search for the directory of the Atm project
4. Click Run on Visual Studio!

## Usage

This is how the project desktop looks like. A you can see there are different options to choose from and it is easily navigated from here.
![FrontPage](https://github.com/Done-Brand/MyATM/assets/111229240/c5eb98e7-99f8-444a-9d90-cde484175f39)


After you have signed in you will see this page - Please see above the Account numbers and PINs.
![ProjectDesktop](https://github.com/Done-Brand/MyATM/assets/111229240/32549f7a-a662-4166-a559-5396948bb16f)

It is easily naviagted from here, there are also a text file updating with every transaction made by a specific user.
![TransactionHistory](https://github.com/Done-Brand/MyATM/assets/111229240/5d550ba1-2e6c-4401-827f-546d8b2157af)

With another file displaying each exception as well as the date and time, to review what went wrong.
![ExceptionHistoy](https://github.com/Done-Brand/MyATM/assets/111229240/a3e9eb49-67ec-4e79-b2d5-ca450b7df03e)

## Contact

Doné Brand - donedev8@gmail.com
