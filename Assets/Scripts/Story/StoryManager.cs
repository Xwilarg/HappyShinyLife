using HappyShinyLife.Translation;
using TMPro;
using UnityEngine;

namespace HappyShinyLife
{
    public class StoryManager : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _storyText;

        private int _index = 1;
        private int _maxIndex;
        private string _baseString;

        public static StoryManager Instance;

        private void Awake()
        {
            Instance = this;
            Load("intro", 9);
        }

        public void Load(string baseString, int maxCount)
        {
            _maxIndex = maxCount;
            _baseString = baseString;
            _index = 1;
            _storyText.text = Translate.Instance.Tr($"{baseString}1");
            _storyText.gameObject.SetActive(true);
        }

        public void NextDialogue()
        {
            _index++;
            if (!IsInStory)
            {
                _storyText.gameObject.SetActive(false);
            }
            else
            {
                _storyText.text = Translate.Instance.Tr($"{_baseString}{_index}");
            }
        }

        public bool IsInStory => _index <= _maxIndex;
    }
}
