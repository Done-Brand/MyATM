using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class Account
    {
        public int accountNum;
        public int pin;
        public double balance;

        public Account(int accountNum, int pin, double balance)
        {
            this.accountNum = accountNum;
            this.pin = pin;
            this.balance = balance;
        }

        public int getAccNum()
        {
            return accountNum;
        }

        public int getPin()
        {
            return pin;
        }

        public double getBalance()
        {
            return balance;
        }

        public void setAccNum(int newAccountNum)
        {
            accountNum = newAccountNum;
        }

        public void setPin(int newPin)
        {
            pin = newPin;
        }

        public void setBalance(double newBalance)
        {
            balance = newBalance;
        }
    }

}
