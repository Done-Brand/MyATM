using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ATM
{
    internal class Program
    {
        // C:\Users\Private\Desktop\DONETOETS\ATM
        static int[,] AccountsData;
        static string currentUser;
        static bool UserFound = false;
        static int Cardnumber;
        static int CardPIN;
        static int CheckValue;
        static int MenuOption;
        static bool CheckException;
        static string HistoryBuilder;
        static int UserIndex;
        static string ExceptionFile = "ExceptionHistory.txt";
        
        static string TransationHistoryFile = "TransactionHistory.txt";
        int TransactionType;
        static  string SessionFile = "UserSession.txt";
        static Account[] AccountArray = new Account[3];
        static void Main(string[] args)
        {
            InitializeAccountArray();
            StoreAccountdata();
            StartSession();
            Console.ReadKey();
        }
        
        static void StartSession()
        {
            
            currentUser = SessionRead(SessionFile);
            if (currentUser == null)
            {
                LoginPrompt();
                SessionWrite(SessionFile);

            }
            else
            {
                MainMenu();
            }



        }
        static void MainMenu()
        {
            GetUserIndex();
            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~ATM~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("|           Choose a Desired Option           |");
            Console.WriteLine("| 1: Withdraw Money                           |");
            Console.WriteLine("| 2: Deposit Money                            |");
            Console.WriteLine("| 3: Transfer Money                           |");
            Console.WriteLine("| 4: Check Balance                            |");
            Console.WriteLine("| 5: Check Transaction History                |");
            Console.WriteLine("| 6: Logout                                   |");
            do
            {
                Console.WriteLine("|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
                Console.Write("| Type a Option    ");

                CheckException = Check6InTException ();

            } while (CheckException == true);
            
            MenuOptionProcess(FetchMenuOption(CheckValue));
            
        }
        static int FetchMenuOption(int option)
        {
            MenuOption = option;
            return MenuOption;
        }
        static void MenuOptionProcess(int option)
        {
            

            switch (option)
            {
                case 1:
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("| You have selected Withdraw Money            |");
                    LoadingFlow();
                    WithDrawFunds();
                    break;
                case 2:
                    Console.WriteLine("| You have selected Deposit Money             |");
                    LoadingFlow();
                    DepositFunds();
                    break;
                case 3:
                    Console.WriteLine("| You have selected Transfer Money            |");
                    LoadingFlow();
                    TransferFunds();
                    break;
                case 4:
                    Console.WriteLine("| You have selected Check Balance             |");
                    LoadingFlow();
                    CheckBalance();

                    break;
                case 5:
                    Console.WriteLine("| You have Selected Check Transaction History  |");
                    LoadingFlow();
                    ShowTransactionHistory();
                    break;
                case 6:
                    Console.WriteLine("| You have selected logout                    |");
                    LoadingFlow();
                    Logout();
                    break;
                default:
                    Console.WriteLine("Invalid Selection                             |");
                    LoadingFlow();
                    break;

            }




        }
        static void WithDrawFunds()
        {
            string input;
            double WithDrawAmount=0;
            do
            {
                
                Console.Clear();
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~ATM~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("|           WithDraw Funds                    |");
                Console.WriteLine("|                                             |");
                Console.WriteLine("| CardNumber : " + currentUser + "                      |");
                Console.WriteLine("| Balance    : " + AccountArray[UserIndex].balance + "                          |");
                Console.WriteLine("|                                             |");
                Console.WriteLine("| Type Amount to WithDraw:                                           |");
                Console.WriteLine("|                                             |");
                Console.WriteLine("| Type B to Back                              |");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                input = Console.ReadLine().ToUpper();
                if (input == "B")
                {
                    MainMenu();
                }
                if (input != "B")
                {
                    if (int.TryParse(input, out int number))
                    {
                        WithDrawAmount = double.Parse(input);

                        VerifyFunds(WithDrawAmount);
                    }
                    else
                    {
                        Console.WriteLine("Please Type either B for Back or a Integer to deposit");
                        Thread.Sleep(1000);
                    }
                    
                }
            } while ((input != "B")||(WithDrawAmount == 0 ));

        }
        static void GetUserIndex()
        {
            int i = 0;
            bool found = false;
            string Back = "";
            while ((i < 4) && (found != true))
            {
                if (AccountArray[i].accountNum == int.Parse(currentUser))
                {
                    UserIndex = i;
                    found = true;
                }
                i++;
            }



        }
        static void VerifyFunds(double reqeuestedFunds)
        {
            if (reqeuestedFunds >0) { 
            if (AccountArray[UserIndex].balance >= reqeuestedFunds)
            {
                TransactionHistory(WriteHistory(1, AccountArray[UserIndex].balance, reqeuestedFunds));
                AccountArray[UserIndex].balance = AccountArray[UserIndex].balance - reqeuestedFunds;
            }
            else
            {
                Console.WriteLine("Insuffisunt Funds");
                Thread.Sleep(1000);
            }
            }
            else
            {
                if (reqeuestedFunds <= 0)
                {
                    Console.WriteLine("Please Type a Postive Number");
                    Thread.Sleep(1000);
                }
            }


        }
        static void ClearSession(string SessionFile)
        {
            using (StreamWriter writer = new StreamWriter(SessionFile, false))
            {

                writer.Write(String.Empty);
                writer.Close();
            }
            currentUser = null;
        }
        static void DepositFunds()
        {
            string input;
            double DepositAmount =0;
            do
            {
                Console.Clear();
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~ATM~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("|           Deposit Funds                    |");
                Console.WriteLine("|                                             |");
                Console.WriteLine("| CardNumber : " + currentUser + "                      |");
                Console.WriteLine("| Balance    : " + AccountArray[UserIndex].balance + "                          |");
                Console.WriteLine("|                                             |");
                Console.WriteLine("| Type Amount to Deposit:                                           |");
                Console.WriteLine("|                                             |");
                Console.WriteLine("| Type B to Back                              |");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                input = Console.ReadLine().ToUpper();
                if (input == "B")
                {
                    MainMenu();
                }
                if (input != "B")
                {
                    if (int.TryParse(input, out int number))
                    {
                        DepositAmount = double.Parse(input);
                        if (DepositAmount <= 0)
                        {
                            Console.WriteLine("Please Type a Postive Number");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            TransactionHistory(WriteHistory(2, AccountArray[UserIndex].balance, DepositAmount));
                            AccountArray[UserIndex].balance = AccountArray[UserIndex].balance + DepositAmount;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please Type either B for Back or a Integer to deposit");
                        Thread.Sleep(1000);
                    }

                }
                
            } while ((input != "B") || (DepositAmount <= 0));


        }
        static void TransferFunds()
        {
            string input;
            int User1 = 1;
            int User2 = 2;
            double TransferFund = 0;
            do {
                Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~ATM~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("|           Transfer Funds                    |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("| CardNumber : " + currentUser + "                      |");
            Console.WriteLine("| Balance    : " + AccountArray[UserIndex].balance + "                          |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("| Type 1 or 2 to Transfer to:                                         |");
            switch (UserIndex)
            {
                case 1:
                    User1 = 2;
                    User2 = 3;
                    break;
                case 2:
                    User1 = 1;
                    User2 = 3;
                    break;
                case 3:
                    User1 = 1;
                    User2 = 2;
                    break;
                default:
                    break;

            }
            Console.WriteLine("|                                             |");
            Console.WriteLine("| 1: CardNumber : " + AccountArray[User1].accountNum + "                      |");
            Console.WriteLine("| 2: CardNumber : " + AccountArray[User2].accountNum + "                      |");

            Console.WriteLine("| Type B to Back                              |");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            input = Console.ReadLine().ToUpper();
            if (input == "B")
            {
                MainMenu();
            }
            if (input != "B")
            {
                if (int.TryParse(input, out int number))
                {
                    if (number == 1)
                    {
                        Console.WriteLine("|                                             |");
                        Console.WriteLine("| Type Amount to Transfer:                     |");
                        TransferFund = int.Parse(Console.ReadLine());
                        TransactionHistory(WriteHistory(3, AccountArray[UserIndex].balance, TransferFund));
                        AccountArray[User1].balance = AccountArray[User1].balance + TransferFund;
                        AccountArray[UserIndex].balance = AccountArray[UserIndex].balance - TransferFund;

                        }
                    if (number == 2)
                    {
                        Console.WriteLine("|                                             |");
                        Console.WriteLine("| Type Amount to Transfer:                     |");
                        TransferFund = int.Parse(Console.ReadLine());
                        TransactionHistory(WriteHistory(3, AccountArray[UserIndex].balance, TransferFund));
                        AccountArray[User2].balance = AccountArray[User2].balance + TransferFund;
                        AccountArray[UserIndex].balance = AccountArray[UserIndex].balance - TransferFund;
                          
                        }
                        if ((number > 2) || (number < 1))
                        {
                            Console.WriteLine("Choose one of the cardnumbers that is provided in the list above");
                            Thread.Sleep(1000);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please Type either B for Back or a Integer to deposit");
                        Thread.Sleep(1000);
                    }

                }
        } while ((input != "B") || (TransferFund == 0));
        }
        static void CheckBalance()
        {
            double balance = 0;
            int i = 0;
            bool found = false;
            string Back = "";
            while ((i < 4)&&(found!=true))
            {
                if (AccountArray[i].accountNum == int.Parse(currentUser))
                {
                    balance = AccountArray[i].getBalance();
                    found = true;
                }
                i++; 
            }
            
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~ATM~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("|           Check Balance                     |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("| CardNumber : "+ currentUser +"                      |");
            Console.WriteLine("| Balance    : "+ balance + "                          |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("| B : Back                                    |");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            do
            {
                Back = Console.ReadLine().ToUpper();
                if (Back == "B")
                {
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("Please type B to go back");
                }
            } while (Back != "B");

        }
        static void LogException( string ExceptionWriteString)
        {
            using (StreamWriter writer = new StreamWriter(ExceptionFile, true))
            {

                writer.WriteLine(ExceptionWriteString);
                writer.Close();

            }


        }
        static void ShowTransactionHistory()
        {
            string Back;
            Console.WriteLine("~~ATM~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("| Transaction History ");
            using (StreamReader reader = new StreamReader(TransationHistoryFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine("| " + line + "  |");
                }
            }
                     
            Console.WriteLine("|");
            Console.WriteLine("| B : Back ");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            do
            {
                Back = Console.ReadLine().ToUpper();
                if (Back == "B")
                {
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("Please type B to go back");
                }
            } while (Back != "B");

        }
        static void TransactionHistory(string HistoryWriteString)
        {
            using (StreamWriter writer = new StreamWriter(TransationHistoryFile,true))
            {
               
                writer.WriteLine(HistoryWriteString);
                writer.Close();
                               
            }


        }
        static string WriteHistory(int TransactionType,double TransactionBalance, double TransacionFund)
        {
            string currentDateTimeString = DateTime.Now.ToString();
            switch (TransactionType)
            {
                case 1:
                    HistoryBuilder = " User : " +
                       currentUser + " Previous Balance : " +
                       TransactionBalance + " , WithDraw : " +
                       TransacionFund + " Current balance : " +
                       (TransactionBalance - TransacionFund) +
                       " Date and Time : " + currentDateTimeString;
                    return HistoryBuilder;
                    break;
                case 2:
                    HistoryBuilder = " User : " + 
                        currentUser + " Previous Balance : " + 
                        TransactionBalance + " , Deposited : " +
                        TransacionFund + " Current balance : " +
                        (TransactionBalance+ TransacionFund) + 
                        " Date and Time : "+ currentDateTimeString;
                    return HistoryBuilder;
                    break;
                case 3:
                    HistoryBuilder = " User : " +
                       currentUser + " Previous Balance : " +
                       TransactionBalance + " , Transfered : " +
                       TransacionFund + " Current balance : " +
                       (TransactionBalance - TransacionFund) +
                       " Date and Time : " + currentDateTimeString;
                    return HistoryBuilder;
                    break;
                default:
                    HistoryBuilder = "Transaction Failed";  
                    return HistoryBuilder;
                    break;

            }

           



        }
        static void Logout()
        {

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~ATM~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("|                Logging Out                  |");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            ClearSession(SessionFile);
            LoadingFlow();
            StartSession();

        }
        static void LoadingFlow()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(700);
            }
            Console.Clear();
        }
        static void SessionWrite(string SessionFile)
        {
            using (StreamWriter writer = new StreamWriter(SessionFile))
            {
                Console.WriteLine("Current User = " + currentUser);
                Thread.Sleep(2000);
                Console.WriteLine("Redirecting to Main Menu");
                Thread.Sleep(1000);
                LoadingFlow();
                           
                writer.WriteLine(currentUser);
                writer.Close();

                MainMenu();
            }

        }
        static string SessionRead(string SessionFile)
        {
            if (File.Exists(SessionFile))
            {
                string[] lines = File.ReadAllLines(SessionFile);
                if (lines.Length == 0)
                {
                                     
                    return null;
                }
                foreach (string line in lines)
                {
                    currentUser = lines[0];
                    return currentUser;
                }
            }
            else
            {
                                
                return null;
               
            }

            return null;

        }
      static  void LoginPrompt()
        {
            CheckException = false;

            do
            {
                do
                {
                    CheckException = false;
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~ATM~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("|           Welcome to Online ATM            |");
                    Console.WriteLine("| Please Enter Your Card number Below :      |");


                    CheckException = CheckINTexception();
                    
                   
                } while (CheckException == true);

                Cardnumber = CheckValue;
                
                do {
                    Console.WriteLine("| Please Enter You PIN Below :               |");
                    CheckException = CheckINTexception();
                    CardPIN = CheckValue;
                } while (CheckException == true);

                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                UserFound = VerifyLogindetails(Cardnumber, CardPIN);

            } while (UserFound == false);



            if (UserFound == true)
            {
                
                Console.Clear();
                currentUser =Convert.ToString(Cardnumber);
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~ATM~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("| Login Succesfull !                         |");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Thread.Sleep(2000); // Delay of 1 second (1000 milliseconds)
            }



      }
       static bool Check6InTException()
        {

            String ExceptionWriteString;
            string currentDateTimeString = DateTime.Now.ToString();

            try
            {
                CheckValue = int.Parse(Console.ReadLine());
            }
            catch (OverflowException e)
            {
                ExceptionWriteString = "Please Type a Integer smaller than 2 digits(" + e.Message + ") Date of Exception : " + currentDateTimeString;

                LogException(ExceptionWriteString);
                Console.Write(ExceptionWriteString);
                Thread.Sleep(2000);
                return CheckException = true;
            }
            catch (FormatException e)
            {
                ExceptionWriteString = "Please Type a Integer NOT Text(" + e.Message + ") Date of Exception : " + currentDateTimeString;

                LogException(ExceptionWriteString);
                Console.Write(ExceptionWriteString);
                
                Thread.Sleep(2000);
                return CheckException = true;
            }
            if ((CheckValue < 7) && (CheckValue > 0))
            {
                return CheckException = false;
            }
            else
            {
                ExceptionWriteString = "Please Choose from 1- 6 , Date of Exception : " + currentDateTimeString;

                LogException(ExceptionWriteString);
                Console.Write(ExceptionWriteString);
                return CheckException = true;

            }
        }
            static bool CheckINTexception()
        {
            String ExceptionWriteString;
            string currentDateTimeString = DateTime.Now.ToString();
            try
            {
                CheckValue = int.Parse(Console.ReadLine());
            }
            catch (OverflowException e)
            {
                ExceptionWriteString = "Please Type a Integer smaller than 9 digits(" + e.Message + ") Date of Exception : " + currentDateTimeString;

                LogException(ExceptionWriteString);
                Console.Write(ExceptionWriteString);

                                Thread.Sleep(2000);
                return CheckException = true;
            }
            catch (FormatException e)
            {
                ExceptionWriteString = "Please Type a Integer NOT Text(" + e.Message + ") Date of Exception : " + currentDateTimeString;

                LogException(ExceptionWriteString);
                Console.Write(ExceptionWriteString);
                               
                Thread.Sleep(2000);
                 return CheckException = true;
            }
              return CheckException =false;
        }
      static  bool VerifyLogindetails(int num, int pin)
        {

            foreach (Account account in AccountArray)
            {
                if (account.accountNum == num && account.pin == pin)
                {

                    return true; 
                }
            }

            return false;
        }
       static void InitializeAccountArray()
        {
            AccountsData = new int[3, 3]{
        { 123456789, 1234, 1000 },
        { 0876543210, 5678, 2000 },
        { 0987654321, 8765, 3000 }
    };
            
        }
      static  void StoreAccountdata()
        {

            


            for (int i = 0; i < 3; i++)
            {
                int accountNum = AccountsData[i, 0];
                int pin = AccountsData[i, 1];
                double balance = AccountsData[i, 2];

                Account account = new Account(accountNum, pin, balance);
                AccountArray[i] = account;
            }


        }
        //#region Get Functions
        //public void testc()
        //{

        //}
        //#endregion
    }
}
