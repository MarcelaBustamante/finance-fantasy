namespace FinanceFantasy {
  public static class TimeUtils {
    public static string GetFormatTime(float time) {
      var hours = ((int)time / 3600).ToString ("00");
      var module = time % 3600;
      var minutes = ((int)module / 60).ToString ("00");
      var seconds = (module % 60).ToString ("00");
      
      return $"{hours}:{minutes}:{seconds}";
    }
  }
}
