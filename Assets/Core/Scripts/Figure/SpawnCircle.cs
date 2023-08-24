using UnityEngine;

namespace Core.Scripts.Figure
{
    public class SpawnCircle : SpawnFigure
    {
        public override void Spawn()
        {
            SetParameters();

            float sphereRadius = _figureSize / 2f;

            int numberOfSpheres = Mathf.FloorToInt((2f * _size) / _figureSize);

            for (int i = 0; i < numberOfSpheres; i++)
            {
                for (int j = 0; j < numberOfSpheres; j++)
                {
                    for (int k = 0; k < numberOfSpheres; k++)
                    {
                        float x = -_size + i * _figureSize + sphereRadius;
                        float y = -_size + j * _figureSize + sphereRadius;
                        float z = -_size + k * _figureSize + sphereRadius;

                        Vector3 position = new Vector3(x, y, z);
                        float distanceToCenter = Vector3.Distance(position, Vector3.zero);

                        if (distanceToCenter <= _size)
                        {
                            Instance(position);
                        }
                    }
                }
            }

            SetParentPostion();
        }
    }
}