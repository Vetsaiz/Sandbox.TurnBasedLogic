using System;
using System.Collections.Generic;
using MetaLogic.Contracts;
using SampesLogic.Client.State;
using SampesLogic.Data;

namespace SampesLogic.Client
{
    public class ClientDataCreator
    {
        public static string CreateSampleState(ISerializator serializator)
        {
            var data = new Internal_StateData
            {
                _TestComplexState = 
                new Internal_ITestComplexState
                {
                    _TestString = 
                    "sampleValue"                    ,                    _TestInt = 
                    default(Int32)                    ,                    _SubSet = 
                    new Internal_ITestSubState
                    {
                        _TestFloat = 
                        default(Single)                        ,                        _TestDouble = 
                        default(Int64)                        ,                        _TestData = 
                        null                        ,                        _Commands = 
                        new String[]
                        {
                            "sampleValue"                        }
                        ,                    }
                    ,                    _TestData = 
                    null                    ,                }
                ,                _TestClientState = 
                new Internal_ITestClientState
                {
                    _TestElements = 
                    new Internal_ITestElementsState
                    {
                        _Element = 
                        "sampleValue"                        ,                        _Element1 = 
                        default(Int32)                        ,                        _Element2 = 
                        default(Int64)                        ,                        _Element3 = 
                        default(Single)                        ,                        _Element4 = 
                        default(Double)                        ,                        _Element5 = 
                        default(Boolean)                        ,                        _Element6 = 
                        null                        ,                        _Element7 = 
                        default(TestEnum)                        ,                        _Element8 = 
                        new Internal_ITestSampleState
                        {
                            _TestString = 
                            "sampleValue"                            ,                            _TestInt = 
                            default(Int32)                            ,                        }
                        ,                    }
                    ,                    _TestDict = 
                    new Internal_ITestDictState
                    {
                        _DictElement = 
                        new Dictionary<string, String>
                        {
                            {
                                "sampleKey", 
                                "sampleValue"                            }
                        }
                        ,                        _DictElement1 = 
                        new Dictionary<string, Int32>
                        {
                            {
                                "sampleKey", 
                                default(Int32)                            }
                        }
                        ,                        _DictElement2 = 
                        new Dictionary<string, Int64>
                        {
                            {
                                "sampleKey", 
                                default(Int64)                            }
                        }
                        ,                        _DictElement3 = 
                        new Dictionary<string, Single>
                        {
                            {
                                "sampleKey", 
                                default(Single)                            }
                        }
                        ,                        _DictElement4 = 
                        new Dictionary<string, Double>
                        {
                            {
                                "sampleKey", 
                                default(Double)                            }
                        }
                        ,                        _DictElement5 = 
                        new Dictionary<string, Boolean>
                        {
                            {
                                "sampleKey", 
                                default(Boolean)                            }
                        }
                        ,                        _DictElement8 = 
                        new Dictionary<string, Internal_ITestSampleState>
                        {
                            {
                                "sampleKey", 
                                new Internal_ITestSampleState
                                {
                                    _TestString = 
                                    "sampleValue"                                    ,                                    _TestInt = 
                                    default(Int32)                                    ,                                }
                            }
                        }
                        ,                        _DictElement9 = 
                        new Dictionary<string, String>
                        {
                            {
                                "sampleKey", 
                                "sampleValue"                            }
                        }
                        ,                        _DictElement10 = 
                        new Dictionary<string, Internal_ITestSampleState>
                        {
                            {
                                "sampleKey", 
                                new Internal_ITestSampleState
                                {
                                    _TestString = 
                                    "sampleValue"                                    ,                                    _TestInt = 
                                    default(Int32)                                    ,                                }
                            }
                        }
                        ,                        _DictElement11 = 
                        new Dictionary<string, Int32[]>
                        {
                            {
                                "sampleKey", 
                                new Int32[]
                                {
                                    default(Int32)                                }
                            }
                        }
                        ,                    }
                    ,                    _TestList = 
                    new Internal_ITestListState
                    {
                        _ListElement = 
                        new List<String>
                        {
                            "sampleValue"                        }
                        ,                        _ListElement1 = 
                        new List<Int32>
                        {
                            default(Int32)                        }
                        ,                        _ListElement2 = 
                        new List<Int64>
                        {
                            default(Int64)                        }
                        ,                        _ListElement3 = 
                        new List<Single>
                        {
                            default(Single)                        }
                        ,                        _ListElement4 = 
                        new List<Double>
                        {
                            default(Double)                        }
                        ,                        _ListElement5 = 
                        new List<Boolean>
                        {
                            default(Boolean)                        }
                        ,                        _ListElement6 = 
                        new List<SimpleTestData>
                        {
                            null                        }
                        ,                        _ListElement7 = 
                        new List<TestEnum>
                        {
                            default(TestEnum)                        }
                        ,                        _ListElement8 = 
                        new List<Internal_ITestSampleState>
                        {
                            new Internal_ITestSampleState
                            {
                                _TestString = 
                                "sampleValue"                                ,                                _TestInt = 
                                default(Int32)                                ,                            }
                        }
                        ,                    }
                    ,                    _TestArray = 
                    new Internal_ITestArrayState
                    {
                        _ArrayElement = 
                        new String[]
                        {
                            "sampleValue"                        }
                        ,                        _ArrayElement1 = 
                        new Int32[]
                        {
                            default(Int32)                        }
                        ,                        _ArrayElement2 = 
                        new Int64[]
                        {
                            default(Int64)                        }
                        ,                        _ArrayElement3 = 
                        new Single[]
                        {
                            default(Single)                        }
                        ,                        _ArrayElement4 = 
                        new Double[]
                        {
                            default(Double)                        }
                        ,                        _ArrayElement5 = 
                        new Boolean[]
                        {
                            default(Boolean)                        }
                        ,                        _ArrayElement6 = 
                        new SimpleTestData[]
                        {
                            null                        }
                        ,                        _ArrayElement7 = 
                        new TestEnum[]
                        {
                            default(TestEnum)                        }
                        ,                    }
                    ,                }
                ,                _TestServerState = 
                new Internal_ITestServerState
                {
                    _TestServerElements = 
                    new Internal_ITestServerElementsState
                    {
                        _ServerElement = 
                        "sampleValue"                        ,                        _ServerElement1 = 
                        default(Int32)                        ,                        _ServerElement2 = 
                        default(Int64)                        ,                        _ServerElement3 = 
                        default(Single)                        ,                        _ServerElement4 = 
                        default(Double)                        ,                        _ServerElement5 = 
                        default(Boolean)                        ,                        _ServerElement6 = 
                        null                        ,                        _ServerElement7 = 
                        default(TestEnum)                        ,                    }
                    ,                    _TestServerArray = 
                    new Internal_ITestServerArrayState
                    {
                        _ArrayServerElement = 
                        new String[]
                        {
                            "sampleValue"                        }
                        ,                        _ArrayServerElement1 = 
                        new Int32[]
                        {
                            default(Int32)                        }
                        ,                        _ArrayServerElement2 = 
                        new Int64[]
                        {
                            default(Int64)                        }
                        ,                        _ArrayServerElement3 = 
                        new Single[]
                        {
                            default(Single)                        }
                        ,                        _ArrayServerElement4 = 
                        new Double[]
                        {
                            default(Double)                        }
                        ,                        _ArrayServerElement5 = 
                        new Boolean[]
                        {
                            default(Boolean)                        }
                        ,                        _ArrayServerElement6 = 
                        new SimpleTestData[]
                        {
                            null                        }
                        ,                        _ArrayServerElement7 = 
                        new TestEnum[]
                        {
                            default(TestEnum)                        }
                        ,                    }
                    ,                }
                ,            }
            ;return serializator.Serialize(data);
        }
    }
}
