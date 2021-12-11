using UnityEngine;

namespace Assets._Game.Scripts
{
    public class HintHelper : MonoBehaviour
    {
        [SerializeField]
        private string[] ListHints;

        public string GetText(int index)
        {
            if (index >= 0 && index < ListHints.Length)
            {
                return ListHints[index];
            }
            return "'Git gud.";
        }
    }
}