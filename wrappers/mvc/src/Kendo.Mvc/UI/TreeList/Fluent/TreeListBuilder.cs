namespace Kendo.Mvc.UI.Fluent
{
    using System.Collections.Generic;
    using System.Collections;
    using System;

    /// <summary>
    /// Defines the fluent API for configuring the Kendo TreeList for ASP.NET MVC.
    /// </summary>
    public class TreeListBuilder<T>: WidgetBuilderBase<TreeList<T>, TreeListBuilder<T>> where T : class
    {
        private readonly TreeList<T> container;
        /// <summary>
        /// Initializes a new instance of the <see cref="TreeList"/> class.
        /// </summary>
        /// <param name="component">The component.</param>
        public TreeListBuilder(TreeList<T> component)
            : base(component)
        {
            container = component;
        }

        //>> Fields
        
        /// <summary>
        /// The configuration of the treelist columns. An array of JavaScript objects or strings. A JavaScript objects are interpreted as column configurations. Strings are interpreted as the
		/// field to which the column is bound. The treelist will create a column for every item of the array.
        /// </summary>
        /// <param name="configurator">The action that configures the columns.</param>
        public TreeListBuilder<T> Columns(Action<TreeListColumnFactory> configurator)
        {
            configurator(new TreeListColumnFactory(container.Columns));
            return this;
        }
        
        /// <summary>
        /// If set to false the widget will not bind to the data source during initialization. In this case data binding will occur when the change event of the
		/// data source is fired. By default the widget will bind to the data source specified in the configuration.
        /// </summary>
        /// <param name="value">The value that configures the autobind.</param>
        public TreeListBuilder<T> AutoBind(bool value)
        {
            container.AutoBind = value;

            return this;
        }
        
        /// <summary>
        /// If set to true the grid will display a scrollbar when the total row height (or width) exceeds the grid height (or width). By default scrolling is enabled.Can be set to a JavaScript object which represents the scrolling configuration.
        /// </summary>
        /// <param name="value">The value that configures the scrollable.</param>
        public TreeListBuilder<T> Scrollable(bool value)
        {
            container.Scrollable = value;

            return this;
        }
        
        /// <summary>
        /// If set to true the user would be able to select treelist rows. By default selection is disabled.Can also be set to the following string values:
        /// </summary>
        /// <param name="value">The value that configures the selectable.</param>
        public TreeListBuilder<T> Selectable(bool value)
        {
            container.Selectable = value;

            return this;
        }
        
        /// <summary>
        /// If set to true the user could sort the treelist by clicking the column header cells. By default sorting is disabled.Can be set to a JavaScript object which represents the sorting configuration.
        /// </summary>
        /// <param name="configurator">The action that configures the sortable.</param>
        public TreeListBuilder<T> Sortable(Action<TreeListSortableSettingsBuilder> configurator)
        {
            configurator(new TreeListSortableSettingsBuilder(container.Sortable));
            return this;
        }
        
        /// <summary>
        /// If a String value is assigned to the toolbar configuration option, it will be treated as a single string template for the whole treelist Toolbar,
		/// and the string value will be passed as an argument to a kendo.template() function.If a Function value is assigned (it may be a kendo.template() function call or a generic function reference), then the return value of the function will be used to render the treelist Toolbar contents.If an Array value is assigned, it will be treated as the list of commands displayed in the treelist Toolbar. Commands can be custom or built-in ("cancel", "create", "save", "excel").The "create" command adds an empty data item to the treelist.The "excel" command exports the treelist data in MS Excel format.
        /// </summary>
        /// <param name="configurator">The action that configures the toolbar.</param>
        public TreeListBuilder<T> Toolbar(Action<TreeListToolbaFactory> configurator)
        {
            configurator(new TreeListToolbaFactory(container.Toolbar));
            return this;
        }
        
        /// <summary>
        /// The height of the treelist. Numeric values are treated as pixels.
        /// </summary>
        /// <param name="value">The value that configures the height.</param>
        public TreeListBuilder<T> Height(double value)
        {
            container.Height = value;

            return this;
        }
        
        /// <summary>
        /// If set to true the user can filter the data source using the grid filter menu. Filtering is disabled by default.Can be set to a JavaScript object which represents the filter menu configuration.
        /// </summary>
        /// <param name="configurator">The action that configures the filterable.</param>
        public TreeListBuilder<T> Filterable(Action<TreeListFilterableSettingsBuilder> configurator)
        {
            configurator(new TreeListFilterableSettingsBuilder(container.Filterable));
            return this;
        }
        
        /// <summary>
        /// If set to true the user would be able to edit the data to which the treelist is bound to. By default editing is disabled.Can be set to a string ("inline" or "popup") to specify the editing mode. The default editing mode is "inline".Can be set to a JavaScript object which represents the editing configuration.
        /// </summary>
        /// <param name="configurator">The action that configures the editable.</param>
        public TreeListBuilder<T> Editable(Action<TreeListEditableSettingsBuilder> configurator)
        {
            configurator(new TreeListEditableSettingsBuilder(container.Editable));
            return this;
        }
        
        //<< Fields

        /// <summary>
        /// Configure the DataSource of the component
        /// </summary>
        /// <param name="configurator">The action that configures the <see cref="DataSource"/>.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeMap()
        ///     .Name("treeMap")
        ///     .DataSource(dataSource => dataSource
        ///         .Read(read => read
        ///             .Action("_PopulationUS", "TreeMap")
        ///         )
        ///     )
        ///  %&gt;
        /// </code>
        /// </example>
        public TreeListBuilder<T> DataSource(Action<TreeListAjaxDataSourceBuilder<T>> configurator)
        {
            configurator(new TreeListAjaxDataSourceBuilder<T>(Component.DataSource, this.Component.ViewContext, this.Component.urlGenerator));

            return this;
        }
        
        /// <summary>
        /// Configures the client-side events.
        /// </summary>
        /// <param name="configurator">The client events action.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.Kendo().TreeList()
        ///             .Name("TreeList")
        ///             .Events(events => events
        ///                 .DataBinding("onDataBinding")
        ///             )
        /// %&gt;
        /// </code>
        /// </example>
        public TreeListBuilder<T> Events(Action<TreeListEventBuilder> configurator)
        {

            configurator(new TreeListEventBuilder(Component.Events));

            return this;
        }
        
    }
}

