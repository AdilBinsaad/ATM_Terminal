public class BankAccount
{
    public int AccountNumber { get; private set; }
    public int Balance { get; private set; }
    private int _pin;

    public BankAccount(int pin, int initialBalance)
    {
        AccountNumber = new Random().Next(100000, 999999);  // สร้างเลขบัญชีสุ่ม
        _pin = pin;
        Balance = initialBalance;
    }

    public bool VerifyPin(int enteredPin)
    {
        return _pin == enteredPin;
    }

    public bool Withdraw(int amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }

    public bool Deposit(int amount)
    {
        Balance += amount;
        return true;
    }

    public bool Transfer(int amount, BankAccount recipient)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            recipient.Deposit(amount);
            return true;
        }
        return false;
    }
}



public class ATM
{
    private BankAccount _account;

    public ATM(BankAccount account)
    {
        _account = account;
    }

    public void WithdrawMoney()
    {
        Console.WriteLine("กรุณากรอกจำนวนเงินที่ต้องการถอน:");
        int amount = Convert.ToInt32(Console.ReadLine());

        if (_account.Withdraw(amount))
        {
            Console.WriteLine($"ถอนเงิน {amount} บาทสำเร็จ");
            // ถามผู้ใช้ว่าต้องการใบเสร็จหรือไม่
            Console.WriteLine("คุณต้องการใบเสร็จหรือไม่?");
            Console.WriteLine("กด 1 : ใช่");
            Console.WriteLine("กด 2 : ไม่");
            int receiptOption = Convert.ToInt32(Console.ReadLine());

            if (receiptOption == 1)
            {
                // หากผู้ใช้ต้องการใบเสร็จ
                Console.WriteLine("ทำรายการสำเร็จ!");
                Console.WriteLine("โปรดรับใบเสร็จของคุณ");
                Console.WriteLine("โปรดรับบัตรของคุณ");
                Console.WriteLine($"กรุณารับเงิน: {amount} บาท ที่ตู้เอทีเอ็ม");
            }
            else
            {
                // หากผู้ใช้ไม่ต้องการใบเสร็จ
                Console.WriteLine("ทำรายการสำเร็จ!");
                Console.WriteLine("โปรดรับบัตรของคุณ");
                Console.WriteLine($"กรุณารับเงิน: {amount} บาท ที่ตู้เอทีเอ็ม");
            }
        }
        else
        {
            Console.WriteLine("ยอดเงินไม่เพียงพอ");
        }
    }

    public void DepositMoney()
    {
        Console.WriteLine("กรุณากรอกจำนวนเงินที่ต้องการฝาก:");
        int amount = Convert.ToInt32(Console.ReadLine());
        if (_account.Deposit(amount))
        {
            Console.WriteLine($"ฝากเงิน {amount} บาทสำเร็จ");
        }
        else
        {
            Console.WriteLine("การฝากเงินล้มเหลว");
        }
    }

    public void TransferMoney()
    {
        Console.WriteLine("กรุณากรอกเลขบัญชีของผู้รับ:");
        int recipientAccountNumber = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("กรุณากรอกจำนวนเงินที่ต้องการโอน:");
        int amount = Convert.ToInt32(Console.ReadLine());

        // สมมุติว่าเรามีการสร้าง BankAccount ของผู้รับ
        BankAccount recipient = new BankAccount(123456, 5000);  // ตัวอย่างเลขบัญชีผู้รับ

        if (_account.Transfer(amount, recipient))
        {
            Console.WriteLine($"โอนเงิน {amount} บาทไปยังบัญชี {recipientAccountNumber} สำเร็จ!");
        }
        else
        {
            Console.WriteLine("การโอนเงินล้มเหลว ยอดเงินของคุณไม่เพียงพอ");
        }
    }

    public int GetBalance()
    {
        return _account.Balance;
    }
}





public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("ยินดีต้อนรับสู่ธนาคาร UBL ATM");
        Console.WriteLine("กรุณาสร้างบัญชีของคุณ");
        Console.WriteLine("กรุณาตั้งรหัส PIN (6 หลัก):");
        int pin = Convert.ToInt32(Console.ReadLine());

        BankAccount userAccount = new BankAccount(pin, 5000); // สร้างบัญชีผู้ใช้
        ATM atm = new ATM(userAccount); // สร้างเครื่อง ATM

        Console.WriteLine("บัญชีของคุณถูกสร้างเรียบร้อยแล้ว!");

        bool isAuthenticated = false;
        while (!isAuthenticated)
        {
            Console.WriteLine("กรุณาป้อน PIN ของคุณ:");
            int enteredPin = Convert.ToInt32(Console.ReadLine());
            if (userAccount.VerifyPin(enteredPin))
            {
                isAuthenticated = true;
                Console.WriteLine("เข้าสู่ระบบสำเร็จ!");
                ShowMenu(atm);
            }
            else
            {
                Console.WriteLine("PIN ไม่ถูกต้อง!");
            }
        }
    }

    static void ShowMenu(ATM atm)
    {
        bool continueTransaction = true;

        while (continueTransaction)
        {
            Console.WriteLine("เลือกการดำเนินการ:");
            Console.WriteLine("กด 1 : ถอนเงิน");
            Console.WriteLine("กด 2 : ฝากเงิน");
            Console.WriteLine("กด 3 : โอนเงิน");
            Console.WriteLine("กด 4 : ตรวจสอบยอดเงิน");
            Console.WriteLine("กด 5 : ออกจากระบบ");

            int selection = Convert.ToInt32(Console.ReadLine());

            switch (selection)
            {
                case 1:
                    atm.WithdrawMoney();
                    break;
                case 2:
                    atm.DepositMoney();
                    break;
                case 3:
                    atm.TransferMoney();
                    break;
                case 4:
                    Console.WriteLine($"ยอดเงินคงเหลือ: {atm.GetBalance()} บาท");
                    break;
                case 5:
                    Console.WriteLine("ออกจากระบบแล้ว");
                    continueTransaction = false;
                    break;
                default:
                    Console.WriteLine("เลือกไม่ถูกต้อง");
                    break;
            }
        }
    }
}
