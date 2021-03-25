using System;
using System.Collections.Generic;
using VetsEngine.MetaLogic.Contracts;

namespace MetaTests.Client.Core
{
    public class TestCommandStorage : ICommandStorage
    {
        private ISerializator _serializator;

        public TestCommandStorage(ISerializator serializator)
        {
            _serializator = serializator;
        }

        private List<CommandData> _commands = new List<CommandData>();
        private long _now;

        public string GetBatches()
        {
            var data = _serializator.Serialize(_commands);
            _commands.Clear();
            return data;
        }

        public void SaveCommand(CommandData data, string[] description, bool isChanges)
        {
            _commands.Add(data);
        }

        public void ChangeServerState()
        {
            throw new System.NotImplementedException();
        }

        public void PreCommand()
        {
        }

        long ICommandStorage.Now
        {
            get { return _now; }
        }

        public float Now => DateTime.Now.ToFileTimeUtc();

        public void ClearBatches()
        {
            _commands.Clear();
        }

        public T GetStatic<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public IReadOnlyDictionary<string, T> GetTests<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public T GetState<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public T GetServerState<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public void SaveState<T1, T2>(T1 clientState, T2 serverState) where T1 : class where T2 : class
        {
            throw new NotImplementedException();
        }
    }
}