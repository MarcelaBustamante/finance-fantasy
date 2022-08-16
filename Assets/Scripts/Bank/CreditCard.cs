using System.Collections.Generic;
using UnityEngine;

namespace FinanceFantasy.Bank {
  public class CreditCard : BankOperation {
    public float PayTimeInSeconds { get; private set; }
    private string _cardNumber;
    public float MouthPayment { get; private set; }
    public float PaymentLimit { get; private set; }
    public Dictionary<string, float> PaymentDetail { get; private set; }

    public CreditCard(int payTimeInSeconds, float payLimit) {
      _cardNumber = BankUtils.Create16DigitString();
      this.Name = "Credit card";
      MouthPayment = 0f;
      PaymentLimit = payLimit;
      PaymentDetail = new Dictionary<string, float>();
      PayTimeInSeconds = payTimeInSeconds;
      ResetPayTime();
    }

    public sealed override void ResetPayTime() {
      this.PaymentTime = this.PayTimeInSeconds;
    }
  }
}