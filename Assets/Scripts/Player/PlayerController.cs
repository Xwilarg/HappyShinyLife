using UnityEngine;
using UnityEngine.InputSystem;

namespace HappyShinyLife
{
    public class PlayerController : MonoBehaviour
    {
        private Vector2 _mov;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.velocity = new Vector2(_mov.x, _rb.velocity.y);
        }

        public void OnMove(InputAction.CallbackContext value)
        {
            _mov = value.ReadValue<Vector2>().normalized;
        }

        public void OnNextDialogue(InputAction.CallbackContext value)
        {
            if (value.performed)
            {
                StoryManager.Instance.NextDialogue();
            }
        }
    }
}
