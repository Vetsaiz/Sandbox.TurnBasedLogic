using MetaLogic.Core;
using SampesLogic.Data;
using SampesLogic.Logic.Accessors;

namespace SampesLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class TestChangeStateModule
    {
        public TestClientAccessor _accessor;

        [Command]
        public void ChangeClientStateTest0(string stringArg)
        {
            _accessor.State.TestElements.Element = stringArg;
            _accessor.State.TestArray.ArrayElement = new[] {stringArg};
            _accessor.State.TestList.ListElement.Add(stringArg);
            _accessor.State.TestDict.DictElement[$"key{stringArg}"] = stringArg;
        }

        [Command]
        public void ChangeClientStateTest1(int intArg)
        {
            _accessor.State.TestElements.Element1 = intArg;
            _accessor.State.TestArray.ArrayElement1 = new[] { intArg };
            _accessor.State.TestList.ListElement1.Add(intArg);
            _accessor.State.TestDict.DictElement1[$"key{intArg}"] = intArg;
        }

        [Command]
        public void ChangeClientStateTest2(long longArg)
        {
            _accessor.State.TestElements.Element2 = longArg;
            _accessor.State.TestArray.ArrayElement2 = new[] { longArg };
            _accessor.State.TestList.ListElement2.Add(longArg);
            _accessor.State.TestDict.DictElement2[$"key{longArg}"] = longArg;
        }


        [Command]
        public void ChangeClientStateTest3(float floatArg)
        {
            _accessor.State.TestElements.Element3 = floatArg;
            _accessor.State.TestArray.ArrayElement3 = new[] { floatArg };
            _accessor.State.TestList.ListElement3.Add(floatArg);
            _accessor.State.TestDict.DictElement3[$"key{floatArg}"] = floatArg;
        }


        [Command]
        public void ChangeClientStateTest4(double doubleArg)
        {
            _accessor.State.TestElements.Element4 = doubleArg;
            _accessor.State.TestArray.ArrayElement4 = new[] { doubleArg };
            _accessor.State.TestList.ListElement4.Add(doubleArg);
            _accessor.State.TestDict.DictElement4[$"key{doubleArg}"] = doubleArg;
        }


        [Command]
        public void ChangeClientStateTest5(bool boolArg)
        {
            _accessor.State.TestElements.Element5 = boolArg;
            _accessor.State.TestArray.ArrayElement5 = new[] { boolArg };
            _accessor.State.TestList.ListElement5.Add(boolArg);
            _accessor.State.TestDict.DictElement5[$"key{boolArg}"] = boolArg;
        }


        [Command]
        public void ChangeClientStateTest6(SimpleTestData dataArg)
        {
            _accessor.State.TestElements.Element6 = dataArg;
            _accessor.State.TestArray.ArrayElement6 = new[] { dataArg };
            _accessor.State.TestList.ListElement6.Add(dataArg);
            //_accessor.State.TestDict.DictElement6[$"key{arg}"] = arg;
        }

        [Command]
        public void ChangeClientStateTest7(TestEnum enumArg)
        {
            _accessor.State.TestElements.Element7 = enumArg;
            _accessor.State.TestArray.ArrayElement7 = new[] { enumArg };
            _accessor.State.TestList.ListElement7.Add(enumArg);
            //_accessor.State.TestDict.DictElement6[$"key{arg}"] = arg;
        }

        [Command]
        public void ChangeClientStateTest8(string stringArg, int intArg)
        {
            var data = _accessor.Factory.CreateTestElement(stringArg, intArg);
            _accessor.State.TestElements.Element8 = data;
            //_accessor.State.TestArray.ArrayElement8 = new[] { data };
            _accessor.State.TestList.ListElement8.Add(data);
            _accessor.State.TestDict.DictElement8[$"key{stringArg}"] = data;
        }
    }
}