using System.Linq.Expressions;
using static PW.WinForms.DataBinding.ExtensionMethods;

namespace PW.WinForms.DataBinding;

/// <summary>
/// Used to bind a single data source to one or more controls.
/// Is just a simple wrapper around standard binding, but with simpler syntax.
/// This class will be extended as requirements arise for more controls and properties to be bound.
/// </summary>
/// <typeparam name="TDataSource"></typeparam>
public partial class Binder<TDataSource> where TDataSource : class
{

  /// <summary>
  /// 
  /// </summary>
  public Binder<TDataSource> BindChecked<TProperty>(CheckBox control!!, Expression<Func<TDataSource, TProperty>> property!!)
  {
    var b = new Binding(nameof(control.Checked), DataSource, property.PropertyName(), true, DataSourceUpdateMode);
    control.DataBindings.Add(b);
    return this;
  }

  /// <summary>
  /// Binds the <see cref="Control.Enabled"/> property
  /// </summary>
  /// <param name="control"></param>
  /// <param name="to"></param>
  public Binder<TDataSource> BindEnabled<TProperty>(Control control!!, Expression<Func<TDataSource, TProperty>> property!!)
  {
    var b = new Binding(nameof(control.Enabled), DataSource, property.PropertyName(), true, DataSourceUpdateMode);
    control.DataBindings.Add(b);
    return this;
  }

  /// <summary>
  /// Binds the <see cref="Control.Enabled"/> property
  /// </summary>
  /// <param name="controls"></param>
  /// <param name="to"></param>
  public Binder<TDataSource> BindEnabled<TProperty>(IEnumerable<Control> controls!!, Expression<Func<TDataSource, TProperty>> property!!)
  {
    controls.ForEach(c => BindEnabled<TProperty>(c, property));
    return this;
  }

  /// <summary>
  /// Binds the <see cref="Control.ForeColor"/> property
  /// </summary>
  /// <param name="control"></param>
  /// <param name="to"></param>
  /// <param name="converter"></param>
  public Binder<TDataSource> BindForecolor<TProperty>(Control control!!, Expression<Func<TDataSource, TProperty>> property!!, ConvertEventHandler converter!!)
  {
    var b = new Binding(nameof(control.ForeColor), DataSource, property.PropertyName(), true, DataSourceUpdateMode);
    b.Format += converter;
    control.DataBindings.Add(b);
    return this;
  }

  /// <summary>
  /// Binds the <see cref="DataGridView"/> to a sub-object of <typeparamref name="TDataSource"/>.
  /// </summary>
  public Binder<TDataSource> BindGrid(DataGridView control!!, Func<TDataSource, object> toList!!)
  {
    control.DataSource = null;
    control.DataSource = toList.Invoke(DataSource);
    return this;
  }

  /// <summary>
  /// Binds the <see cref="DataGridView"/> to <typeparamref name="TDataSource"/>.
  /// </summary>
  public Binder<TDataSource> BindGrid(DataGridView control)
  {
    control.DataSource = null;
    control.DataSource = DataSource;
    return this;
  }
  /// <summary>
  /// Binds the <see cref="TextBoxBase.Lines"/> property
  /// </summary>
  /// <param name="control"></param>
  /// <param name="to"></param>
  public Binder<TDataSource> BindLines<TProperty>(TextBox control!!, Expression<Func<TDataSource, TProperty>> property!!)
  {
    var b = new Binding(nameof(control.Lines), DataSource, property.PropertyName(), true, DataSourceUpdateMode);
    control.DataBindings.Add(b);
    return this;
  }

  /// <summary>
  /// Binds the list control to a sub-object on the data-source
  /// </summary>
  /// <param name="control">Control to be bound.</param>
  /// <param name="dataSource">Function returning the property of <typeparamref name="TDataSource"/> to which to bind.</param>
  /// <param name="displayMember">Property of the data-source to display in the list.</param>
  public Binder<TDataSource> BindList(ListControl control!!, Func<TDataSource, object> dataSource!!, string displayMember!!)
  {
    control.DataSource = null;
    control.DataSource = dataSource.Invoke(DataSource);
    control.DisplayMember = displayMember;
    return this;
  }

  /// <summary>
  /// Binds the list control to a sub-object on the data-source
  /// </summary>
  /// <param name="control">Control to be bound.</param>
  /// <param name="dataSource">Function returning the property of <typeparamref name="TDataSource"/> to which to bind.</param>
  public Binder<TDataSource> BindList(ListControl control!!, Func<TDataSource, object> dataSource!!)
  {
    control.DataSource = null;
    control.DataSource = dataSource.Invoke(DataSource);
    return this;
  }

  /// <summary>
  /// Binds the <see cref="Control.Enabled"/> property to the opposite of the value of <paramref name="to"/>.
  /// </summary>
  /// <param name="control"></param>
  /// <param name="to"></param>
  public Binder<TDataSource> BindNotEnabled<TProperty>(Control control!!, Expression<Func<TDataSource, TProperty>> property!!)
  {
    var b = new Binding(nameof(control.Enabled), DataSource, property.PropertyName(), true, DataSourceUpdateMode);
    b.Format += ConvertEventHandlers.ToggleBool;
    control.DataBindings.Add(b);
    return this;
  }
  /// <summary>
  /// Binds the <see cref="ComboBox.SelectedItem"/> property
  /// </summary>
  /// <param name="control"></param>
  /// <param name="to"></param>
  public Binder<TDataSource> BindSelectedItem<TProperty>(ComboBox control!!, Expression<Func<TDataSource, TProperty>> property!!)
  {
    BindSelectionInternal(control, SelectedOptions.SelectedItem, property);
    return this;
  }

  /// <summary>
  /// Binds the <see cref="ListBox.SelectedItem"/> property
  /// </summary>
  /// <param name="control"></param>
  /// <param name="to"></param>
  public Binder<TDataSource> BindSelectedItem<TProperty>(ListBox control!!, Expression<Func<TDataSource, TProperty>> property!!)
  {
    BindSelectionInternal(control, SelectedOptions.SelectedItem, property);
    return this;
  }

  /// <summary>
  /// Binds the <see cref="ListControl.SelectedValue"/> property. 
  /// Also works for both <see cref="ComboBox"/> and <see cref="ListBox"/>.
  /// </summary>
  /// <param name="control"></param>
  /// <param name="to"></param>
  public Binder<TDataSource> BindSelectedValue<TProperty>(ListControl control!!, Expression<Func<TDataSource, TProperty>> property!!)
  {
    BindSelectionInternal(control, SelectedOptions.SelectedValue, property);
    return this;
  }

  /// <summary>
  /// Binds the <see cref="Control.Text"/> property
  /// </summary>
  /// <param name="control"></param>
  /// <param name="to"></param>
  public Binder<TDataSource> BindText<TProperty>(Control control!!, Expression<Func<TDataSource, TProperty>> property!!)
  {


    var b = new Binding(nameof(control.Text), DataSource, property.PropertyName(), true, DataSourceUpdateMode);
    control.DataBindings.Add(b);
    return this;
  }

  /// <summary>
  /// Binds the <see cref="Control.Text"/> property
  /// </summary>
  /// <param name="control"></param>
  /// <param name="to"></param>
  /// <param name="formatter"></param>
  /// <param name="parser"></param>
  public Binder<TDataSource> BindText<TProperty>(Control control!!, Expression<Func<TDataSource, TProperty>> property!!, ConvertEventHandler? formatter, ConvertEventHandler? parser)
  {

    BindText<TProperty>(control, property,
      formatter is null ? null : new ConvertEventHandler[] { formatter },
      parser is null ? null : new ConvertEventHandler[] { parser });

    return this;
  }

  /// <summary>
  /// Binds the <see cref="Control.Text"/> property
  /// </summary>
  /// <param name="control"></param>
  /// <param name="to"></param>
  /// <param name="formatters"></param>
  /// <param name="parsers"></param>
  public Binder<TDataSource> BindText<TProperty>(Control control!!, Expression<Func<TDataSource, TProperty>> property!!, ConvertEventHandler[]? formatters, ConvertEventHandler[]? parsers)
  {
    if (formatters is null && parsers is null) throw new InvalidOperationException("formatters is null && parsers is null");

    var b = new Binding(nameof(Control.Text), DataSource, property.PropertyName(), true, DataSourceUpdateMode);
    if (formatters != null) foreach (var f in formatters) b.Format += f;
    if (parsers != null) foreach (var p in parsers) b.Parse += p;
    control.DataBindings.Add(b);
    return this;
  }

  /// <summary>
  /// Binds the <see cref="DateTimePicker.Value"/> property
  /// </summary>
  /// <param name="control"></param>
  /// <param name="to"></param>
  public Binder<TDataSource> BindValue<TProperty>(DateTimePicker control!!, Expression<Func<TDataSource, TProperty>> property!!)
  {
    var b = new Binding(nameof(control.Value), DataSource, property.PropertyName(), true, DataSourceUpdateMode);
    control.DataBindings.Add(b);
    return this;
  }

  /// <summary>
  /// Binds the <see cref="NumericUpDown.Value"/> property
  /// </summary>
  /// <param name="control"></param>
  /// <param name="to"></param>
  public Binder<TDataSource> BindValue<TProperty>(NumericUpDown control!!, Expression<Func<TDataSource, TProperty>> property!!)
  {
    var b = new Binding(nameof(control.Value), DataSource, property.PropertyName(), true, DataSourceUpdateMode);
    control.DataBindings.Add(b);
    return this;
  }

  /// <summary>
  /// Binds the <see cref="CheckBox.Checked"/> property
  /// </summary>
  /// <param name="control"></param>
  /// <param name="to"></param>
  public Binder<TDataSource> BindValue<TProperty>(CheckBox control!!, Expression<Func<TDataSource, TProperty>> property!!)
  {
    var b = new Binding(nameof(control.Checked), DataSource, property.PropertyName(), true, DataSourceUpdateMode);
    control.DataBindings.Add(b);
    return this;
  }
  /// <summary>
  /// Handles binding ListBox and ComboBox SelectedItem and SelectedValue properties.
  /// </summary>
  private void BindSelectionInternal<TProperty>(Control control!!, SelectedOptions selectedOptions, Expression<Func<TDataSource, TProperty>> property!!)
  {
    var b = new Binding(selectedOptions.ToString(), DataSource, property.PropertyName(), true, DataSourceUpdateMode);
    control.DataBindings.Add(b);
  }

}

// The two methods below contain dependencies on interfaces from the original PW.WinForms.
// Will leave commented for now.

///// <summary>
///// To support binding of custom controls which implement <see cref="IValueControl"/>.
///// </summary>    
//public void BindValue<TProperty>(IValueControl control, string to)
//{
//  var b = new Binding(nameof(control.Value), DataSource, to, true, DataSourceUpdateMode);
//  ((Control)control).DataBindings.Add(b);
//}

///// <summary>
///// To support binding of custom controls which implement <see cref="ILongValueControl"/>.
///// </summary>    
//public void BindValue<TProperty>(ILongValueControl control, string to)
//{
//  var b = new Binding(nameof(control.Value), DataSource, to, true, DataSourceUpdateMode);
//  ((Control)control).DataBindings.Add(b);
//}