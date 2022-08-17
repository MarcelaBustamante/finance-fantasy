using UnityEngine;

namespace FinanceFantasy.Bank {
  public class Loan : BankOperation {
    public float PayTimeInSeconds { get; private set; }
    public float LoanAmount { get; private set; }
    public float MonthlyInstallments { get; private set; }
    public int PaidInstallments { get; set; }

    public int TotalInstallments = 12;

    public Loan(float amount, float time) {
      this.LoanAmount = amount;
      this.PayTimeInSeconds = time;
      this.MonthlyInstallments = LoanAmount / TotalInstallments;
      this.PaidInstallments = 0;
      this.Name = "Loan";

      ResetPayTime();
    }
    
    public sealed override void ResetPayTime() {
      this.PaymentTime = this.PayTimeInSeconds;
    }
  }
}