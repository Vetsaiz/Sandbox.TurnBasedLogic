using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MetaTests.Client.Views
{
    public class ViewData : MonoBehaviour
    {
        [SerializeField]
        private Text _exp = null;

        [SerializeField]
        private Text _resource = null;

        private List<IDisposable> _currentProfileObservers = new List<IDisposable>();

        public void Init(object data)
        {
            foreach (var temp in _currentProfileObservers)
            {
                temp.Dispose();
            }
            //data.TestState.TestInt.Subscribe(x => _exp.text = x.ToString()).AddTo(_currentProfileObservers);
            //data.TestState.TestData.Subscribe(x => _resource.text = x.ToString()).AddTo(_currentProfileObservers);
        }
    }
}
