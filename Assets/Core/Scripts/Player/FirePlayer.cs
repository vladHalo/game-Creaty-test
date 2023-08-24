using UnityEngine;

namespace Core.Scripts.Player
{
    [RequireComponent(typeof(Animator))]
    public class FirePlayer : Player
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                _animator.SetTrigger(Str.Fire);
                _joystick.gameObject.SetActive(false);
                Invoke(nameof(EnableJoystick), 2);
            }
        }

        private void EnableJoystick() => _joystick.gameObject.SetActive(true);
    }
}