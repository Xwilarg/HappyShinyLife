using HappyShinyLife.Translation;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace HappyShinyLife
{
    public class StoryManager : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _storyText;

        private int _index = 1;

        private void Awake()
        {
            _storyText.text = Translate.Instance.Tr("intro1");
        }

        public void OnNextDialogue(InputAction.CallbackContext value)
        {
            if (value.performed)
            {
                _index++;
                if (_index == 10)
                {
                    SceneManager.LoadScene("Main");
                }
                else
                {
                    _storyText.text = Translate.Instance.Tr($"intro{_index}");
                }
            }
        }
    }
}
