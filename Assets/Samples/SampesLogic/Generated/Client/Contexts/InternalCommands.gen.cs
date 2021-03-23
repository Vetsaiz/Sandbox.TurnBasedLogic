using System;
using System.Collections.Generic;
using MetaLogic.Contracts;
using MetaLogic.Core;
using SampesLogic.Data;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client
{
    internal class InternalCommands : BaseClientCommands, ICommands
    {
        private InternalModules _modules;

        public InternalCommands(InternalModules modules, ChangeStorage storage, ICommandStorage commandStorage) : base(storage, commandStorage)
        {
            _modules = modules;
        }
        public void ChangeClientStateTest0(String stringArg)
        {
            PreCommand();
            try
            {
                _modules.TestChangeStateModule.ChangeClientStateTest0(stringArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("ChangeClientStateTest0", new object[] {(object)stringArg} );
        }
        public void ChangeClientStateTest1(Int32 intArg)
        {
            PreCommand();
            try
            {
                _modules.TestChangeStateModule.ChangeClientStateTest1(intArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("ChangeClientStateTest1", new object[] {(object)intArg} );
        }
        public void ChangeClientStateTest2(Int64 longArg)
        {
            PreCommand();
            try
            {
                _modules.TestChangeStateModule.ChangeClientStateTest2(longArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("ChangeClientStateTest2", new object[] {(object)longArg} );
        }
        public void ChangeClientStateTest3(Single floatArg)
        {
            PreCommand();
            try
            {
                _modules.TestChangeStateModule.ChangeClientStateTest3(floatArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("ChangeClientStateTest3", new object[] {(object)floatArg} );
        }
        public void ChangeClientStateTest4(Double doubleArg)
        {
            PreCommand();
            try
            {
                _modules.TestChangeStateModule.ChangeClientStateTest4(doubleArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("ChangeClientStateTest4", new object[] {(object)doubleArg} );
        }
        public void ChangeClientStateTest5(Boolean boolArg)
        {
            PreCommand();
            try
            {
                _modules.TestChangeStateModule.ChangeClientStateTest5(boolArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("ChangeClientStateTest5", new object[] {(object)boolArg} );
        }
        public void ChangeClientStateTest6(SimpleTestData dataArg)
        {
            PreCommand();
            try
            {
                _modules.TestChangeStateModule.ChangeClientStateTest6(dataArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("ChangeClientStateTest6", new object[] {(object)dataArg} );
        }
        public void ChangeClientStateTest7(TestEnum enumArg)
        {
            PreCommand();
            try
            {
                _modules.TestChangeStateModule.ChangeClientStateTest7(enumArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("ChangeClientStateTest7", new object[] {(object)(int)enumArg} );
        }
        public void ChangeClientStateTest8(String stringArg, Int32 intArg)
        {
            PreCommand();
            try
            {
                _modules.TestChangeStateModule.ChangeClientStateTest8(stringArg, intArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("ChangeClientStateTest8", new object[] {(object)stringArg, (object)intArg} );
        }
        public void ChangeServerStateTest0(String stringArg)
        {
            PreCommand();
            try
            {
                _modules.TestChangeServerModule.ChangeServerStateTest0(stringArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("ChangeServerStateTest0", new object[] {(object)stringArg} );
        }
        public void ChangeServerStateTest1(Int32 intArg)
        {
            PreCommand();
            try
            {
                _modules.TestChangeServerModule.ChangeServerStateTest1(intArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("ChangeServerStateTest1", new object[] {(object)intArg} );
        }
        public void ChangeServerStateTest2(Int64 longArg)
        {
            PreCommand();
            try
            {
                _modules.TestChangeServerModule.ChangeServerStateTest2(longArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("ChangeServerStateTest2", new object[] {(object)longArg} );
        }
        public void ChangeServerStateTest3(Single floatArg)
        {
            PreCommand();
            try
            {
                _modules.TestChangeServerModule.ChangeServerStateTest3(floatArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("ChangeServerStateTest3", new object[] {(object)floatArg} );
        }
        public void ChangeServerStateTest4(Double doubleArg)
        {
            PreCommand();
            try
            {
                _modules.TestChangeServerModule.ChangeServerStateTest4(doubleArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("ChangeServerStateTest4", new object[] {(object)doubleArg} );
        }
        public void ChangeServerStateTest5(Boolean boolArg)
        {
            PreCommand();
            try
            {
                _modules.TestChangeServerModule.ChangeServerStateTest5(boolArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("ChangeServerStateTest5", new object[] {(object)boolArg} );
        }
        public void ChangeServerStateTest6(SimpleTestData dataArg)
        {
            PreCommand();
            try
            {
                _modules.TestChangeServerModule.ChangeServerStateTest6(dataArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("ChangeServerStateTest6", new object[] {(object)dataArg} );
        }
        public void ChangeServerStateTest7(TestEnum enumArg)
        {
            PreCommand();
            try
            {
                _modules.TestChangeServerModule.ChangeServerStateTest7(enumArg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("ChangeServerStateTest7", new object[] {(object)(int)enumArg} );
        }
        public void CreateState()
        {
            PreCommand();
            try
            {
                _modules.TestModule.CreateState();
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("CreateState", new object[] {} );
        }
        public void InputArrayTest1(Int32[] args)
        {
            PreCommand();
            try
            {
                _modules.TestInputArrayModule.InputArrayTest1(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputArrayTest1", new object[] {(object)args} );
        }
        public void InputArrayTest2(String[] args)
        {
            PreCommand();
            try
            {
                _modules.TestInputArrayModule.InputArrayTest2(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputArrayTest2", new object[] {(object)args} );
        }
        public void InputArrayTest3(SimpleTestData[] args)
        {
            PreCommand();
            try
            {
                _modules.TestInputArrayModule.InputArrayTest3(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputArrayTest3", new object[] {(object)args} );
        }
        public void InputArrayTest4(ComplexTestData[] args)
        {
            PreCommand();
            try
            {
                _modules.TestInputArrayModule.InputArrayTest4(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputArrayTest4", new object[] {(object)args} );
        }
        public void InputDictTest1(Dictionary<String, String> args)
        {
            PreCommand();
            try
            {
                _modules.TestInputDictModule.InputDictTest1(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputDictTest1", new object[] {(object)args} );
        }
        public void InputDictTest2(Dictionary<String, Int32> args)
        {
            PreCommand();
            try
            {
                _modules.TestInputDictModule.InputDictTest2(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputDictTest2", new object[] {(object)args} );
        }
        public void InputDictTest3(Dictionary<Int32, String> args)
        {
            PreCommand();
            try
            {
                _modules.TestInputDictModule.InputDictTest3(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputDictTest3", new object[] {(object)args} );
        }
        public void InputDictTest4(Dictionary<Int32, Int32> args)
        {
            PreCommand();
            try
            {
                _modules.TestInputDictModule.InputDictTest4(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputDictTest4", new object[] {(object)args} );
        }
        public void InputDictTest5(Dictionary<Int32, SimpleTestData> args)
        {
            PreCommand();
            try
            {
                _modules.TestInputDictModule.InputDictTest5(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputDictTest5", new object[] {(object)args} );
        }
        public void InputDictTest6(Dictionary<String, SimpleTestData> args)
        {
            PreCommand();
            try
            {
                _modules.TestInputDictModule.InputDictTest6(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputDictTest6", new object[] {(object)args} );
        }
        public void InputDictTest7(Dictionary<String, ComplexTestData> args)
        {
            PreCommand();
            try
            {
                _modules.TestInputDictModule.InputDictTest7(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputDictTest7", new object[] {(object)args} );
        }
        public void InputDictTest8(Dictionary<Int32, ComplexTestData> args)
        {
            PreCommand();
            try
            {
                _modules.TestInputDictModule.InputDictTest8(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputDictTest8", new object[] {(object)args} );
        }
        public void InputElementTest1(String arg)
        {
            PreCommand();
            try
            {
                _modules.TestInputElementsModule.InputElementTest1(arg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputElementTest1", new object[] {(object)arg} );
        }
        public void InputElementTest2(Int32 arg)
        {
            PreCommand();
            try
            {
                _modules.TestInputElementsModule.InputElementTest2(arg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputElementTest2", new object[] {(object)arg} );
        }
        public void InputElementTest3(Boolean arg)
        {
            PreCommand();
            try
            {
                _modules.TestInputElementsModule.InputElementTest3(arg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputElementTest3", new object[] {(object)arg} );
        }
        public void InputElementTest4(Int64 arg)
        {
            PreCommand();
            try
            {
                _modules.TestInputElementsModule.InputElementTest4(arg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputElementTest4", new object[] {(object)arg} );
        }
        public void InputElementTest5(Single arg)
        {
            PreCommand();
            try
            {
                _modules.TestInputElementsModule.InputElementTest5(arg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputElementTest5", new object[] {(object)arg} );
        }
        public void InputElementTest6(Double arg)
        {
            PreCommand();
            try
            {
                _modules.TestInputElementsModule.InputElementTest6(arg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputElementTest6", new object[] {(object)arg} );
        }
        public void InputElementTest7(TestEnum arg)
        {
            PreCommand();
            try
            {
                _modules.TestInputElementsModule.InputElementTest7(arg);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputElementTest7", new object[] {(object)(int)arg} );
        }
        public void InputListTest1(List<Int32> args)
        {
            PreCommand();
            try
            {
                _modules.TestInputListModule.InputListTest1(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputListTest1", new object[] {(object)args} );
        }
        public void InputListTest2(List<String> args)
        {
            PreCommand();
            try
            {
                _modules.TestInputListModule.InputListTest2(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputListTest2", new object[] {(object)args} );
        }
        public void InputListTest3(List<SimpleTestData> args)
        {
            PreCommand();
            try
            {
                _modules.TestInputListModule.InputListTest3(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputListTest3", new object[] {(object)args} );
        }
        public void InputListTest4(List<ComplexTestData> args)
        {
            PreCommand();
            try
            {
                _modules.TestInputListModule.InputListTest4(args);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("InputListTest4", new object[] {(object)args} );
        }
        public void TestMethod1()
        {
            PreCommand();
            try
            {
                _modules.TestModule.TestMethod1();
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("TestMethod1", new object[] {} );
        }
        public void TestMethod2(String arg1, Int32 arg2)
        {
            PreCommand();
            try
            {
                _modules.TestModule.TestMethod2(arg1, arg2);
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("TestMethod2", new object[] {(object)arg1, (object)arg2} );
        }
    }
}
