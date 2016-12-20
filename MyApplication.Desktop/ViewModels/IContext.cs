using System;

namespace MyApplication.Desktop.ViewModels
{
    /// <summary>
    /// Context for running operations which should be run in UI thread.
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Gets a value indicating whether this instance is synchronized.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is synchronized; otherwise, <c>false</c>.
        /// </value>
        bool IsSynchronized { get; }

        /// <summary>
        /// Invokes the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        void Invoke(Action action);

        /// <summary>
        /// Begins the invoke.
        /// </summary>
        /// <param name="action">The action.</param>
        void BeginInvoke(Action action);
    }
}
