using System;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IUnitImpactBubble : IImpact
    {
        //[SerializableId("unit_id")]
        //int UnitId { get; }

        //[SerializableId("emoji_id")]
        //int EmojiId { get; }

        [SerializableId("phrase")]
        string Phrase { get; }
    }
}
