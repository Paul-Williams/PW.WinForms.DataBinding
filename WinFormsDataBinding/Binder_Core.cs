namespace PW.WinForms.DataBinding;

// This is the 'core' part of the class, including constructors, private methods and basically anything
// which is not a method for binding a control.
// Binding methods have been moved to other partial classes as a single class file was becoming unwieldy !! 


public partial class Binder<TDataSource> where TDataSource : class
{
  /// <summary>
  /// Creates a new instance
  /// </summary>
  /// <param name="dataSource">Data source used when binding controls.</param>
  /// <param name="dataSourceUpdateMode">Specifies when a data source is updated when changes occur in the bound control.</param>
  public Binder(TDataSource dataSource!!, DataSourceUpdateMode dataSourceUpdateMode)
  {
    DataSource = dataSource;
    DataSourceUpdateMode = dataSourceUpdateMode;
  }

  /// <summary>
  /// Creates a new instance with <see cref="DataSourceUpdateMode.OnPropertyChanged"/>
  /// </summary>
  /// <param name="dataSource">Data source used when binding controls.</param>
  public Binder(TDataSource dataSource!!) : this(dataSource, DataSourceUpdateMode.OnPropertyChanged) { }

  /// <summary>
  /// Data source used by this binder instance.
  /// </summary>
  public TDataSource DataSource { get; }


  /// <summary>
  /// Enum for the supported 'Selected...' values supported by <see cref="BindSelectionInternal(Control, SelectedOptions, string)"/>
  /// NB: The enum value names must match property names
  /// </summary>
  private enum SelectedOptions
  {
    SelectedItem,
    SelectedValue
  }

  private DataSourceUpdateMode DataSourceUpdateMode { get; }

}
