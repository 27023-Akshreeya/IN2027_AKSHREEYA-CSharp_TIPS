namespace EventsAndDelegates
{
    public delegate void Notify(string message);

    public class Notifer
    {
        public event Notify OnAction;

        public void DisplayOnAction(string message) => OnAction?.Invoke(message);
    }
}
