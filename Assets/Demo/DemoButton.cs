using UnityEngine;
using unityroom.Api;

namespace Demo
{
    public class DemoButton : MonoBehaviour
    {
        private int _count = 0;

        public void OnClick()
        {
            _count++;
            UnityroomApiClient.Instance.SendScore(1, _count, ScoreboardWriteMode.Always);
        }
    }
}