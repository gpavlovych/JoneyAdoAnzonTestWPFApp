using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Windows.Threading;

namespace MyApplication.Desktop.ViewModels
{
    /// <summary>
    /// Implementation of context.
    /// </summary>
    /// <seealso cref="MyApplication.Desktop.ViewModels.IContext" />
    [ExcludeFromCodeCoverage]
    public sealed class WpfContext : IContext
    {
        /// <summary>
        /// The dispatcher
        /// </summary>
        private readonly Dispatcher dispatcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="WpfContext"/> class.
        /// </summary>
        /// <param name="dispatcher">The dispatcher.</param>
        public WpfContext(Dispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is synchronized.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is synchronized; otherwise, <c>false</c>.
        /// </value>
        public bool IsSynchronized => this.dispatcher.Thread == Thread.CurrentThread;

        /// <summary>
        /// Invokes the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        public void Invoke(Action action)
        {
            this.dispatcher.Invoke(action);
        }

        /// <summary>
        /// Begins the invoke.
        /// </summary>
        /// <param name="action">The action.</param>
        public void BeginInvoke(Action action)
        {
            this.dispatcher.BeginInvoke(action);
        }
    }
}