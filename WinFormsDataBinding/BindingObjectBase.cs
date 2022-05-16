using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PW.WinForms.DataBinding;

/// <summary>
/// Base class for objects supporting <see cref="INotifyPropertyChanged"/>
/// </summary>
public abstract class BindingObjectBase : INotifyPropertyChanged
{
  /// <summary>
  /// Raised when a property changes
  /// </summary>
  public event PropertyChangedEventHandler? PropertyChanged;

  /// <summary>
  /// Raises the <see cref="PropertyChangedEventHandler"/>
  /// </summary>
  /// <param name="propertyName"></param>
  protected void OnPropertyChanged(string? propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

  /// <summary>
  /// Sets a property's backing field to the new value and raises the <see cref="PropertyChanged"/> event, but only if the existing and new values are not equal. 
  /// Returns true if the property's value was changed, otherwise false.
  /// </summary>
  /// <typeparam name="T">The type of the property.</typeparam>
  /// <param name="backingField">A reference to the property's backing field.</param>
  /// <param name="value">The new value for the backing field.</param>
  /// <param name="propertyName">The name of the property being changed. If omitted <see cref="CallerMemberNameAttribute"/> is used to obtain a value.</param>
  /// <returns>Returns true if the property's value was changed, otherwise false.</returns>
  protected bool SetPropertyValue<T>(ref T backingField, T value, [CallerMemberName] string? propertyName = null)
  {
    if (EqualityComparer<T>.Default.Equals(backingField, value)) return false;
    backingField = value;
    OnPropertyChanged(propertyName);
    return true;
  }


}
