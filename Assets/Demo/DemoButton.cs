using UnityEngine;

namespace Demo
{
    public class DemoButton : MonoBehaviour
    {
        private int counter = 0;

        public void OnClick()
        {
            counter++;

            var board = new Unityroom.Scoreboard(1, "abc");
            board.SendScore(1.24f);
        }
    }
}
