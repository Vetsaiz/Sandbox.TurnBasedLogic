using Pathfinding.Serialization.JsonFx;
using SampesLogic.Logic.Accessors;
using SampesLogic.Logic.StateData;
using SampesLogic.Logic.StateData.ClientElements;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Server.State
{
    internal class Internal_ITestClientState : ITestClientState 
    {
        private ChangeStorage _storage;
        private string DataId = "testClientState";
        private TestClientAccessor _accessor;
        public void InitData(string root, ChangeStorage storage, TestClientAccessor accessor)
        {
            _accessor = accessor;
            _storage = storage;
            DataId = $"{root}.{DataId}";
            _TestElements?.InitData(DataId, storage);
            _TestDict?.InitData(DataId, storage);
            _TestList?.InitData(DataId, storage);
            _TestArray?.InitData(DataId, storage);
        }
        public void PreSave()
        {
            _TestElements?.PreSave();
            _TestDict?.PreSave();
            _TestList?.PreSave();
            _TestArray?.PreSave();
        }

        #region Internal

        [JsonName("testElements")]
        public Internal_ITestElementsState _TestElements;
        [JsonName("testDict")]
        public Internal_ITestDictState _TestDict;
        [JsonName("testList")]
        public Internal_ITestListState _TestList;
        [JsonName("testArray")]
        public Internal_ITestArrayState _TestArray;

        #endregion

        #region Source

        ITestElementsState ITestClientState.TestElements
        {
            get => _TestElements;
            set
            {
                var castValue = (Internal_ITestElementsState) value;
                if (_storage != null)
                {
                    castValue?.InitData(DataId, _storage);
                }
                _TestElements = castValue;
                _storage?.AddChange(this, DataId + $".testElements.{castValue?.ToString()}", null);
            }
        }
        ITestDictState ITestClientState.TestDict
        {
            get => _TestDict;
            set
            {
                var castValue = (Internal_ITestDictState) value;
                if (_storage != null)
                {
                    castValue?.InitData(DataId, _storage);
                }
                _TestDict = castValue;
                _storage?.AddChange(this, DataId + $".testDict.{castValue?.ToString()}", null);
            }
        }
        ITestListState ITestClientState.TestList
        {
            get => _TestList;
            set
            {
                var castValue = (Internal_ITestListState) value;
                if (_storage != null)
                {
                    castValue?.InitData(DataId, _storage);
                }
                _TestList = castValue;
                _storage?.AddChange(this, DataId + $".testList.{castValue?.ToString()}", null);
            }
        }
        ITestArrayState ITestClientState.TestArray
        {
            get => _TestArray;
            set
            {
                var castValue = (Internal_ITestArrayState) value;
                if (_storage != null)
                {
                    castValue?.InitData(DataId, _storage);
                }
                _TestArray = castValue;
                _storage?.AddChange(this, DataId + $".testArray.{castValue?.ToString()}", null);
            }
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _TestElements?.ToString();
            result += _TestDict?.ToString();
            result += _TestList?.ToString();
            result += _TestArray?.ToString();
            return result;
        }

        #endregion

    }
}
