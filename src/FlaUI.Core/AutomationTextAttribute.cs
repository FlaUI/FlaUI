namespace FlaUI.Core
{
    public class AutomationTextAttribute : AutomationIdentifier
    {
        public AutomationTextAttribute(int id, string name)
            : base(id, name)
        {
        }

        public static AutomationTextAttribute Register(int id, string name)
        {
            return RegisterTextAttribute(id, name);
        }

        public static AutomationTextAttribute Find(int id)
        {
            return FindTextAttribute(id);
        }
    }
}
