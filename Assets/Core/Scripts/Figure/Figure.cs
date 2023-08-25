using UnityEngine;

namespace Core.Scripts.Figure
{
    public class Figure : MonoBehaviour
    {
        [HideInInspector] public FigureBox figureBox;

        public Collider collider;
        public MeshRenderer meshRenderer;
        public Rigidbody rigidbody;
    }
}