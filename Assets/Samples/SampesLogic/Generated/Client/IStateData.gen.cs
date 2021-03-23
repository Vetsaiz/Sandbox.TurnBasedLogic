using System;
using System.Collections.Generic;
using SampesLogic.Data;
using SampesLogic.Logic.StaticData;
using UniRx;

namespace SampesLogic.Client
{
    public interface IStateData
    {
        ITestClientStateClient TestClientState {get;}
        ITestComplexStateClient TestComplexState {get;}
        ITestServerStateClient TestServerState {get;}
    }

    public interface ITestArrayStateClient
    {
        IReadOnlyReactiveProperty<String[]> ArrayElement {get;}
        IReadOnlyReactiveProperty<Int32[]> ArrayElement1 {get;}
        IReadOnlyReactiveProperty<Int64[]> ArrayElement2 {get;}
        IReadOnlyReactiveProperty<Single[]> ArrayElement3 {get;}
        IReadOnlyReactiveProperty<Double[]> ArrayElement4 {get;}
        IReadOnlyReactiveProperty<Boolean[]> ArrayElement5 {get;}
        IReadOnlyReactiveProperty<SimpleTestData[]> ArrayElement6 {get;}
        IReadOnlyReactiveProperty<TestEnum[]> ArrayElement7 {get;}
        ITestSampleStateClient[] ArrayElement8 {get;}
    }
    public interface ITestClientStateClient
    {
        IReadOnlyReactiveProperty<ITestElementsStateClient> TestElements {get;}
        IReadOnlyReactiveProperty<ITestDictStateClient> TestDict {get;}
        IReadOnlyReactiveProperty<ITestListStateClient> TestList {get;}
        IReadOnlyReactiveProperty<ITestArrayStateClient> TestArray {get;}
        String GetElement();
        Int32 GetElement1();
        Int64 GetElement2();
        Single GetElement3();
        Double GetElement4();
        Boolean GetElement5();
        SimpleTestData GetElement6();
        ComplexTestData GetElement7();
        ITestElementStatic GetElement8();
        IReadOnlyDictionary<String, String> GetDictElements();
        IReadOnlyDictionary<String, Int32> GetDictElements1();
        IReadOnlyDictionary<Int32, String> GetDictElements2();
        IReadOnlyDictionary<Int32, ITestElementStatic> GetDictElements3();
        IReadOnlyDictionary<Int32, SimpleTestData> GetDictElements4();
        String[] GetArrayElements();
        Int32[] GetArrayElements1();
        SimpleTestData[] GetArrayElements2();
        ITestElementStatic[] GetArrayElements3();
        ITestElementsStateClient TestElementsStatic {get;}
        String ElementStatic {get;}
        Int32 Element1Static {get;}
        Int64 Element2Static {get;}
        Single Element3Static {get;}
        Double Element4Static {get;}
        Boolean Element5Static {get;}
        SimpleTestData Element6Static {get;}
        ComplexTestData Element7Static {get;}
        ITestElementStatic Element8Static {get;}
        IReadOnlyDictionary<String, String> DictElementsStatic {get;}
        IReadOnlyDictionary<String, Int32> DictElements1Static {get;}
        IReadOnlyDictionary<Int32, String> DictElements2Static {get;}
        IReadOnlyDictionary<Int32, ITestElementStatic> DictElements3Static {get;}
        IReadOnlyDictionary<Int32, SimpleTestData> DictElements4Static {get;}
        String[] ArrayElementsStatic {get;}
        Int32[] ArrayElements1Static {get;}
        SimpleTestData[] ArrayElements2Static {get;}
        ITestElementStatic[] ArrayElements3Static {get;}
    }
    public interface ITestComplexStateClient
    {
        String TestString {get;}
        IReadOnlyReactiveProperty<Int32> TestInt {get;}
        IReadOnlyReactiveProperty<ITestSubStateClient> SubSet {get;}
        IReadOnlyReactiveProperty<SimpleTestData> TestData {get;}
        SimpleTestData GetData();
        SimpleTestData GetStrData(System.String testStr);
        Int32 TestIntStatic {get;}
    }
    public interface ITestDictStateClient
    {
        IReadOnlyReactiveProperty<String> GetDictElementProperty(String key);
        IReadOnlyReactiveDictionary<String, String> DictElement {get;}
        IReadOnlyReactiveProperty<Int32?> GetDictElement1Property(String key);
        IReadOnlyReactiveDictionary<String, Int32> DictElement1 {get;}
        IReadOnlyReactiveProperty<Int64?> GetDictElement2Property(String key);
        IReadOnlyReactiveDictionary<String, Int64> DictElement2 {get;}
        IReadOnlyReactiveProperty<Single?> GetDictElement3Property(String key);
        IReadOnlyReactiveDictionary<String, Single> DictElement3 {get;}
        IReadOnlyReactiveProperty<Double?> GetDictElement4Property(String key);
        IReadOnlyReactiveDictionary<String, Double> DictElement4 {get;}
        IReadOnlyReactiveProperty<Boolean?> GetDictElement5Property(String key);
        IReadOnlyReactiveDictionary<String, Boolean> DictElement5 {get;}
        IReadOnlyReactiveProperty<ITestSampleStateClient> GetDictElement8Property(String key);
        IReadOnlyReactiveDictionary<String, ITestSampleStateClient> DictElement8 {get;}
        IReadOnlyReactiveProperty<String> GetDictElement9Property(Int32 key);
        IReadOnlyReactiveDictionary<Int32, String> DictElement9 {get;}
        IReadOnlyReactiveProperty<ITestSampleStateClient> GetDictElement10Property(Int32 key);
        IReadOnlyReactiveDictionary<Int32, ITestSampleStateClient> DictElement10 {get;}
        IReadOnlyReactiveProperty<Int32[]> GetDictElement11Property(String key);
        IReadOnlyReactiveDictionary<String, Int32[]> DictElement11 {get;}
        IReadOnlyReactiveProperty<Int32?> GetDictElement12Property(TestEnum key);
        IReadOnlyReactiveDictionary<TestEnum, Int32> DictElement12 {get;}
        IReadOnlyReactiveProperty<IReadOnlyReactiveCollection<Int32>> GetDictElement14Property(String key);
        IReadOnlyReactiveProperty<IReadOnlyReactiveCollection<ITestSampleStateClient>> GetDictElement13Property(String key);
    }
    public interface ITestElementsStateClient
    {
        IReadOnlyReactiveProperty<String> Element {get;}
        IReadOnlyReactiveProperty<Int32> Element1 {get;}
        IReadOnlyReactiveProperty<Int64> Element2 {get;}
        IReadOnlyReactiveProperty<Single> Element3 {get;}
        IReadOnlyReactiveProperty<Double> Element4 {get;}
        IReadOnlyReactiveProperty<Boolean> Element5 {get;}
        IReadOnlyReactiveProperty<SimpleTestData> Element6 {get;}
        IReadOnlyReactiveProperty<TestEnum> Element7 {get;}
        IReadOnlyReactiveProperty<ITestSampleStateClient> Element8 {get;}
    }
    public interface ITestListStateClient
    {
        IReadOnlyReactiveCollection<String> ListElement {get;}
        IReadOnlyReactiveCollection<Int32> ListElement1 {get;}
        IReadOnlyReactiveCollection<Int64> ListElement2 {get;}
        IReadOnlyReactiveCollection<Single> ListElement3 {get;}
        IReadOnlyReactiveCollection<Double> ListElement4 {get;}
        IReadOnlyReactiveCollection<Boolean> ListElement5 {get;}
        IReadOnlyReactiveCollection<SimpleTestData> ListElement6 {get;}
        IReadOnlyReactiveCollection<TestEnum> ListElement7 {get;}
        IReadOnlyReactiveCollection<ITestSampleStateClient> ListElement8 {get;}
    }
    public interface ITestSampleStateClient
    {
        String TestString {get;}
        Int32 TestInt {get;}
    }
    public interface ITestServerArrayStateClient
    {
        IReadOnlyReactiveProperty<String[]> ArrayServerElement {get;}
        IReadOnlyReactiveProperty<Int32[]> ArrayServerElement1 {get;}
        IReadOnlyReactiveProperty<Int64[]> ArrayServerElement2 {get;}
        IReadOnlyReactiveProperty<Single[]> ArrayServerElement3 {get;}
        IReadOnlyReactiveProperty<Double[]> ArrayServerElement4 {get;}
        IReadOnlyReactiveProperty<Boolean[]> ArrayServerElement5 {get;}
        IReadOnlyReactiveProperty<SimpleTestData[]> ArrayServerElement6 {get;}
        IReadOnlyReactiveProperty<TestEnum[]> ArrayServerElement7 {get;}
    }
    public interface ITestServerElementsStateClient
    {
        IReadOnlyReactiveProperty<String> ServerElement {get;}
        IReadOnlyReactiveProperty<Int32> ServerElement1 {get;}
        IReadOnlyReactiveProperty<Int64> ServerElement2 {get;}
        IReadOnlyReactiveProperty<Single> ServerElement3 {get;}
        IReadOnlyReactiveProperty<Double> ServerElement4 {get;}
        IReadOnlyReactiveProperty<Boolean> ServerElement5 {get;}
        IReadOnlyReactiveProperty<SimpleTestData> ServerElement6 {get;}
        IReadOnlyReactiveProperty<TestEnum> ServerElement7 {get;}
    }
    public interface ITestServerStateClient
    {
        IReadOnlyReactiveProperty<ITestServerElementsStateClient> TestServerElements {get;}
        IReadOnlyReactiveProperty<ITestServerArrayStateClient> TestServerArray {get;}
    }
    public interface ITestSubStateClient
    {
        Single TestFloat {get;}
        IReadOnlyReactiveProperty<Int64> TestDouble {get;}
        SimpleTestData TestData {get;}
        IReadOnlyReactiveProperty<String[]> Commands {get;}
    }
}
