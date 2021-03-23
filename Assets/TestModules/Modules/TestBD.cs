using UnityEngine;

namespace MetaTests.Client.Core
{
    public class TestBD
    {
        public string GetProfile(string id)
        {
            return PlayerPrefs.GetString(id, null);
        }

        public void SetProfile(string id, string profile)
        {
            PlayerPrefs.SetString(id, profile);
        }
    }
}
