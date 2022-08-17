using FinanceFantasy.Tick;
using UnityEngine;

namespace FinanceFantasy.Bank {
  public abstract class BankOperation {
    public float PaymentTime { get; set; }
    public string Name { get; set; }

    public BankOperation() {
      TickSystem.OnTick += UpdatePaymentTime;
    }

    ~BankOperation() {
      TickSystem.OnTick -= UpdatePaymentTime;
    }

    public abstract void ResetPayTime();

    private void UpdatePaymentTime(object sender, TickSystem.TickEvent tick) {
      if (PaymentTime > 0) {
        PaymentTime--;
      } else {
        Debug.Log("Se acabo el tiempo");
      }
    }
  }
}
