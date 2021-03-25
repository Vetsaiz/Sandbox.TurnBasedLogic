using System;
using System.Collections.Generic;
using SampesLogic.Data;

namespace SampesLogic.Client
{
    public interface ICommands
    {
        void ChangeClientStateTest0(String stringArg);
        void ChangeClientStateTest1(Int32 intArg);
        void ChangeClientStateTest2(Int64 longArg);
        void ChangeClientStateTest3(Single floatArg);
        void ChangeClientStateTest4(Double doubleArg);
        void ChangeClientStateTest5(Boolean boolArg);
        void ChangeClientStateTest6(SimpleTestData dataArg);
        void ChangeClientStateTest7(TestEnum enumArg);
        void ChangeClientStateTest8(String stringArg, Int32 intArg);
        void ChangeServerStateTest0(String stringArg);
        void ChangeServerStateTest1(Int32 intArg);
        void ChangeServerStateTest2(Int64 longArg);
        void ChangeServerStateTest3(Single floatArg);
        void ChangeServerStateTest4(Double doubleArg);
        void ChangeServerStateTest5(Boolean boolArg);
        void ChangeServerStateTest6(SimpleTestData dataArg);
        void ChangeServerStateTest7(TestEnum enumArg);
        void CreateState();
        void InputArrayTest1(Int32[] args);
        void InputArrayTest2(String[] args);
        void InputArrayTest3(SimpleTestData[] args);
        void InputArrayTest4(ComplexTestData[] args);
        void InputDictTest1(Dictionary<String, String> args);
        void InputDictTest2(Dictionary<String, Int32> args);
        void InputDictTest3(Dictionary<Int32, String> args);
        void InputDictTest4(Dictionary<Int32, Int32> args);
        void InputDictTest5(Dictionary<Int32, SimpleTestData> args);
        void InputDictTest6(Dictionary<String, SimpleTestData> args);
        void InputDictTest7(Dictionary<String, ComplexTestData> args);
        void InputDictTest8(Dictionary<Int32, ComplexTestData> args);
        void InputElementTest1(String arg);
        void InputElementTest2(Int32 arg);
        void InputElementTest3(Boolean arg);
        void InputElementTest4(Int64 arg);
        void InputElementTest5(Single arg);
        void InputElementTest6(Double arg);
        void InputElementTest7(TestEnum arg);
        void InputListTest1(List<Int32> args);
        void InputListTest2(List<String> args);
        void InputListTest3(List<SimpleTestData> args);
        void InputListTest4(List<ComplexTestData> args);
        void TestMethod1();
        void TestMethod2(String arg1, Int32 arg2);
    }
}
