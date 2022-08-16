using UnityEngine;

namespace FinanceFantasy.Bank {
  
  /**
   * This should be MonoBehaviour if there are multiple banks, probabilities of distinct credit cards, etc.
   * As this will not be the case, for now, we will leave it as a simple class
   */
  public class BankController {
    public CreditCard TakeCreditCard(int nextPayTime) {
      return new CreditCard(nextPayTime, 1000f);
    }

    public Loan TakeLoan(float loanAmount, int nextPayTime) {
      return new Loan(loanAmount, nextPayTime);
    }

    public Insurance TakeInsurance() {
      return new Insurance(1000f);
    }
  }
}