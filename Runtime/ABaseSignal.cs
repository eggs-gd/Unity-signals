namespace eggsgd.Signals
{
    /// <summary>
    ///     Abstract class for Signals, provides hash by type functionality
    /// </summary>
    public abstract class ABaseSignal : ISignal
    {
        protected string hash;

        /// <summary>
        ///     Unique id for this signal
        /// </summary>
        public string Hash
        {
            get
            {
                if (string.IsNullOrEmpty(hash))
                {
                    hash = GetType().ToString();
                }

                return hash;
            }
        }
    }
}