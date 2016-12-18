namespace MyApplication.Desktop.ViewModels
{
    /// <summary>
    /// View model for T3Rb Row.
    /// </summary>
    /// <seealso cref="MyApplication.Desktop.ViewModels.RowViewModelBase" />
    public class T3RbRowViewModel : RowViewModelBase
    {
        /// <summary>
        /// The state
        /// </summary>
        private T3RbRowState state;

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public T3RbRowState State
        {
            get { return this.state; }
            set
            {
                this.state = value;
                this.OnPropertyChanged(() => this.State);
            }
        }
    }
}