using System;
using System.Collections.Generic;
using MetaLogic.Contracts;

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

        public float Now => DateTime.Now.ToFileTimeUtc();

        public void ClearBatches()
        {
            _commands.Clear();
        }
    }
}