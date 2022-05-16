using System.Linq.Expressions;

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

  /// <summary>
  /// Returns the property name given an expression such as: x => x.MyProperty 
  /// </summary>
  public static string PropertyName<T,P>(this Expression<Func<T, P>> propertyExpression)
  {
    var member = ((MemberExpression)propertyExpression.Body).Member;

    return member.MemberType == System.Reflection.MemberTypes.Property
      ? member.Name
      : throw new ArgumentException($"{typeof(T).FullName}.{member.Name} is not Property.");
  }


}
