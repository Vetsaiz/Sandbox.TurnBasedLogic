using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IExplorerActivation
    {
        [SerializableId("cost")]
        IActivationCost Cost { get; }
        [SerializableId("id")]
        int Id { get; }
        [SerializableId("settings")]
        IActivationSettings Settings { get; }
        [SerializableId("source")]
        IActivationSource Source { get; }
        [SerializableId("desc")]
        IActivationDescription Description { get; }
        [SerializableId("impact")]
        IImpact Impact { get; }
        [SerializableId("visibility")]
        ICondition Actable { get; }
    }

    public interface IActivationSettings
    {
        [SerializableId("triggers")]
        IReadOnlyDictionary<int, ActivationTriggerType> Triggers { get; }
        [SerializableId("auto")]
        bool Auto { get; }
        [SerializableId("unity_id")]
        string AnumUnityId { get; }

        [SerializableId("fx_id")]
        string FxUnityId { get; }
    }

    public interface IActivationSource
    {
        [SerializableId("perk_class_id")]
        int PerkClassId { get; }
        [SerializableId("perk_level")]
        int PerkLevel { get; }
        [SerializableId("icon_type")]
        int IconType { get; }
        [SerializableId("unit_id")]
        int UnitId { get; }
    }

    public interface IActivationDescription
    {
        [SerializableId("description")]
        string Description { get; }
        [SerializableId("item_id")]
        int ItemId { get; }
        [SerializableId("item_number")]
        IFormula ItemCount { get; }
        [SerializableId("unknown_item")]
        bool UnknownItem { get; }
    }

    public interface IActivationCost
    {
        [SerializableId("btn_title")]
        string BtnTitle { get; }
        
        [SerializableId("item_id")]
        int ItemId { get; }

        [SerializableId("item_number")]
        IFormula ItemCount { get; }

        [SerializableId("stamina")]
        IFormula Stamina { get; }

        [SerializableId("price")]
        IReadOnlyDictionary<int, IPrice> Prices { get; }
    }

}
