using UnityEngine;

namespace Core.Scripts.Figure
{
    public class SpawnRectangle : SpawnCube
    {
        public override void Spawn()
        {
            CubeOrRectangle(2);
        }
    }
}