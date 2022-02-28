namespace Shared.Events.Domain
{
    public class EventInnerText
    {
        public string Value { get; }

        public EventInnerText(string innerText)
        {
            Value = innerText;
        }
    }
}
