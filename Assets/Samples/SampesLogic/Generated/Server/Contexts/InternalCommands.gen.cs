using System;
using System.Collections.Generic;
using System.Linq;
using SampesLogic.Data;
using VetsEngine.MetaLogic.Core;

namespace SampesLogic.Server
{
    internal class InternalCommands : IServerCommandExecutor
    {
        private InternalModules _modules;

        public InternalCommands(InternalModules modules)
        {
            _modules = modules;
        }
        public void Execute(string nameCommand, object[] args, Action callback)
        {
            switch (nameCommand)
            {
                case "ChangeClientStateTest0":
                {
                    var args0 = (String)args[0];
                    _modules.TestChangeStateModule.ChangeClientStateTest0(args0);
                    break;
                }
                case "ChangeClientStateTest1":
                {
                    var args0 = (Int32)args[0];
                    _modules.TestChangeStateModule.ChangeClientStateTest1(args0);
                    break;
                }
                case "ChangeClientStateTest2":
                {
                    var args0 = long.Parse(args[0].ToString());
                    _modules.TestChangeStateModule.ChangeClientStateTest2(args0);
                    break;
                }
                case "ChangeClientStateTest3":
                {
                    var args0 = (Single)(double)args[0];
                    _modules.TestChangeStateModule.ChangeClientStateTest3(args0);
                    break;
                }
                case "ChangeClientStateTest4":
                {
                    var args0 = (Double)args[0];
                    _modules.TestChangeStateModule.ChangeClientStateTest4(args0);
                    break;
                }
                case "ChangeClientStateTest5":
                {
                    var args0 = (Boolean)args[0];
                    _modules.TestChangeStateModule.ChangeClientStateTest5(args0);
                    break;
                }
                case "ChangeClientStateTest6":
                {
                    var args0 = CreateSimpleTestData(args[0]);
                    _modules.TestChangeStateModule.ChangeClientStateTest6(args0);
                    break;
                }
                case "ChangeClientStateTest7":
                {
                    var args0 = (TestEnum)(int)args[0];
                    _modules.TestChangeStateModule.ChangeClientStateTest7(args0);
                    break;
                }
                case "ChangeClientStateTest8":
                {
                    var args0 = (String)args[0];
                    var args1 = (Int32)args[1];
                    _modules.TestChangeStateModule.ChangeClientStateTest8(args0, args1);
                    break;
                }
                case "ChangeServerStateTest0":
                {
                    var args0 = (String)args[0];
                    _modules.TestChangeServerModule.ChangeServerStateTest0(args0);
                    break;
                }
                case "ChangeServerStateTest1":
                {
                    var args0 = (Int32)args[0];
                    _modules.TestChangeServerModule.ChangeServerStateTest1(args0);
                    break;
                }
                case "ChangeServerStateTest2":
                {
                    var args0 = long.Parse(args[0].ToString());
                    _modules.TestChangeServerModule.ChangeServerStateTest2(args0);
                    break;
                }
                case "ChangeServerStateTest3":
                {
                    var args0 = (Single)(double)args[0];
                    _modules.TestChangeServerModule.ChangeServerStateTest3(args0);
                    break;
                }
                case "ChangeServerStateTest4":
                {
                    var args0 = (Double)args[0];
                    _modules.TestChangeServerModule.ChangeServerStateTest4(args0);
                    break;
                }
                case "ChangeServerStateTest5":
                {
                    var args0 = (Boolean)args[0];
                    _modules.TestChangeServerModule.ChangeServerStateTest5(args0);
                    break;
                }
                case "ChangeServerStateTest6":
                {
                    var args0 = CreateSimpleTestData(args[0]);
                    _modules.TestChangeServerModule.ChangeServerStateTest6(args0);
                    break;
                }
                case "ChangeServerStateTest7":
                {
                    var args0 = (TestEnum)(int)args[0];
                    _modules.TestChangeServerModule.ChangeServerStateTest7(args0);
                    break;
                }
                case "CreateState":
                {
                    _modules.TestModule.CreateState();
                    break;
                }
                case "InputArrayTest1":
                {
                    var args0 = (Int32[])args[0];
                    _modules.TestInputArrayModule.InputArrayTest1(args0);
                    break;
                }
                case "InputArrayTest2":
                {
                    var args0 = (String[])args[0];
                    _modules.TestInputArrayModule.InputArrayTest2(args0);
                    break;
                }
                case "InputArrayTest3":
                {
                    var args0 = ((Object[])args[0]).Select(x => CreateSimpleTestData(x)).ToArray();
                    _modules.TestInputArrayModule.InputArrayTest3(args0);
                    break;
                }
                case "InputArrayTest4":
                {
                    var args0 = ((Object[])args[0]).Select(x => CreateComplexTestData(x)).ToArray();
                    _modules.TestInputArrayModule.InputArrayTest4(args0);
                    break;
                }
                case "InputDictTest1":
                {
                    var args0 = (args[0] as Dictionary<string, object>).ToDictionary(x=> x.Key, x=> (String)x.Value);
                    _modules.TestInputDictModule.InputDictTest1(args0);
                    break;
                }
                case "InputDictTest2":
                {
                    var args0 = (args[0] as Dictionary<string, object>).ToDictionary(x=> x.Key, x=> (Int32)x.Value);
                    _modules.TestInputDictModule.InputDictTest2(args0);
                    break;
                }
                case "InputDictTest3":
                {
                    var args0 = (args[0] as Dictionary<string, object>).ToDictionary(x=> int.Parse(x.Key), x=> (String)x.Value);
                    _modules.TestInputDictModule.InputDictTest3(args0);
                    break;
                }
                case "InputDictTest4":
                {
                    var args0 = (args[0] as Dictionary<string, object>).ToDictionary(x=> int.Parse(x.Key), x=> (Int32)x.Value);
                    _modules.TestInputDictModule.InputDictTest4(args0);
                    break;
                }
                case "InputDictTest5":
                {
                    var args0 = (args[0] as Dictionary<string, object>).ToDictionary(x=> int.Parse(x.Key), x => CreateSimpleTestData(x));
                    _modules.TestInputDictModule.InputDictTest5(args0);
                    break;
                }
                case "InputDictTest6":
                {
                    var args0 = (args[0] as Dictionary<string, object>).ToDictionary(x=> x.Key, x => CreateSimpleTestData(x));
                    _modules.TestInputDictModule.InputDictTest6(args0);
                    break;
                }
                case "InputDictTest7":
                {
                    var args0 = (args[0] as Dictionary<string, object>).ToDictionary(x=> x.Key, x => CreateComplexTestData(x));
                    _modules.TestInputDictModule.InputDictTest7(args0);
                    break;
                }
                case "InputDictTest8":
                {
                    var args0 = (args[0] as Dictionary<string, object>).ToDictionary(x=> int.Parse(x.Key), x => CreateComplexTestData(x));
                    _modules.TestInputDictModule.InputDictTest8(args0);
                    break;
                }
                case "InputElementTest1":
                {
                    var args0 = (String)args[0];
                    _modules.TestInputElementsModule.InputElementTest1(args0);
                    break;
                }
                case "InputElementTest2":
                {
                    var args0 = (Int32)args[0];
                    _modules.TestInputElementsModule.InputElementTest2(args0);
                    break;
                }
                case "InputElementTest3":
                {
                    var args0 = (Boolean)args[0];
                    _modules.TestInputElementsModule.InputElementTest3(args0);
                    break;
                }
                case "InputElementTest4":
                {
                    var args0 = long.Parse(args[0].ToString());
                    _modules.TestInputElementsModule.InputElementTest4(args0);
                    break;
                }
                case "InputElementTest5":
                {
                    var args0 = (Single)(double)args[0];
                    _modules.TestInputElementsModule.InputElementTest5(args0);
                    break;
                }
                case "InputElementTest6":
                {
                    var args0 = (Double)args[0];
                    _modules.TestInputElementsModule.InputElementTest6(args0);
                    break;
                }
                case "InputElementTest7":
                {
                    var args0 = (TestEnum)(int)args[0];
                    _modules.TestInputElementsModule.InputElementTest7(args0);
                    break;
                }
                case "InputListTest1":
                {
                    var args0 = ((List<Int32>)args[0]).ToList();
                    _modules.TestInputListModule.InputListTest1(args0);
                    break;
                }
                case "InputListTest2":
                {
                    var args0 = ((List<String>)args[0]).ToList();
                    _modules.TestInputListModule.InputListTest2(args0);
                    break;
                }
                case "InputListTest3":
                {
                    var args0 = ((Object[])args[0]).Select(x => CreateSimpleTestData(x)).ToList();
                    _modules.TestInputListModule.InputListTest3(args0);
                    break;
                }
                case "InputListTest4":
                {
                    var args0 = ((Object[])args[0]).Select(x => CreateComplexTestData(x)).ToList();
                    _modules.TestInputListModule.InputListTest4(args0);
                    break;
                }
                case "TestMethod1":
                {
                    _modules.TestModule.TestMethod1();
                    break;
                }
                case "TestMethod2":
                {
                    var args0 = (String)args[0];
                    var args1 = (Int32)args[1];
                    _modules.TestModule.TestMethod2(args0, args1);
                    break;
                }
            }
            callback();
        }

        public SimpleTestData CreateSimpleTestData(object obj)
        {
            var dict = obj as Dictionary<string, object>;
            var data = new SimpleTestData
            {
                X = (Int32)dict["X"],
                Y = (Single)(double)dict["Y"],
            }
            ;return data;
        }

        public ComplexTestData CreateComplexTestData(object obj)
        {
            var dict = obj as Dictionary<string, object>;
            var data = new ComplexTestData
            {
            }
            ;return data;
        }
    }
}
