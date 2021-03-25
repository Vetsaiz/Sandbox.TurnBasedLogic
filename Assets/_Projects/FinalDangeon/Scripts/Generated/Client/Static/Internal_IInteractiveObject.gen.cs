using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
using System.Collections.Generic;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IInteractiveObject : IInteractiveObject 
    {
        public void PostSerialize()
        {
            ROD_Activations = _Activations != null ? _Activations.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IExplorerActivation;
            }
            ) : null;
        }

        #region Interface

        public Int32 Id => _Id;

        public String Title => _Title;

        public Int32 RoomId => _RoomId;

        public String UnityId => _UnityId;

        public AvailibilityType Availibility => _Availibility;

        public Boolean Backlight => _Backlight;

        public IconType IconType => _IconType;

        public Boolean MinimapVisability => _MinimapVisability;

        public Boolean BattleVisibility => _BattleVisibility;

        public Boolean Impassable => _Impassable;

        public  IReadOnlyDictionary<Int32, IExplorerActivation> Activations => ROD_Activations;

        public String Description => _Description;

        public JumpDirectionType JumpDirection => _JumpDirection;

        public Boolean Danger => _Danger;

        public Boolean Revert => _Revert;

        public Boolean AutoRotate => _AutoRotate;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("ui_title")]
        public String _Title;
        [JsonName("room_id")]
        public Int32 _RoomId;
        [JsonName("unity_id")]
        public String _UnityId;
        [JsonName("availibility")]
        public AvailibilityType _Availibility;
        [JsonName("backlight")]
        public Boolean _Backlight;
        [JsonName("icon_type")]
        public IconType _IconType;
        [JsonName("minimap_visibility")]
        public Boolean _MinimapVisability;
        [JsonName("battle_view")]
        public Boolean _BattleVisibility;
        [JsonName("impassable")]
        public Boolean _Impassable;
        [JsonName("activations")]
        public Dictionary<String, Internal_IExplorerActivation> _Activations;
        private Dictionary<Int32, IExplorerActivation> ROD_Activations;
        [JsonName("description")]
        public String _Description;
        [JsonName("jump_direction")]
        public JumpDirectionType _JumpDirection;
        [JsonName("danger")]
        public Boolean _Danger;
        [JsonName("revert")]
        public Boolean _Revert;
        [JsonName("autorotate")]
        public Boolean _AutoRotate;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
