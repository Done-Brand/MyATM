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



<!-- TABLE OF CONTENTS -->
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



<!-- ABOUT THE PROJECT -->
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


<!-- GETTING STARTED -->
## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.
* npm
  ```sh
  npm install npm@latest -g
  ```

### Installation

_Below is an example of how you can instruct your audience on installing and setting up your app. This template doesn't rely on any external dependencies or services._

1. Get a free API Key at [https://example.com](https://example.com)
2. Clone the repo
   ```sh
   git clone https://github.com/your_username_/Project-Name.git
   ```
3. Install NPM packages
   ```sh
   npm install
   ```
4. Enter your API in `config.js`
   ```js
   const API_KEY = 'ENTER YOUR API';
   ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

This is how the project desktop looks like. A you can see there are different options to choose from and it is easily navigated from here.
![FrontPage](https://github.com/Done-Brand/MyATM/assets/111229240/c5eb98e7-99f8-444a-9d90-cde484175f39)


After you have signed in you will see this page - Please see above the Account numbers and PINs.
![ProjectDesktop](https://github.com/Done-Brand/MyATM/assets/111229240/32549f7a-a662-4166-a559-5396948bb16f)

It is easily naviagted from here, there are also a text file updating with every transaction made by a specific useer.
![TransactionHistory](https://github.com/Done-Brand/MyATM/assets/111229240/5d550ba1-2e6c-4401-827f-546d8b2157af)

With another file displaying each exception as well as the date and time, to review what went wrong.
![ExceptionHistoy](https://github.com/Done-Brand/MyATM/assets/111229240/a3e9eb49-67ec-4e79-b2d5-ca450b7df03e)


<!-- CONTACT -->
## Contact

Doné Barnd - donedev8@gmail.com




<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/othneildrew/Best-README-Template.svg?style=for-the-badge
[contributors-url]: https://github.com/othneildrew/Best-README-Template/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/othneildrew/Best-README-Template.svg?style=for-the-badge
[forks-url]: https://github.com/othneildrew/Best-README-Template/network/members
[stars-shield]: https://img.shields.io/github/stars/othneildrew/Best-README-Template.svg?style=for-the-badge
[stars-url]: https://github.com/othneildrew/Best-README-Template/stargazers
[issues-shield]: https://img.shields.io/github/issues/othneildrew/Best-README-Template.svg?style=for-the-badge
[issues-url]: https://github.com/othneildrew/Best-README-Template/issues
[license-shield]: https://img.shields.io/github/license/othneildrew/Best-README-Template.svg?style=for-the-badge
[license-url]: https://github.com/othneildrew/Best-README-Template/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/othneildrew
[product-screenshot]: images/screenshot.png
[Next.js]: https://img.shields.io/badge/next.js-000000?style=for-the-badge&logo=nextdotjs&logoColor=white
[Next-url]: https://nextjs.org/
[React.js]: https://img.shields.io/badge/React-20232A?style=for-the-badge&logo=react&logoColor=61DAFB
[React-url]: https://reactjs.org/
[Vue.js]: https://img.shields.io/badge/Vue.js-35495E?style=for-the-badge&logo=vuedotjs&logoColor=4FC08D
[Vue-url]: https://vuejs.org/
[Angular.io]: https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white
[Angular-url]: https://angular.io/
[Svelte.dev]: https://img.shields.io/badge/Svelte-4A4A55?style=for-the-badge&logo=svelte&logoColor=FF3E00
[Svelte-url]: https://svelte.dev/
[Laravel.com]: https://img.shields.io/badge/Laravel-FF2D20?style=for-the-badge&logo=laravel&logoColor=white
[Laravel-url]: https://laravel.com
[Bootstrap.com]: https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white
[Bootstrap-url]: https://getbootstrap.com
[JQuery.com]: https://img.shields.io/badge/jQuery-0769AD?style=for-the-badge&logo=jquery&logoColor=white
[JQuery-url]: https://jquery.com 
