using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IBuff
    {
        [SerializableId("id")]
        int Id { get; }

        [SerializableId("indelible")]
        bool Indelible { get; }

        [SerializableId("limit_charges")]
        int LimitCharges { get; }

        [SerializableId("impact_unit")]
        IImpact Impact { get; }

        [SerializableId("impact_takeoff")]
        IImpact ImpactTakeOff { get; }

        [SerializableId("mods")]
        IReadOnlyDictionary<int, IBuffModifier> Mods { get; }

        //[SerializableId("amplification")]
        //bool Amplification { get; }

        [SerializableId("withdraw_turn")]
        int WithdrawTurn { get; }

        [SerializableId("withdraw_death")]
        int WithdrawDeath { get; }

        [SerializableId("withdraw_finish")]
        int WithdrawFinish { get; }

        //Визуал

        [SerializableId("ui_title")]
        string Title { get; }

        [SerializableId("description")]
        string Description { get; }

        [SerializableId("unity_id")]
        string UnityId { get; }

        [SerializableId("unity_fx_status")]
        IReadOnlyDictionary<int, FxStatusType> FxStatuses { get; }

        [SerializableId("buff_type_id")]
        IReadOnlyDictionary<int, int> BuffType { get; }

        [SerializableId("cond_buff")]
        ICondition Condition { get; }

        [SerializableId("hidden")]
        bool Hidden { get; }
        
        [SerializableId("anim_loop")]
        bool AnimLoop { get; }

        [SerializableId("hidden_number")]
        bool HiddenNumber { get; }

        [SerializableId("influence_type")]
        InfluenceBuffType Influence { get; }

        [SerializableId("impact_init")]
        IImpact ImpactInit { get; }

        [SerializableId("impact_die")]
        IImpact ImpactDie { get; }
    }
}
