using VetsEngine.MetaLogic.Core;
using SampesLogic.Data;
using SampesLogic.Logic.Accessors;

namespace SampesLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class TestChangeServerModule
    {
        public TestServerAccessor _accessor;


        [Command]
        public void ChangeServerStateTest0(string stringArg)
        {
            _accessor.State.TestServerElements.ServerElement = stringArg;
            _accessor.State.TestServerArray.ArrayServerElement = new[] {stringArg};
            //_accessor.State.TestServerList.ListServerElement.Add(stringArg);
            //_accessor.State.TestServerDict.DictServerElement[$"key{stringArg}"] = stringArg;
        }

        [Command]
        public void ChangeServerStateTest1(int intArg)
        {
            _accessor.State.TestServerElements.ServerElement1 = intArg;
            _accessor.State.TestServerArray.ArrayServerElement1 = new[] { intArg };
            //_accessor.State.TestServerList.ListServerElement1.Add(intArg);
            //_accessor.State.TestServerDict.DictServerElement1[$"key{intArg}"] = intArg;
        }

        [Command]
        public void ChangeServerStateTest2(long longArg)
        {
            _accessor.State.TestServerElements.ServerElement2 = longArg;
            _accessor.State.TestServerArray.ArrayServerElement2 = new[] { longArg };
            //_accessor.State.TestServerList.ListServerElement2.Add(longArg);
            //_accessor.State.TestServerDict.DictServerElement2[$"key{longArg}"] = longArg;
        }


        [Command]
        public void ChangeServerStateTest3(float floatArg)
        {
            _accessor.State.TestServerElements.ServerElement3 = floatArg;
            _accessor.State.TestServerArray.ArrayServerElement3 = new[] { floatArg };
            //_accessor.State.TestServerList.ListServerElement3.Add(floatArg);
            //_accessor.State.TestServerDict.DictServerElement3[$"key{floatArg}"] = floatArg;
        }


        [Command]
        public void ChangeServerStateTest4(double doubleArg)
        {
            _accessor.State.TestServerElements.ServerElement4 = doubleArg;
            _accessor.State.TestServerArray.ArrayServerElement4 = new[] { doubleArg };
            //_accessor.State.TestServerList.ListServerElement4.Add(doubleArg);
            //_accessor.State.TestServerDict.DictServerElement4[$"key{doubleArg}"] = doubleArg;
        }


        [Command]
        public void ChangeServerStateTest5(bool boolArg)
        {
            _accessor.State.TestServerElements.ServerElement5 = boolArg;
            _accessor.State.TestServerArray.ArrayServerElement5 = new[] { boolArg };
            //_accessor.State.TestServerList.ListServerElement5.Add(boolArg);
            //_accessor.State.TestServerDict.DictServerElement5[$"key{boolArg}"] = boolArg;
        }


        [Command]
        public void ChangeServerStateTest6(SimpleTestData dataArg)
        {
            _accessor.State.TestServerElements.ServerElement6 = dataArg;
            _accessor.State.TestServerArray.ArrayServerElement6 = new[] { dataArg };
            //_accessor.State.TestServerList.ListServerElement6.Add(dataArg);
            //_accessor.State.TestDict.DictElement6[$"key{arg}"] = arg;
        }

        [Command]
        public void ChangeServerStateTest7(TestEnum enumArg)
        {
            _accessor.State.TestServerElements.ServerElement7 = enumArg;
            _accessor.State.TestServerArray.ArrayServerElement7 = new[] { enumArg };
            //_accessor.State.TestServerList.ListServerElement7.Add(enumArg);
            //_accessor.State.TestDict.DictElement6[$"key{arg}"] = arg;
        }

        //[Command]
        //public void ChangeServerStateTest8(string arg1, int arg2)
        //{
            //var data = _accessor.Factory.CreateServerTestElement(arg1, arg2);
            //_accessor.State.TestServerElements.ServerElement8 = data;
            //_accessor.State.TestServerArray.ArrayServerElement8 = new[] { data };
            //_accessor.State.TestServerList.ListServerElement8.Add(data);
            //_accessor.State.TestServerDict.DictServerElement8[$"key{arg1}"] = data;
        //}
    }
}