using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IAbility
    {
        [SerializableId("id")]
        int Id { get; }

        [SerializableId("ui_title")]
        string Title { get; }

        [SerializableId("description")]
        string Description { get; }

        [SerializableId("unity_id")]
        string UnityId { get; }

        [SerializableId("activation")]
        IActivationEvent Activation { get; }

        [SerializableId("impact_unit")]
        IImpact Impact { get; }

        [SerializableId("mana")]
        IFormula Mana { get; }

        [SerializableId("limit_battle")]
        int LimitBattle { get; }

        [SerializableId("limit_turn")]
        int LimitTurn { get; }

        [SerializableId("influence_type")]
        IReadOnlyDictionary<int, InfluenceType> Influence { get; }

        [SerializableId("params")]
        IAbilityParam Params { get; }

        [SerializableId("action_info")]
        IReadOnlyDictionary<int, IAbilityAction> Actions { get; }

        [SerializableId("hidden")]
        bool IsHidden { get; }

        [SerializableId("has_familiar")]
        bool HasFamiliar { get; }

        [SerializableId("lock_familiar")]
        bool LockFamiliar { get; }

        [SerializableId("actable")]
        ICondition Actable { get; }

        [SerializableId("hide_bar")]
        bool HideBar { get; }
    }
}
