using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    [StaticData(IsRoot = true)]
    public interface ILogStatic
    {
        IReadOnlyDictionary<int, ILogEvent> Events { get; }
    }

    public interface ILogEvent
    {
        [SerializableId("facebook_id")]
        string FacebookId { get; }

        [SerializableId("firebase_id")]
        string FirebaseId { get; }

        [SerializableId("appmetrica_id")]
        string AppmetricaId { get; }

        [SerializableId("appsflyer_id")]
        string AppsFlyerId { get; }
    }
}
