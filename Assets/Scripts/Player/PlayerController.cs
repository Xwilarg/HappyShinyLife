using UnityEngine;
using UnityEngine.InputSystem;

namespace HappyShinyLife.Player
{
    public class PlayerController : MonoBehaviour
    {
        private Vector2 _mov;
        private Rigidbody2D _rb;

        private Interactible _target;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (StoryManager.Instance.IsInStory)
            {
                return;
            }
            _rb.velocity = new Vector2(_mov.x * 5f, _rb.velocity.y);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Interactible target))
            {
                _target = target;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Interactible>(out _))
            {
                _target = null;
            }
        }

        public void OnMove(InputAction.CallbackContext value)
        {
            _mov = value.ReadValue<Vector2>().normalized;
        }

        public void OnNextDialogue(InputAction.CallbackContext value)
        {
            if (value.performed)
            {
                var wasInStory = StoryManager.Instance.IsInStory;
                StoryManager.Instance.NextDialogue();
                if (_target != null && !wasInStory && !StoryManager.Instance.IsInStory) // There is a valid target and we weren't in a dialogue
                {
                    _target.Invoke();
                }
            }
        }
    }
}
