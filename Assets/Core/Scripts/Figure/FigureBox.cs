using UnityEngine;

namespace Core.Scripts.Figure
{
    [RequireComponent(typeof(BoxCollider))]
    public class FigureBox : MonoBehaviour
    {
        [SerializeField] private float _torqueForce, _upForce;
        [SerializeField] private Rigidbody[] _rigidbodies;

        public void DestroyFigureBox()
        {
            for (int i = 0; i < _rigidbodies.Length; i++)
            {
                _rigidbodies[i].isKinematic = false;

                float randTorque = Random.Range(-_torqueForce, _torqueForce);

                _rigidbodies[i].AddForce(Vector3.up * _upForce, ForceMode.Impulse);
                _rigidbodies[i].AddTorque(Vector3.right * randTorque + Vector3.forward * randTorque,
                    ForceMode.Impulse);
                _rigidbodies[i].velocity = Random.onUnitSphere * randTorque;
            }
        }
    }
}