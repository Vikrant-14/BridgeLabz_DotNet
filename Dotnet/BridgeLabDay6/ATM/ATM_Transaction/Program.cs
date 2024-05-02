using System;

internal class ATM
{
    public double Amount { get; set; }

    public void CashDeposit(double amount)
    {
        if(amount >= 0)
        {
            this.Amount += amount;
        }
        else
        {
            throw new ATMException("Amount should be greater than Zero!!!");
        }
    }

    public void CashWithDrawal(double amount)
    {
        if(amount >= 0 && this.Amount >= 0)
        {
            this.Amount -= amount;

            if (this.Amount < 0)
            {
                this.Amount += amount ;
                
                throw new ATMException("Insufficient Balance!!!");
            }
        }
        else
        {
            throw new ATMException("Amount should be greater than Zero!!!");
        }
    }

    public double CheckBalance()
    {
        return Amount;
    }

    public static int MenuDriven() 
    {
        int choice = 0;

        Console.WriteLine("==================================");
        Console.WriteLine("0. Enter Zero to Exit Application.");
        Console.WriteLine("1. Enter One to Deposit Money.");
        Console.WriteLine("2. Enter Two to WithDraw Money.");
        Console.WriteLine("3. Enter Three to Check Balance.");
        Console.WriteLine("==================================");
        choice = Convert.ToInt32(Console.ReadLine());

        return choice;
    }


    static void Main() 
    {
        int choice = 0;
        ATM a = new ATM();

        while ((choice = MenuDriven()) != 0)
        {
            switch(choice)
            {
                case 1:
                    try
                    {
                        Console.Write("Enter Amount to Deposit: ");
                        double amtDep = Convert.ToDouble(Console.ReadLine());
                        a.CashDeposit(amtDep);
                    }
                    catch(ATMException ex)
                    {
                        Console.WriteLine(ex.Message); 
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                   
                    break;

                case 2:
                    try
                    {
                        Console.Write("Enter Amount to WithDraw: ");
                        double amtWit = Convert.ToDouble(Console.ReadLine());
                        a.CashWithDrawal(amtWit);
                    }
                    catch(ATMException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;

                case 3:
                    Console.WriteLine("Your Available Balance : " + a.CheckBalance());
                    break;
            }
        }
    }


    public class ATMException : Exception 
    {
        public ATMException(string message) : base(message) 
        { 
        }
    }
}