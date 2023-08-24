using UnityEngine;

namespace Core.Scripts.Figure
{
    public class SpawnCube : SpawnFigure
    {
        public override void Spawn()
        {
            CubeOrRectangle();
        }

        protected void CubeOrRectangle(int number = 1)
        {
            SetParameters();

            int numberOfCubesX = Mathf.FloorToInt((2f * _size) / _figureSize);
            int numberOfCubesY = Mathf.FloorToInt((2f * _size) / _figureSize);
            int numberOfCubesZ = Mathf.FloorToInt((2f * _size) / _figureSize);

            float stepX = (2f * _size) / numberOfCubesX;
            float stepY = (2f * _size) / numberOfCubesY;
            float stepZ = (2f * _size) / numberOfCubesZ;

            for (int i = 0; i < numberOfCubesX; i++)
            {
                for (int j = 0; j < numberOfCubesY / number; j++)
                {
                    for (int k = 0; k < numberOfCubesZ; k++)
                    {
                        float x = -_size + i * stepX + _figureSize / 2f;
                        float y = -_size + j * stepY + _figureSize / 2f;
                        float z = -_size + k * stepZ + _figureSize / 2f;

                        Vector3 position = new Vector3(x, y, z);

                        if (Mathf.Abs(x) <= _size / 2f && Mathf.Abs(y) <= _size / 2f && Mathf.Abs(z) <= _size / 2f)
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