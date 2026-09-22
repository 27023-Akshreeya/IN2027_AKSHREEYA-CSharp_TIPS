using System;

namespace EventsAndDelegates
{
    /// <summary>
    /// Handles system notifications and action events.
    /// </summary>
    public class Notifier
    {
        /// <summary>
        /// Defines the signature for the notification callback.
        /// </summary>
        /// <param name="message">The notification message string.</param>
        public delegate void Notify(string message);

        /// <summary>
        /// Occurs when an action is performed.
        /// </summary>
        public event Notify OnAction;

        /// <summary>
        /// Triggers the OnAction event safely.
        /// </summary>
        /// <param name="message">The message payload to broadcast.</param>
        public void TriggerAction(string message)
        {
            this.OnAction?.Invoke(message);
        }
    }
}
