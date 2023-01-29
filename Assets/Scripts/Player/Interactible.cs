using System;
using UnityEngine;

namespace HappyShinyLife.Player
{
    public class Interactible : MonoBehaviour
    {
        [SerializeField]
        private InteractionType _interaction;

        [SerializeField]
        private string _argument;

        public void Invoke()
        {
            switch (_interaction)
            {
                case InteractionType:
                    StoryManager.Instance.Load(_argument, 1);
                    break;

                default: throw new NotImplementedException(nameof(_interaction));
            }
        }
    }
}
