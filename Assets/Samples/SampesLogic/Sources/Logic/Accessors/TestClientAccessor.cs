using System.Collections.Generic;
using MetaLogic.Core;
using SampesLogic.Data;
using SampesLogic.Logic.StateData;
using SampesLogic.Logic.StateData.ClientElements;
using SampesLogic.Logic.StaticData;

namespace SampesLogic.Logic.Accessors
{
    [LogicElement(ElementType.Accessor)]
    internal partial class TestClientAccessor
    {
        public ITestClientState State { get; set; }
        public ITestStructuresStatic Static { get; set; }
        public ITestFactory Factory { get; set; }

        public void CreateElements()
        {
            State.TestElements = Factory.CreateTestElements();
            State.TestArray = Factory.CreateTestArray();
            State.TestList = Factory.CreateTestList();
            State.TestDict = Factory.CreateTestDict();
        }

        #region Properties


        [Query]
        public ITestElementsState TestElements => State.TestElements;

        [Query]
        public string Element => Static.Elements.Element;

        [Query]
        public int Element1 => Static.Elements.Element1;

        [Query]
        public long Element2 => Static.Elements.Element2;

        [Query]
        public float Element3 => Static.Elements.Element3;

        [Query]
        public double Element4 => Static.Elements.Element4;

        [Query]
        public bool Element5 => Static.Elements.Element5;

        [Query]
        public SimpleTestData Element6 => Static.Elements.Element6;

        [Query]
        public ComplexTestData Element7 => Static.Elements.Element7;

        [Query]
        public ITestElementStatic Element8 => Static.Elements.Element8;

        [Query]
        public IReadOnlyDictionary<string, string> DictElements => Static.DictElements.DictElements;

        [Query]
        public IReadOnlyDictionary<string, int> DictElements1 => Static.DictElements.DictElements1;

        [Query]
        public IReadOnlyDictionary<int, string> DictElements2 => Static.DictElements.DictElements2;

        [Query]
        public IReadOnlyDictionary<int, ITestElementStatic> DictElements3 => Static.DictElements.DictElements3;

        [Query]
        public IReadOnlyDictionary<int, SimpleTestData> DictElements4 => Static.DictElements.DictElements4;

        [Query]
        public string[] ArrayElements => Static.ArrayElements.ArrayElements;

        [Query]
        public int[] ArrayElements1 => Static.ArrayElements.ArrayElements1;

        [Query]
        public SimpleTestData[] ArrayElements2 => Static.ArrayElements.ArrayElements2;

        [Query]
        public ITestElementStatic[] ArrayElements3 => Static.ArrayElements.ArrayElements3;

        #endregion

        #region Methods

        [Query]
        public string GetElement()
        {
            return Static.Elements.Element;
        }

        [Query]
        public int GetElement1()
        {
            return Static.Elements.Element1;
        }

        [Query]
        public long GetElement2()
        {
            return Static.Elements.Element2;
        }

        [Query]
        public float GetElement3()
        {
            return Static.Elements.Element3;
        }

        [Query]
        public double GetElement4()
        {
            return Static.Elements.Element4;
        }

        [Query]
        public bool GetElement5()
        {
            return Static.Elements.Element5;
        }

        [Query]
        public SimpleTestData GetElement6()
        {
            return Static.Elements.Element6;
        }

        [Query]
        public ComplexTestData GetElement7()
        {
            return Static.Elements.Element7;
        }

        [Query]
        public ITestElementStatic GetElement8()
        {
            return Static.Elements.Element8;
        }

        [Query]
        public IReadOnlyDictionary<string, string> GetDictElements()
        {
            return Static.DictElements.DictElements;
        }

        [Query]
        public IReadOnlyDictionary<string, int> GetDictElements1()
        {
            return Static.DictElements.DictElements1;
        }

        [Query]
        public IReadOnlyDictionary<int, string> GetDictElements2()
        {
            return Static.DictElements.DictElements2;
        }

        [Query]
        public IReadOnlyDictionary<int, ITestElementStatic> GetDictElements3()
        {
            return Static.DictElements.DictElements3;
        }

        [Query]
        public IReadOnlyDictionary<int, SimpleTestData> GetDictElements4()
        {
            return Static.DictElements.DictElements4;
        }

        [Query]
        public string[] GetArrayElements()
        {
            return Static.ArrayElements.ArrayElements;
        }

        [Query]
        public int[] GetArrayElements1()
        {
            return Static.ArrayElements.ArrayElements1;
        }

        [Query]
        public SimpleTestData[] GetArrayElements2()
        {
            return Static.ArrayElements.ArrayElements2;
        }

        [Query]
        public ITestElementStatic[] GetArrayElements3()
        {
            return Static.ArrayElements.ArrayElements3;
        }

        #endregion
    }
}
