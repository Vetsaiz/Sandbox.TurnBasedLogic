using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MetaTests.Client.Views
{
    public class ViewConsole : MonoBehaviour
    {
        [SerializeField]
        private Text _console = null;

        public void Clear()
        {
            _console.text = "";
        }

        void Awake()
        {
            Application.logMessageReceived += (text, stackTrace, d) =>
            {
                if (d == LogType.Error || d == LogType.Exception)
                {
                    AddConsole($"{text}\n{stackTrace}", ConsoleMessageType.Error);
                }
            };
        }

        public void AddConsole(string message, ConsoleMessageType type)
        {
            _console.text += $"<color=#{_colors[type]}>{message}</color>\n";
            if (type != ConsoleMessageType.Error)
            {
                Debug.Log(message);
            }
        }

        Dictionary<ConsoleMessageType, string> _colors = new Dictionary<ConsoleMessageType, string>
        {
            { ConsoleMessageType.In,"FFFF00"},
            { ConsoleMessageType.Out,"FF00FF"},
            { ConsoleMessageType.Internal,"0000FF"},
            { ConsoleMessageType.Error,"FF0000"}
        };

        public enum ConsoleMessageType
        {
            In,
            Out,
            Internal,
            Error
        }
    }
}
