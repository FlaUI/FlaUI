namespace FlaUI.WebDriver.Models
{
    public class ResponseWithValue<T>
    {
        public T Value { get; set; }

        public ResponseWithValue(T value)
        {
            Value = value;
        }
    }
}
