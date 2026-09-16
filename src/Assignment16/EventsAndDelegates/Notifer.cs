namespace EventsAndDelegates
{
    /// <summary>
    /// di
    /// </summary>
    /// <param name="message">message</param>
    public delegate void Notify(string message);

    /// <summary>
    /// rdfdf
    /// </summary>
    public class Notifer
    {
        /// <summary>
        /// d
        /// </summary>
        public event Notify OnAction;

        /// <summary>
        /// d
        /// </summary>
        /// <param name="message">s</param>
        public void DisplayOnAction(string message) => OnAction?.Invoke(message);
    }
}
