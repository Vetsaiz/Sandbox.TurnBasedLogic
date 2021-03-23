using System;
using System.Collections.Generic;
using System.Linq;
using MetaLogic.Contracts;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Data;

namespace SampesLogic.MigrationLogic.States
{
    public class StateVersion_1 : IMigrationState<StateVersion_0>
    {
        public int StateVersion => 1;
        public int Version => 11;

        [JsonName("testClientState")]
        public ITestClientState_1 TestClientState;

        [JsonName("testComplexState")]
        public ITestComplexState_1 TestComplexState;

        [JsonName("testServerState")]
        public ITestServerState_1 TestServerState;

        public IMigrationState<StateVersion_0> CopyTo(StateVersion_0 oldData)
        {
            var newData = new StateVersion_1();
            newData.TestClientState = ITestClientState_1.CopyTo(oldData.TestClientState);
            newData.TestComplexState = ITestComplexState_1.CopyTo(oldData.TestComplexState);
            newData.TestServerState = ITestServerState_1.CopyTo(oldData.TestServerState);
            return newData;
        }
        public class ITestArrayState_1
        {

            [JsonName("arrayElement")]
            public String[] ArrayElement;

            [JsonName("arrayElement1")]
            public Int32[] ArrayElement1;

            [JsonName("arrayElement2")]
            public Int64[] ArrayElement2;

            [JsonName("arrayElement3")]
            public Single[] ArrayElement3;

            [JsonName("arrayElement4")]
            public Double[] ArrayElement4;

            [JsonName("arrayElement5")]
            public Boolean[] ArrayElement5;

            [JsonName("arrayElement6")]
            public SimpleTestData[] ArrayElement6;

            [JsonName("arrayElement7")]
            public TestEnum[] ArrayElement7;

            [JsonName("arrayElement8")]
            public ITestSampleState_1[] ArrayElement8;

            public static ITestArrayState_1 CopyTo(StateVersion_0.ITestArrayState_0 oldData)
            {
                var newData = new ITestArrayState_1();
                newData.ArrayElement = oldData.ArrayElement;
                newData.ArrayElement1 = oldData.ArrayElement1;
                newData.ArrayElement2 = oldData.ArrayElement2;
                newData.ArrayElement3 = oldData.ArrayElement3;
                newData.ArrayElement4 = oldData.ArrayElement4;
                newData.ArrayElement5 = oldData.ArrayElement5;
                newData.ArrayElement6 = oldData.ArrayElement6;
                newData.ArrayElement7 = oldData.ArrayElement7;
                newData.ArrayElement8 = oldData.ArrayElement8.Select(ITestSampleState_1.CopyTo).ToArray();
                return newData;
            }
        }
        public class ITestClientState_1
        {

            [JsonName("testElements")]
            public ITestElementsState_1 TestElements;

            [JsonName("testDict")]
            public ITestDictState_1 TestDict;

            [JsonName("testList")]
            public ITestListState_1 TestList;

            [JsonName("testArray")]
            public ITestArrayState_1 TestArray;

            public static ITestClientState_1 CopyTo(StateVersion_0.ITestClientState_0 oldData)
            {
                var newData = new ITestClientState_1();
                newData.TestElements = ITestElementsState_1.CopyTo(oldData.TestElements);
                newData.TestDict = ITestDictState_1.CopyTo(oldData.TestDict);
                newData.TestList = ITestListState_1.CopyTo(oldData.TestList);
                newData.TestArray = ITestArrayState_1.CopyTo(oldData.TestArray);
                return newData;
            }
        }
        public class ITestComplexState_1
        {

            [JsonName("testString")]
            public String TestString;

            [JsonName("testInt")]
            public Int32 TestInt;

            [JsonName("subSet")]
            public ITestSubState_1 SubSet;

            [JsonName("testData")]
            public SimpleTestData TestData;

            public static ITestComplexState_1 CopyTo(StateVersion_0.ITestComplexState_0 oldData)
            {
                var newData = new ITestComplexState_1();
                newData.TestString = oldData.TestString;
                newData.TestInt = oldData.TestInt;
                newData.SubSet = ITestSubState_1.CopyTo(oldData.SubSet);
                newData.TestData = oldData.TestData;
                return newData;
            }
        }
        public class ITestDictState_1
        {

            // ----------------- Added fields -----------------------------

            [JsonName("dictElement12")]
            public Dictionary<String, Int32> DictElement12;

            [JsonName("dictElement14")]
            public Dictionary<String, Int32[]> DictElement14;

            [JsonName("dictElement13")]
            public Dictionary<String, ITestSampleState_1[]> DictElement13;


            // ------------------------------------------------------------

            [JsonName("dictElement")]
            public Dictionary<String, String> DictElement;

            [JsonName("dictElement1")]
            public Dictionary<String, Int32> DictElement1;

            [JsonName("dictElement2")]
            public Dictionary<String, Int64> DictElement2;

            [JsonName("dictElement3")]
            public Dictionary<String, Single> DictElement3;

            [JsonName("dictElement4")]
            public Dictionary<String, Double> DictElement4;

            [JsonName("dictElement5")]
            public Dictionary<String, Boolean> DictElement5;

            [JsonName("dictElement8")]
            public Dictionary<String, ITestSampleState_1> DictElement8;

            [JsonName("dictElement9")]
            public Dictionary<String, String> DictElement9;

            [JsonName("dictElement10")]
            public Dictionary<String, ITestSampleState_1> DictElement10;

            [JsonName("dictElement11")]
            public Dictionary<String, Int32[]> DictElement11;

            public static ITestDictState_1 CopyTo(StateVersion_0.ITestDictState_0 oldData)
            {
                var newData = new ITestDictState_1();
                newData.DictElement = oldData.DictElement;
                newData.DictElement1 = oldData.DictElement1;
                newData.DictElement2 = oldData.DictElement2;
                newData.DictElement3 = oldData.DictElement3;
                newData.DictElement4 = oldData.DictElement4;
                newData.DictElement5 = oldData.DictElement5;
                newData.DictElement8 = oldData.DictElement8.ToDictionary(x => x.Key, x => ITestSampleState_1.CopyTo(x.Value));
                newData.DictElement9 = oldData.DictElement9;
                newData.DictElement10 = oldData.DictElement10.ToDictionary(x => x.Key, x => ITestSampleState_1.CopyTo(x.Value));
                newData.DictElement11 = oldData.DictElement11;
                return newData;
            }
        }
        public class ITestElementsState_1
        {

            [JsonName("element")]
            public String Element;

            [JsonName("element1")]
            public Int32 Element1;

            [JsonName("element2")]
            public Int64 Element2;

            [JsonName("element3")]
            public Single Element3;

            [JsonName("element4")]
            public Double Element4;

            [JsonName("element5")]
            public Boolean Element5;

            [JsonName("element6")]
            public SimpleTestData Element6;

            [JsonName("element7")]
            public TestEnum Element7;

            [JsonName("element8")]
            public ITestSampleState_1 Element8;

            public static ITestElementsState_1 CopyTo(StateVersion_0.ITestElementsState_0 oldData)
            {
                var newData = new ITestElementsState_1();
                newData.Element = oldData.Element;
                newData.Element1 = oldData.Element1;
                newData.Element2 = oldData.Element2;
                newData.Element3 = oldData.Element3;
                newData.Element4 = oldData.Element4;
                newData.Element5 = oldData.Element5;
                newData.Element6 = oldData.Element6;
                newData.Element7 = oldData.Element7;
                newData.Element8 = ITestSampleState_1.CopyTo(oldData.Element8);
                return newData;
            }
        }
        public class ITestListState_1
        {

            [JsonName("listElement")]
            public String[] ListElement;

            [JsonName("listElement1")]
            public Int32[] ListElement1;

            [JsonName("listElement2")]
            public Int64[] ListElement2;

            [JsonName("listElement3")]
            public Single[] ListElement3;

            [JsonName("listElement4")]
            public Double[] ListElement4;

            [JsonName("listElement5")]
            public Boolean[] ListElement5;

            [JsonName("listElement6")]
            public SimpleTestData[] ListElement6;

            [JsonName("listElement7")]
            public TestEnum[] ListElement7;

            [JsonName("listElement8")]
            public ITestSampleState_1[] ListElement8;

            public static ITestListState_1 CopyTo(StateVersion_0.ITestListState_0 oldData)
            {
                var newData = new ITestListState_1();
                newData.ListElement = oldData.ListElement;
                newData.ListElement1 = oldData.ListElement1;
                newData.ListElement2 = oldData.ListElement2;
                newData.ListElement3 = oldData.ListElement3;
                newData.ListElement4 = oldData.ListElement4;
                newData.ListElement5 = oldData.ListElement5;
                newData.ListElement6 = oldData.ListElement6;
                newData.ListElement7 = oldData.ListElement7;
                newData.ListElement8 = oldData.ListElement8.Select(ITestSampleState_1.CopyTo).ToArray();
                return newData;
            }
        }
        public class ITestSampleState_1
        {

            [JsonName("testString")]
            public String TestString;

            [JsonName("testInt")]
            public Int32 TestInt;

            public static ITestSampleState_1 CopyTo(StateVersion_0.ITestSampleState_0 oldData)
            {
                var newData = new ITestSampleState_1();
                newData.TestString = oldData.TestString;
                newData.TestInt = oldData.TestInt;
                return newData;
            }
        }
        public class ITestServerArrayState_1
        {

            [JsonName("arrayServerElement")]
            public String[] ArrayServerElement;

            [JsonName("arrayServerElement1")]
            public Int32[] ArrayServerElement1;

            [JsonName("arrayServerElement2")]
            public Int64[] ArrayServerElement2;

            [JsonName("arrayServerElement3")]
            public Single[] ArrayServerElement3;

            [JsonName("arrayServerElement4")]
            public Double[] ArrayServerElement4;

            [JsonName("arrayServerElement5")]
            public Boolean[] ArrayServerElement5;

            [JsonName("arrayServerElement6")]
            public SimpleTestData[] ArrayServerElement6;

            [JsonName("arrayServerElement7")]
            public TestEnum[] ArrayServerElement7;

            public static ITestServerArrayState_1 CopyTo(StateVersion_0.ITestServerArrayState_0 oldData)
            {
                var newData = new ITestServerArrayState_1();
                newData.ArrayServerElement = oldData.ArrayServerElement;
                newData.ArrayServerElement1 = oldData.ArrayServerElement1;
                newData.ArrayServerElement2 = oldData.ArrayServerElement2;
                newData.ArrayServerElement3 = oldData.ArrayServerElement3;
                newData.ArrayServerElement4 = oldData.ArrayServerElement4;
                newData.ArrayServerElement5 = oldData.ArrayServerElement5;
                newData.ArrayServerElement6 = oldData.ArrayServerElement6;
                newData.ArrayServerElement7 = oldData.ArrayServerElement7;
                return newData;
            }
        }
        public class ITestServerElementsState_1
        {

            [JsonName("serverElement")]
            public String ServerElement;

            [JsonName("serverElement1")]
            public Int32 ServerElement1;

            [JsonName("serverElement2")]
            public Int64 ServerElement2;

            [JsonName("serverElement3")]
            public Single ServerElement3;

            [JsonName("serverElement4")]
            public Double ServerElement4;

            [JsonName("serverElement5")]
            public Boolean ServerElement5;

            [JsonName("serverElement6")]
            public SimpleTestData ServerElement6;

            [JsonName("serverElement7")]
            public TestEnum ServerElement7;

            public static ITestServerElementsState_1 CopyTo(StateVersion_0.ITestServerElementsState_0 oldData)
            {
                var newData = new ITestServerElementsState_1();
                newData.ServerElement = oldData.ServerElement;
                newData.ServerElement1 = oldData.ServerElement1;
                newData.ServerElement2 = oldData.ServerElement2;
                newData.ServerElement3 = oldData.ServerElement3;
                newData.ServerElement4 = oldData.ServerElement4;
                newData.ServerElement5 = oldData.ServerElement5;
                newData.ServerElement6 = oldData.ServerElement6;
                newData.ServerElement7 = oldData.ServerElement7;
                return newData;
            }
        }
        public class ITestServerState_1
        {

            [JsonName("testServerElements")]
            public ITestServerElementsState_1 TestServerElements;

            [JsonName("testServerArray")]
            public ITestServerArrayState_1 TestServerArray;

            public static ITestServerState_1 CopyTo(StateVersion_0.ITestServerState_0 oldData)
            {
                var newData = new ITestServerState_1();
                newData.TestServerElements = ITestServerElementsState_1.CopyTo(oldData.TestServerElements);
                newData.TestServerArray = ITestServerArrayState_1.CopyTo(oldData.TestServerArray);
                return newData;
            }
        }
        public class ITestSubState_1
        {

            [JsonName("testFloat")]
            public Single TestFloat;

            [JsonName("testDouble")]
            public Int64 TestDouble;

            [JsonName("testData")]
            public SimpleTestData TestData;

            [JsonName("commands")]
            public String[] Commands;

            public static ITestSubState_1 CopyTo(StateVersion_0.ITestSubState_0 oldData)
            {
                var newData = new ITestSubState_1();
                newData.TestFloat = oldData.TestFloat;
                newData.TestDouble = oldData.TestDouble;
                newData.TestData = oldData.TestData;
                newData.Commands = oldData.Commands;
                return newData;
            }
        }
    }
}
