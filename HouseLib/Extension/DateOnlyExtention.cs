namespace HouseLib.Extension
{
  public static class DateOnlyExtention
  {
    public static int Soustract(this DateOnly instance, DateOnly parameter)

    {
      // Convert DateOnly to DateTime
      DateTime startDateTime = parameter.ToDateTime(new TimeOnly(0, 0, 0));
      DateTime endDateTime = instance.ToDateTime(new TimeOnly(0, 0, 0));

      var a = (endDateTime - startDateTime).Days;
      return a;

    }
  }
}

