namespace Doctrin.Core.Entities
{
    public class ExceptionSetting
    {
        public string Id { get; set; }

        public string Value { get; set; }

        public string SettingId { get; set; }
        public int ExceptionDayId { get; set; }

        public virtual Setting Setting { get; set; }
        public virtual ExceptionDay ExceptionDay { get; set; }

    }
}
