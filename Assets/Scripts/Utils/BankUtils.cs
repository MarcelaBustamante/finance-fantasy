using System;
using System.Text;

namespace FinanceFantasy.Bank {
  public static class BankUtils {
    private static Random RNG = new Random();
    
    public static string Create16DigitString() {
      var builder = new StringBuilder();
      while (builder.Length < 16) {
        builder.Append(RNG.Next(10).ToString());
      }
      
      return builder.ToString();
    }
  }
}