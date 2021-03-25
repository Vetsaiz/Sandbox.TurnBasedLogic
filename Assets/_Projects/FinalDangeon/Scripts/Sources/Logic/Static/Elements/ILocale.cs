using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface ILocale
    {
        [SerializableId("id")]
        int Id { get; }
        [SerializableId("locale")]
        string Locale { get; }
        [SerializableId("ui_title")]
        int Title { get; }
 }
}
