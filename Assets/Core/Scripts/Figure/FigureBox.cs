using System.Collections.Generic;
using Lean.Pool;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Scripts.Figure
{
    public class FigureBox : MonoBehaviour
    {
        private float _torqueForce = 6, _upForce = 6;
        private List<Rigidbody> _rigidbodies;
        private GameManager _gameManager;

        public void Init()
        {
            _gameManager = GameManager.instance;
            _rigidbodies = new List<Rigidbody>();
        }

        public void SetPosition()
        {
            float x = Random.Range(_gameManager.zoneSpawnFigureMin.x, _gameManager.zoneSpawnFigureMax.x);
            float y = Random.Range(_gameManager.zoneSpawnFigureMin.y, _gameManager.zoneSpawnFigureMax.y);
            float z = Random.Range(_gameManager.zoneSpawnFigureMin.z, _gameManager.zoneSpawnFigureMax.z);
            transform.position = new Vector3(x, y, z);
        }
        
        public void AddRigidbody(Figure figure)
        {
            figure.meshRenderer.material.color = _gameManager.colorsManager.GetRandomColor();
            figure.BallTrigger += DestroyFigureBox;
            figure.rigidbody.isKinematic = true;
            _rigidbodies.Add(figure.rigidbody);
        }

        [Button, DisableInEditorMode]
        public void DestroyFigureBox()
        {
            foreach (Rigidbody item in _rigidbodies)
            {
                item.isKinematic = false;

                float randTorque = Random.Range(-_torqueForce, _torqueForce);

                item.AddForce(Vector3.up * _upForce, ForceMode.Impulse);
                item.AddTorque(Vector3.right * randTorque + Vector3.forward * randTorque,
                    ForceMode.Impulse);
                item.velocity = Random.onUnitSphere * randTorque;
            }

            Invoke(nameof(DespawnFigures), 8);
        }

        private void DespawnFigures()
        {
            foreach (Rigidbody item in _rigidbodies)
            {
                LeanPool.Despawn(item.gameObject);
            }

            Destroy(gameObject);
        }
    }
}