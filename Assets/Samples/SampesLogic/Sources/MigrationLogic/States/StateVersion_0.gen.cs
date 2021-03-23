using System;
using System.Collections.Generic;
using MetaLogic.Contracts;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Data;

namespace SampesLogic.MigrationLogic.States
{
    public class StateVersion_0 : IMigrationState
    {
        public int StateVersion => 0;
        public int Version => 10;

        [JsonName("testClientState")]
        public ITestClientState_0 TestClientState;

        [JsonName("testComplexState")]
        public ITestComplexState_0 TestComplexState;

        [JsonName("testServerState")]
        public ITestServerState_0 TestServerState;

        public class ITestArrayState_0
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
            public ITestSampleState_0[] ArrayElement8;

        }
        public class ITestClientState_0
        {

            [JsonName("testElements")]
            public ITestElementsState_0 TestElements;

            [JsonName("testDict")]
            public ITestDictState_0 TestDict;

            [JsonName("testList")]
            public ITestListState_0 TestList;

            [JsonName("testArray")]
            public ITestArrayState_0 TestArray;

        }
        public class ITestComplexState_0
        {

            [JsonName("testString")]
            public String TestString;

            [JsonName("testInt")]
            public Int32 TestInt;

            [JsonName("subSet")]
            public ITestSubState_0 SubSet;

            [JsonName("testData")]
            public SimpleTestData TestData;

        }
        public class ITestDictState_0
        {

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
            public Dictionary<String, ITestSampleState_0> DictElement8;

            [JsonName("dictElement9")]
            public Dictionary<String, String> DictElement9;

            [JsonName("dictElement10")]
            public Dictionary<String, ITestSampleState_0> DictElement10;

            [JsonName("dictElement11")]
            public Dictionary<String, Int32[]> DictElement11;

        }
        public class ITestElementsState_0
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
            public ITestSampleState_0 Element8;

        }
        public class ITestListState_0
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
            public ITestSampleState_0[] ListElement8;

        }
        public class ITestSampleState_0
        {

            [JsonName("testString")]
            public String TestString;

            [JsonName("testInt")]
            public Int32 TestInt;

        }
        public class ITestServerArrayState_0
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

        }
        public class ITestServerElementsState_0
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

        }
        public class ITestServerState_0
        {

            [JsonName("testServerElements")]
            public ITestServerElementsState_0 TestServerElements;

            [JsonName("testServerArray")]
            public ITestServerArrayState_0 TestServerArray;

        }
        public class ITestSubState_0
        {

            [JsonName("testFloat")]
            public Single TestFloat;

            [JsonName("testDouble")]
            public Int64 TestDouble;

            [JsonName("testData")]
            public SimpleTestData TestData;

            [JsonName("commands")]
            public String[] Commands;

        }
    }
}
