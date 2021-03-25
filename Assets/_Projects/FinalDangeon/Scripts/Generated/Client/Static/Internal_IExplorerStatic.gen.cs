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
    internal class Internal_IExplorerStatic : IExplorerStatic 
    {
        public void PostSerialize()
        {
            ROD_Objects = _Objects != null ? _Objects.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IInteractiveObject;
            }
            ) : null;
            ROD_Stages = _Stages != null ? _Stages.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IStage;
            }
            ) : null;
            ROD_Rooms = _Rooms != null ? _Rooms.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IRoom;
            }
            ) : null;
            ROD_Zones = _Zones != null ? _Zones.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IZone;
            }
            ) : null;
            ROD_Mobs = _Mobs != null ? _Mobs.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IMob;
            }
            ) : null;
            ROD_Worlds = _Worlds != null ? _Worlds.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IWorld;
            }
            ) : null;
        }

        #region Interface

        public  IReadOnlyDictionary<Int32, IInteractiveObject> Objects => ROD_Objects;

        public  IReadOnlyDictionary<Int32, IStage> Stages => ROD_Stages;

        public  IReadOnlyDictionary<Int32, IRoom> Rooms => ROD_Rooms;

        public  IReadOnlyDictionary<Int32, IZone> Zones => ROD_Zones;

        public  IReadOnlyDictionary<Int32, IMob> Mobs => ROD_Mobs;

        public  IReadOnlyDictionary<Int32, IWorld> Worlds => ROD_Worlds;


        #endregion

        #region Internal

        [JsonName("interactive_objects")]
        public Dictionary<String, Internal_IInteractiveObject> _Objects;
        private Dictionary<Int32, IInteractiveObject> ROD_Objects;
        [JsonName("stages")]
        public Dictionary<String, Internal_IStage> _Stages;
        private Dictionary<Int32, IStage> ROD_Stages;
        [JsonName("rooms")]
        public Dictionary<String, Internal_IRoom> _Rooms;
        private Dictionary<Int32, IRoom> ROD_Rooms;
        [JsonName("zones")]
        public Dictionary<String, Internal_IZone> _Zones;
        private Dictionary<Int32, IZone> ROD_Zones;
        [JsonName("mobs")]
        public Dictionary<String, Internal_IMob> _Mobs;
        private Dictionary<Int32, IMob> ROD_Mobs;
        [JsonName("worlds")]
        public Dictionary<String, Internal_IWorld> _Worlds;
        private Dictionary<Int32, IWorld> ROD_Worlds;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
