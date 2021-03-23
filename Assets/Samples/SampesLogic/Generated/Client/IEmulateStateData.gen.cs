using System;
using System.Collections.Generic;
using SampesLogic.Data;
using SampesLogic.Logic.StaticData;

namespace SampesLogic.Client
{
    public interface IEmulateStateData
    {
        ITestClientStateEmulate TestClientState {get;}
        ITestComplexStateEmulate TestComplexState {get;}
        ITestServerStateEmulate TestServerState {get;}
    }

    public interface ITestArrayStateEmulate
    {
        String[] ArrayElement {get; set;}
        Int32[] ArrayElement1 {get; set;}
        Int64[] ArrayElement2 {get; set;}
        Single[] ArrayElement3 {get; set;}
        Double[] ArrayElement4 {get; set;}
        Boolean[] ArrayElement5 {get; set;}
        SimpleTestData[] ArrayElement6 {get; set;}
        TestEnum[] ArrayElement7 {get; set;}
        ITestSampleStateEmulate[] ArrayElement8 {get;}
    }
    public interface ITestClientStateEmulate
    {
        ITestElementsStateEmulate TestElements {get;}
        ITestDictStateEmulate TestDict {get;}
        ITestListStateEmulate TestList {get;}
        ITestArrayStateEmulate TestArray {get;}
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
    public interface ITestComplexStateEmulate
    {
        String TestString {get;}
        Int32 TestInt {get; set;}
        ITestSubStateEmulate SubSet {get;}
        SimpleTestData TestData {get; set;}
        SimpleTestData GetData();
        SimpleTestData GetStrData(System.String testStr);
        Int32 TestIntStatic {get;}
    }
    public interface ITestDictStateEmulate
    {
        IDictionary<String, String> DictElement {get;}
        IDictionary<String, Int32> DictElement1 {get;}
        IDictionary<String, Int64> DictElement2 {get;}
        IDictionary<String, Single> DictElement3 {get;}
        IDictionary<String, Double> DictElement4 {get;}
        IDictionary<String, Boolean> DictElement5 {get;}
        IDictionary<String, ITestSampleStateEmulate> DictElement8 {get;}
        IDictionary<Int32, String> DictElement9 {get;}
        IDictionary<Int32, ITestSampleStateEmulate> DictElement10 {get;}
        IDictionary<String, Int32[]> DictElement11 {get;}
    }
    public interface ITestElementsStateEmulate
    {
        String Element {get; set;}
        Int32 Element1 {get; set;}
        Int64 Element2 {get; set;}
        Single Element3 {get; set;}
        Double Element4 {get; set;}
        Boolean Element5 {get; set;}
        SimpleTestData Element6 {get; set;}
        TestEnum Element7 {get; set;}
        ITestSampleStateEmulate Element8 {get;}
    }
    public interface ITestListStateEmulate
    {
        IList<String> ListElement {get;}
        IList<Int32> ListElement1 {get;}
        IList<Int64> ListElement2 {get;}
        IList<Single> ListElement3 {get;}
        IList<Double> ListElement4 {get;}
        IList<Boolean> ListElement5 {get;}
        IList<SimpleTestData> ListElement6 {get;}
        IList<TestEnum> ListElement7 {get;}
        IList<ITestSampleStateEmulate> ListElement8 {get;}
    }
    public interface ITestSampleStateEmulate
    {
        String TestString {get;}
        Int32 TestInt {get;}
    }
    public interface ITestServerArrayStateEmulate
    {
        String[] ArrayServerElement {get; set;}
        Int32[] ArrayServerElement1 {get; set;}
        Int64[] ArrayServerElement2 {get; set;}
        Single[] ArrayServerElement3 {get; set;}
        Double[] ArrayServerElement4 {get; set;}
        Boolean[] ArrayServerElement5 {get; set;}
        SimpleTestData[] ArrayServerElement6 {get; set;}
        TestEnum[] ArrayServerElement7 {get; set;}
    }
    public interface ITestServerElementsStateEmulate
    {
        String ServerElement {get; set;}
        Int32 ServerElement1 {get; set;}
        Int64 ServerElement2 {get; set;}
        Single ServerElement3 {get; set;}
        Double ServerElement4 {get; set;}
        Boolean ServerElement5 {get; set;}
        SimpleTestData ServerElement6 {get; set;}
        TestEnum ServerElement7 {get; set;}
    }
    public interface ITestServerStateEmulate
    {
        ITestServerElementsStateEmulate TestServerElements {get;}
        ITestServerArrayStateEmulate TestServerArray {get;}
    }
    public interface ITestSubStateEmulate
    {
        Single TestFloat {get;}
        Int64 TestDouble {get; set;}
        SimpleTestData TestData {get;}
        String[] Commands {get; set;}
    }
}
