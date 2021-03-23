using System;
using System.Collections.Generic;
using MetaLogic.Core;
using SampesLogic.Data;

namespace SampesLogic.Client
{
    internal class EmulateCommands: ICommands
    {
        private InternalModules _modules;

         public EmulateCommands(InternalModules modules)
        {
            _modules = modules;
        }
        public void ChangeClientStateTest0(String stringArg)
        {
            try
            {
                _modules.TestChangeStateModule.ChangeClientStateTest0(stringArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void ChangeClientStateTest1(Int32 intArg)
        {
            try
            {
                _modules.TestChangeStateModule.ChangeClientStateTest1(intArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void ChangeClientStateTest2(Int64 longArg)
        {
            try
            {
                _modules.TestChangeStateModule.ChangeClientStateTest2(longArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void ChangeClientStateTest3(Single floatArg)
        {
            try
            {
                _modules.TestChangeStateModule.ChangeClientStateTest3(floatArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void ChangeClientStateTest4(Double doubleArg)
        {
            try
            {
                _modules.TestChangeStateModule.ChangeClientStateTest4(doubleArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void ChangeClientStateTest5(Boolean boolArg)
        {
            try
            {
                _modules.TestChangeStateModule.ChangeClientStateTest5(boolArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void ChangeClientStateTest6(SimpleTestData dataArg)
        {
            try
            {
                _modules.TestChangeStateModule.ChangeClientStateTest6(dataArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void ChangeClientStateTest7(TestEnum enumArg)
        {
            try
            {
                _modules.TestChangeStateModule.ChangeClientStateTest7(enumArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void ChangeClientStateTest8(String stringArg, Int32 intArg)
        {
            try
            {
                _modules.TestChangeStateModule.ChangeClientStateTest8(stringArg, intArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void ChangeServerStateTest0(String stringArg)
        {
            try
            {
                _modules.TestChangeServerModule.ChangeServerStateTest0(stringArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void ChangeServerStateTest1(Int32 intArg)
        {
            try
            {
                _modules.TestChangeServerModule.ChangeServerStateTest1(intArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void ChangeServerStateTest2(Int64 longArg)
        {
            try
            {
                _modules.TestChangeServerModule.ChangeServerStateTest2(longArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void ChangeServerStateTest3(Single floatArg)
        {
            try
            {
                _modules.TestChangeServerModule.ChangeServerStateTest3(floatArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void ChangeServerStateTest4(Double doubleArg)
        {
            try
            {
                _modules.TestChangeServerModule.ChangeServerStateTest4(doubleArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void ChangeServerStateTest5(Boolean boolArg)
        {
            try
            {
                _modules.TestChangeServerModule.ChangeServerStateTest5(boolArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void ChangeServerStateTest6(SimpleTestData dataArg)
        {
            try
            {
                _modules.TestChangeServerModule.ChangeServerStateTest6(dataArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void ChangeServerStateTest7(TestEnum enumArg)
        {
            try
            {
                _modules.TestChangeServerModule.ChangeServerStateTest7(enumArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void CreateState()
        {
            try
            {
                _modules.TestModule.CreateState();
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputArrayTest1(Int32[] args)
        {
            try
            {
                _modules.TestInputArrayModule.InputArrayTest1(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputArrayTest2(String[] args)
        {
            try
            {
                _modules.TestInputArrayModule.InputArrayTest2(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputArrayTest3(SimpleTestData[] args)
        {
            try
            {
                _modules.TestInputArrayModule.InputArrayTest3(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputArrayTest4(ComplexTestData[] args)
        {
            try
            {
                _modules.TestInputArrayModule.InputArrayTest4(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputDictTest1(Dictionary<String, String> args)
        {
            try
            {
                _modules.TestInputDictModule.InputDictTest1(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputDictTest2(Dictionary<String, Int32> args)
        {
            try
            {
                _modules.TestInputDictModule.InputDictTest2(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputDictTest3(Dictionary<Int32, String> args)
        {
            try
            {
                _modules.TestInputDictModule.InputDictTest3(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputDictTest4(Dictionary<Int32, Int32> args)
        {
            try
            {
                _modules.TestInputDictModule.InputDictTest4(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputDictTest5(Dictionary<Int32, SimpleTestData> args)
        {
            try
            {
                _modules.TestInputDictModule.InputDictTest5(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputDictTest6(Dictionary<String, SimpleTestData> args)
        {
            try
            {
                _modules.TestInputDictModule.InputDictTest6(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputDictTest7(Dictionary<String, ComplexTestData> args)
        {
            try
            {
                _modules.TestInputDictModule.InputDictTest7(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputDictTest8(Dictionary<Int32, ComplexTestData> args)
        {
            try
            {
                _modules.TestInputDictModule.InputDictTest8(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputElementTest1(String arg)
        {
            try
            {
                _modules.TestInputElementsModule.InputElementTest1(arg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputElementTest2(Int32 arg)
        {
            try
            {
                _modules.TestInputElementsModule.InputElementTest2(arg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputElementTest3(Boolean arg)
        {
            try
            {
                _modules.TestInputElementsModule.InputElementTest3(arg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputElementTest4(Int64 arg)
        {
            try
            {
                _modules.TestInputElementsModule.InputElementTest4(arg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputElementTest5(Single arg)
        {
            try
            {
                _modules.TestInputElementsModule.InputElementTest5(arg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputElementTest6(Double arg)
        {
            try
            {
                _modules.TestInputElementsModule.InputElementTest6(arg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputElementTest7(TestEnum arg)
        {
            try
            {
                _modules.TestInputElementsModule.InputElementTest7(arg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputListTest1(List<Int32> args)
        {
            try
            {
                _modules.TestInputListModule.InputListTest1(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputListTest2(List<String> args)
        {
            try
            {
                _modules.TestInputListModule.InputListTest2(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputListTest3(List<SimpleTestData> args)
        {
            try
            {
                _modules.TestInputListModule.InputListTest3(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void InputListTest4(List<ComplexTestData> args)
        {
            try
            {
                _modules.TestInputListModule.InputListTest4(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void TestMethod1()
        {
            try
            {
                _modules.TestModule.TestMethod1();
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
        public void TestMethod2(String arg1, Int32 arg2)
        {
            try
            {
                _modules.TestModule.TestMethod2(arg1, arg2);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
        }
    }
}
