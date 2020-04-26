namespace Doctrin.Api.Resources
{
    public class SettingResource
    {
        public int Id { get; set; }
        public string GlobalId { get; set; }
        public string Value { get; set; }
        public bool Inheritable { get; set; }
    }
}
