using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;

namespace MyApplication.Desktop.ViewModels
{
    /// <summary>
    /// DataTemplateSelector to choose templates for <see cref="TTCRowViewModel"/>, <see cref="TTbCRowViewModel"/>, <see cref="T3RbRowViewModel"/>.
    /// </summary>
    /// <seealso cref="System.Windows.Controls.DataTemplateSelector" />
    [ExcludeFromCodeCoverage]
    public class RowViewModelTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Gets or sets the data template for <see cref="TTCRowViewModel"/>.
        /// </summary>
        /// <value>
        /// The data template for <see cref="TTCRowViewModel"/>.
        /// </value>
        public DataTemplate TTCDataTemplate { get; set; }

        /// <summary>
        /// Gets or sets the data template for <see cref="TTbCRowViewModel"/>.
        /// </summary>
        /// <value>
        /// The data template for <see cref="TTbCRowViewModel"/>.
        /// </value>
        public DataTemplate TTbCDataTemplate { get; set; }

        /// <summary>
        /// Gets or sets the data template for <see cref="T3RbRowViewModel"/>.
        /// </summary>
        /// <value>
        /// The data template for <see cref="T3RbRowViewModel"/>.
        /// </value>
        public DataTemplate T3RbDataTemplate { get; set; }

        /// <summary>
        /// When overridden in a derived class, returns a <see cref="T:System.Windows.DataTemplate" /> based on custom logic.
        /// </summary>
        /// <param name="item">The data object for which to select the template.</param>
        /// <param name="container">The data-bound object.</param>
        /// <returns>
        /// Returns a <see cref="T:System.Windows.DataTemplate" /> or null. The default value is null.
        /// </returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is TTCRowViewModel)
            {
                return this.TTCDataTemplate;
            }

            if (item is TTbCRowViewModel)
            {
                return this.TTbCDataTemplate;
            }

            if (item is T3RbRowViewModel)
            {
                return this.T3RbDataTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}