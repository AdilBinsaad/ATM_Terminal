# ATM MACHINE USING C#-OOP


# Description
This ATM (Automated Teller Machine) system is a console-based application implemented in C#. The primary goal of this project is to simulate the functionalities of a real-world ATM machine, providing users with a convenient way to perform banking transactions.

# Overview
This project is an implementation of an ATM (Automated Teller Machine) system in C#. It provides basic functionalities such as withdrawing money, depositing money, checking balance, and transferring funds between accounts.

# Clone this repository:
   git clone https://github.com/ahsan54/ATM_Terminal.git

# Motivation
The motivation behind this project stems from the desire to understand and implement fundamental concepts of object-oriented programming and software engineering principles in a practical scenario. By building this ATM machine, I aimed to strengthen my skills in C# programming, data handling, and user interface design.

# Features Overview
Withdrawal: Users can withdraw cash from their account, with options for selecting different denominations.
Deposit: Users can deposit cash into their account, which gets reflected in their balance.
Balance Inquiry: Users can check their account balance at any time during their session.
Transfer: Users can transfer funds between their own accounts or to other accounts within the system.
PIN Security: The system ensures security by requiring users to authenticate themselves with a PIN before accessing their account.

# License
Feel free to customize this template according to your specific project details and requirements!


## CODE

using System;

public class Program
{
    private int _amountToWithdraw;
    private const int Amount1 = 1000;
    private const int Amount2 = 5000;
    private int _recept;
    private int _opeartingSelectionOnAcc;
    private int _rsi;
    private int _amntsnd;

    void Receipt1()
    {
        Console.WriteLine("ARE U WANA RECEIPT");
        Console.WriteLine("YES : PRESS 1 ");
        Console.WriteLine("NOT : PRESS 2 ");
        _recept = Convert.ToInt32(Console.ReadLine());
        if (_recept == 1)
        {
            Console.WriteLine("TRANSACTION-SUCCESSFUL");
            Console.WriteLine("Take your receipt from R-box ");
            Console.WriteLine("PLEASE TAKE YOUR CARD");
            Console.WriteLine("COLLECT YOUR : " + Amount1 + " AT TERMINAL");
        }
        else if (_recept == 2)
        {
            Console.WriteLine("TRANSACTION-SUCCESSFUL");
            Console.WriteLine("PLEASE TAKE YOUR CARD");
            Console.WriteLine("COLLECT YOUR : " + Amount1 + " AT TERMINAL");
        }
    }

    void Receipt2()
    {
        Console.WriteLine("ARE U WANA RECEIPT");
        Console.WriteLine("YES : PRESS 1 ");
        Console.WriteLine("NOT : PRESS 2 ");
        _recept = Convert.ToInt32(Console.ReadLine());
        if (_recept == 1)
        {
            Console.WriteLine("TRANSACTION-SUCCESSFUL");
            Console.WriteLine("Take your receipt from R-box ");
            Console.WriteLine("PLEASE TAKE YOUR CARD");
            Console.WriteLine("COLLECT YOUR : " + Amount2 + " AT TERMINAL");
        }
        else if (_recept == 2)
        {
            Console.WriteLine("TRANSACTION-SUCCESSFUL");
            Console.WriteLine("PLEASE TAKE YOUR CARD");
            Console.WriteLine("COLLECT YOUR : " + Amount2 + " AT TERMINAL");
        }
    }

    void Receipt3()
    {
        Console.WriteLine("ARE U WANA RECEIPT");
        Console.WriteLine("YES : PRESS 1 ");
        Console.WriteLine("NOT : PRESS 2 ");
        _recept = Convert.ToInt32(Console.ReadLine());
        if (_recept == 1)
        {
            Console.WriteLine("TRANSACTION-SUCCESSFUL");
            Console.WriteLine("Take your receipt from R-box ");
            Console.WriteLine("PLEASE TAKE YOUR CARD");
            Console.WriteLine("COLLECT " + _amountToWithdraw + " AT TERMINAL");
        }
        else if (_recept == 2)
        {
            Console.WriteLine("TRANSACTION-SUCCESSFUL");
            Console.WriteLine("PLEASE TAKE YOUR CARD");
            Console.WriteLine("COLLECT " + _amountToWithdraw + " AT TERMINAL");
        }
    }

    public void Account()
    {
        Console.WriteLine("PRESS 1 FOR : Amount-Withdraw");
        Console.WriteLine("PRESS 2 FOR : Amount-Send");
        Console.WriteLine("PRESS 3 FOR : Balance Check");
        _opeartingSelectionOnAcc = Convert.ToInt32(Console.ReadLine());
        if (_opeartingSelectionOnAcc == 1)
        {
            Console.WriteLine("Enter Amount Here: ");
            Console.WriteLine("FOR 1000 : PRESS 1");
            Console.WriteLine("FOR 5000 : PRESS 2");
            Console.WriteLine("FOR CUSTOM : PRESS 3");
            _amountToWithdraw = Convert.ToInt32(Console.ReadLine());
            if (_amountToWithdraw == 1)
            {
                Receipt1();
            }
            else if (_amountToWithdraw == 2)
            {
                Receipt2();
            }
            else
            {
                Console.WriteLine("ENTER AMOUNT FOR WITHDRAWL");
                _amountToWithdraw = Convert.ToInt32(Console.ReadLine());
                if (_amountToWithdraw >= 12000)
                {
                    Console.WriteLine("TRANSACTION FAILED");
                    Console.WriteLine("AMOUNT EXCEEDS LIMIT");
                }
                else if (_amountToWithdraw <= 10000)
                {
                    Receipt3();
                }
            }
        }
        else if (_opeartingSelectionOnAcc == 2)
        {
            Console.WriteLine("ENTER 4-Digit--ACT-NUMBER  OF RECEIVER");
            _rsi = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ENTER  AMOUNT :");
            _amntsnd = Convert.ToInt32(Console.ReadLine());
            if (_amntsnd <= 100000)
            {
                Console.WriteLine(
                    "AMOUNT :" + _amntsnd + " TRANSFERRED SUCCESSFULLY" + " " + "TO : " + _rsi);
            }
            else if (_amntsnd >= 100001)
            {
                Console.WriteLine("AMOUNT EXCEEDS THE LIMIT");
                Console.WriteLine("TRANSACTION IMPOSSIBLE");
            }
        }
        else
        {
            Console.WriteLine("CURRENT BALANCE IS : ($)5M-USD ");
        }
    }
}

public class Transaction : Mains
{
    private Program _obj = new Program();

    public void EnterPin()
    {
        Console.WriteLine("Enter Pin :");
        var Pins = Convert.ToInt32(Console.ReadLine());
        if (Pins == Pin)
        {
            Console.WriteLine("Welcome To Atm!");
            Console.WriteLine("Select Acc-Type:");
            Console.WriteLine("1 For : Current-Acc");
            Console.WriteLine("2 For : Business-Acc");
            Console.WriteLine("3 For : Savings-Acc");
            var askAccType = Convert.ToInt32(Console.ReadLine());
            if (askAccType == 1)
            {
                Console.WriteLine("You Selected : Current-Acc ");
                Console.WriteLine("Select Operation : ");
                _obj.Account();
            }
            else if (askAccType == 2)
            {
                Console.WriteLine("You Selected : Business-Acc ");
                Console.WriteLine("Select Operation : ");
                _obj.Account();
            }
            else if (askAccType == 3)
            {
                Console.WriteLine("You Selected : Savings-Acc ");
                Console.WriteLine("Select Operation : ");
                _obj.Account();
            }
        }
        else if (Pins != Pin)
        {
            Console.WriteLine("Invalid Pin!");
            Console.WriteLine("Press 1 For :==> Retry ");
            Console.WriteLine("Press 2 For :==> Forget Pin ");
            Console.WriteLine("Press 3 For :==> Session Ending ");
            int invalidPinTry = Convert.ToInt32(Console.ReadLine());
            switch (invalidPinTry)
            {
                case 1:
                    EnterPin();
                    break;
                case 2:
                    Console.WriteLine("Enter Your Access-Acc-On-ForgetPin  Here: ");
                    int forgetAccessPin = Convert.ToInt32(Console.ReadLine());
                    if (forgetAccessPin == AcessAccOnForgetPin)
                    {
                        Console.WriteLine("Wait While We Retrieve Your Pin...");
                        Console.WriteLine("Pin : " +Pin);
                    }
                    else if (forgetAccessPin != AcessAccOnForgetPin)
                    {
                        Console.WriteLine("Session Expired ");
                        Console.WriteLine("!!!");
                    }
                    break;
                case 3:
                    Console.WriteLine("Transaction Failed!");
                    break;
            }
        }
    }
}

public class Mains
{
    static Transaction obj6 = new Transaction();
    private Program obj = new Program();

    public static int AcessAccOnForgetPin;
    public static string FirstName;
    public static string lastName;
    public static int cnic;
    public static int Pin;

    public static void Main(string[] args)
    {
        Console.Write("Welcome To United Bank Limited ATM");
        Console.WriteLine(":==> Create Account...");
        Console.WriteLine("Enter Your First Name:");
        FirstName = Console.ReadLine();
        Console.Write("Enter Your Last Name:");
        lastName = Console.ReadLine();
        Console.WriteLine("Enter CNIC Here: ");
        cnic = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Create A 5-Digit Pin Here: ");
        Pin = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Access-Acc-On-ForgetPin: ");
        AcessAccOnForgetPin = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("       ");
        Console.WriteLine("       ");
        Console.WriteLine("       ");
        Console.WriteLine("       ");

        Console.WriteLine("Account Creation Completed!");
        Console.WriteLine("Welcome To United Bank Limited ATM");
        Console.Write("Press 1 : For Accessing Account      ");
        Console.Write("Press 2 : For Session Termination    ");
        var choiceAfterAccCreation = Convert.ToInt32(Console.ReadLine());
        if (choiceAfterAccCreation == 1)
        {
            obj6.EnterPin();
        }
        else if (choiceAfterAccCreation == 2)
        {
            Console.WriteLine("Terminated");
        }
    }
}













