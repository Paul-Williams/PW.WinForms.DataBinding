using System.Linq.Expressions;

namespace PW.WinForms.DataBinding;

public partial class Binder<TDataSource> where TDataSource : class
{
  /// <summary>
  /// Binds the <see cref="RadioButton"/> to a boolean value on the controller.
  /// </summary>
  public Binder<TDataSource> BindChecked<TProperty>(RadioButton control!!, Expression<Func<TDataSource, TProperty>> property!!, bool initialValue)
  {
    // RadioButtons automatically have their value set, as a group, within a container.
    // If the binding is not set to never, then the selected radio button cannot be changed by clicking in the UI.
    // A side-effect of this is that the control does not get initialized to the binding.
    // Therefore we use the initialValue argument to set one to true, as required.

    var b = new Binding(nameof(control.Checked), DataSource, property.PropertyName(), true, DataSourceUpdateMode)
    {
      ControlUpdateMode = ControlUpdateMode.Never
    };
    control.DataBindings.Add(b);
    if (initialValue) control.Checked = true;
    return this;
  }

  /// <summary>
  /// Performs an action on the controller when the <see cref="RadioButton"/> is clicked.
  /// </summary>
  public Binder<TDataSource> BindClick<TProperty>(RadioButton control!!, Action<TDataSource> action!!)
  {
    control.Click += (s, e) => action.Invoke(DataSource);
    return this;
  }

}
