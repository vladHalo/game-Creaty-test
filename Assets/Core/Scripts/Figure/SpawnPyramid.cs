using UnityEngine;

namespace Core.Scripts.Figure
{
    public class SpawnPyramid : SpawnFigure
    {
        public override void Spawn()
        {
            SetParameters();

            int numberOfLayers = Mathf.FloorToInt(_size / _figureSize);

            for (int layer = 0; layer < numberOfLayers; layer++)
            {
                float layerHeight = layer * _figureSize;
                float yOffset = -_size / 2f + layerHeight / 2f;

                int numberOfCubesX = Mathf.FloorToInt((_size - layerHeight) / _figureSize);
                int numberOfCubesZ = Mathf.FloorToInt((_size - layerHeight) / _figureSize);

                float stepX = (_size - layerHeight) / numberOfCubesX;
                float stepZ = (_size - layerHeight) / numberOfCubesZ;

                for (int i = 0; i < numberOfCubesX; i++)
                {
                    for (int k = 0; k < numberOfCubesZ; k++)
                    {
                        float x = -_size / 2f + layerHeight / 2f + i * stepX + _figureSize / 2f;
                        float y = yOffset;
                        float z = -_size / 2f + layerHeight / 2f + k * stepZ + _figureSize / 2f;

                        Vector3 position = new Vector3(x, y, z);

                        Instance(position);
                    }
                }
            }

            SetParentPostion();
        }
    }
}