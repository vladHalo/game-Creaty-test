using UnityEngine;

namespace Core.Scripts.Figure
{
    public class Figure : MonoBehaviour
    {
        public FigureBox figureBox;

        private void OnTriggerEnter(Collider other)
        {
            figureBox.DestroyFigureBox();
        }
    }
}