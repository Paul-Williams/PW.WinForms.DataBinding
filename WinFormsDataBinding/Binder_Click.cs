using System.Linq.Expressions;

namespace PW.WinForms.DataBinding;

// Contains methods for binding control click events to the data source.

public partial class Binder<TDataSource> where TDataSource : class
{


  /// <summary>
  /// Binds the control's click event to a method on the data source which takes a single parameter of type <typeparamref name="TArg"/>.
  /// </summary>
  public Binder<TDataSource> BindClick<TArg>(Control control!!, Func<TDataSource, Action<TArg>> to!!)
  {
    control.Click += (o, e) => to.Invoke(DataSource);
    return this;
  }

  /// <summary>
  /// Binds the control's click event to an Action which takes the <typeparamref name="TDataSource"/> as a parameter.
  /// </summary>
  public Binder<TDataSource> BindClick(Control control!!, Action<TDataSource> to!!)
  {
    control.Click += (o, e) => to.Invoke(DataSource);
    return this;
  }

  /// <summary>
  /// Binds the control's click event to a parameterless method on the data source.
  /// </summary>
  /// <param name="control">Control for which the click event will be bound.</param>
  /// <param name="to">Function returning the method on the data source to which to bind.</param>
  public Binder<TDataSource> BindClick(Control control!!, Func<TDataSource, Action> to!!)
  {
    control.Click += (o, e) => to.Invoke(DataSource)();
    return this;
  }

  /// <summary>
  /// Binds the control's click-event to a parameterless method and it's enabled-state to a property on the data source.
  /// </summary>
  /// <param name="control">Control for which the click event will be bound.</param>
  /// <param name="executeMethod">Function returning the method on the data source to which to bind.</param>
  /// <param name="toEnabled">Property on the data source used to set the enabled state of the control.</param>
  public Binder<TDataSource> BindClick<TProperty>(Control control!!, Func<TDataSource, Action> executeMethod!!, Expression<Func<TDataSource, TProperty>> enabledProperty!!)
  {
    control.Click += (o, e) => executeMethod.Invoke(DataSource)();
    BindEnabled(control, enabledProperty);
    return this;
  }



}
