using UnityEngine;
using UnityEngine.Serialization;

namespace Core.Scripts.Figure
{
    public class SpawnCircle : SpawnFigure
    {
        public GameObject spherePrefab;
        public int maxSize;

        private void Start()
        {
            Spawn();
        }

        // private void Spawn()
        // {
        //     float sphereDiameter = Random.Range(0, 1);
        //     int outerSphereRadius = Random.Range(1, maxSize);
        //     spherePrefab.transform.localScale = new Vector3(sphereDiameter, sphereDiameter, sphereDiameter);
        //
        //     Transform parent = new GameObject("Spheres").transform;
        //     float sphereRadius = sphereDiameter / 2f;
        //
        //     for (float x = -outerSphereRadius + sphereRadius; x <= outerSphereRadius; x += sphereDiameter)
        //     {
        //         for (float y = -outerSphereRadius + sphereRadius; y <= outerSphereRadius; y += sphereDiameter)
        //         {
        //             for (float z = -outerSphereRadius + sphereRadius; z <= outerSphereRadius; z += sphereDiameter)
        //             {
        //                 Vector3 position = new Vector3(x, y, z);
        //                 float distanceToCenter = Vector3.Distance(position, Vector3.zero);
        //                 if (distanceToCenter <= outerSphereRadius)
        //                 {
        //                     Instantiate(spherePrefab, position, Quaternion.identity, parent);
        //                 }
        //             }
        //         }
        //     }
        // }

        private void Spawn()
        {
            float sphereDiameter = Random.Range(0, 1);
            int squareSize = Random.Range(1, maxSize);
            spherePrefab.transform.localScale = new Vector3(sphereDiameter, sphereDiameter, sphereDiameter);

            Transform parent = new GameObject("Spheres").transform;

            for (float x = -squareSize / 2f; x <= squareSize / 2f; x += sphereDiameter)
            {
                for (float z = -squareSize / 2f; z <= squareSize / 2f; z += sphereDiameter)
                {
                    Vector3 position = new Vector3(x, 0, z);

                    Instantiate(spherePrefab, position, Quaternion.identity, parent);
                }
            }
        }
    }
}