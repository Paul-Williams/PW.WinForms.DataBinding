namespace PW.WinForms.DataBinding;

internal static class ExtensionMethods
{
  /// <summary>
  /// Performs <paramref name="action"/> for each element in <paramref name="seq"/>
  /// </summary>
  public static void ForEach<T>(this IEnumerable<T> seq!!, Action<T> action!!)
  {
    foreach (T item in seq) action(item);
  }


}
