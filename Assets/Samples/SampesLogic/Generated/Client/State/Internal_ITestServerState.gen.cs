using Pathfinding.Serialization.JsonFx;
using SampesLogic.Logic.Accessors;
using SampesLogic.Logic.StateData;
using SampesLogic.Logic.StateData.ServerElements;
using UniRx;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client.State
{
    internal class Internal_ITestServerState : ITestServerStateClient, ITestServerState 
    {
        private ChangeStorage _storage;
        private string DataId = "testServerState";
        private TestServerAccessor _accessor;
        public void InitData(string root, ChangeStorage storage, TestServerAccessor accessor)
        {
            _accessor = accessor;
            _storage = storage;
            DataId = $"{root}.{DataId}";
            _TestServerElements?.InitData(DataId, storage);
            Interface_TestServerElements = new ReactiveProperty<ITestServerElementsStateClient>(_TestServerElements);
            _TestServerArray?.InitData(DataId, storage);
            Interface_TestServerArray = new ReactiveProperty<ITestServerArrayStateClient>(_TestServerArray);
        }
        public void PreSave()
        {
            _TestServerElements?.PreSave();
            _TestServerArray?.PreSave();
        }

        #region Queries


        #endregion

        #region Interface

        private ReactiveProperty<ITestServerElementsStateClient> Interface_TestServerElements;
        IReadOnlyReactiveProperty<ITestServerElementsStateClient> ITestServerStateClient.TestServerElements => Interface_TestServerElements;
        private ReactiveProperty<ITestServerArrayStateClient> Interface_TestServerArray;
        IReadOnlyReactiveProperty<ITestServerArrayStateClient> ITestServerStateClient.TestServerArray => Interface_TestServerArray;

        #endregion

        #region Internal

        [JsonName("testServerElements")]
        public Internal_ITestServerElementsState _TestServerElements;
        [JsonName("testServerArray")]
        public Internal_ITestServerArrayState _TestServerArray;

        #endregion

        #region Source

        ITestServerElementsState ITestServerState.TestServerElements
        {
            get => _TestServerElements;
            set
            {
                var castValue = (Internal_ITestServerElementsState) value;
                if (_storage != null)
                {
                    castValue?.InitData(DataId, _storage);
                }
                _TestServerElements = castValue;
                _storage?.AddChange(this, DataId + $".testServerElements.{castValue?.ToString()}", () => Interface_TestServerElements.Value = castValue);
            }
        }
        ITestServerArrayState ITestServerState.TestServerArray
        {
            get => _TestServerArray;
            set
            {
                var castValue = (Internal_ITestServerArrayState) value;
                if (_storage != null)
                {
                    castValue?.InitData(DataId, _storage);
                }
                _TestServerArray = castValue;
                _storage?.AddChange(this, DataId + $".testServerArray.{castValue?.ToString()}", () => Interface_TestServerArray.Value = castValue);
            }
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _TestServerElements?.ToString();
            result += _TestServerArray?.ToString();
            return result;
        }

        #endregion

    }
}
