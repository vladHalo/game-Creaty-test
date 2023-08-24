using System;
using UnityEngine;

namespace Core.Scripts.Figure
{
    public class Figure : MonoBehaviour
    {
        public Action BallTrigger;
        public MeshRenderer meshRenderer;
        public Rigidbody rigidbody;
        
        private void OnTriggerEnter(Collider other)
        {
            //BallTrigger?.Invoke();
        }
    }
}