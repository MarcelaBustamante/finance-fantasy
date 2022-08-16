namespace FinanceFantasy.Bank {
  public class Insurance : BankOperation {
    private float _costInsurance;

    public Insurance(float costInsurance) {
      this._costInsurance = costInsurance;
    }

    public override void ResetPayTime() {}
  }
}