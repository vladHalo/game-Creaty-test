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
        private List<Figure> _figures;
        private GameManager _gameManager;

        public void Init()
        {
            _gameManager = GameManager.instance;
            _figures = new List<Figure>();
        }

        public void SetPosition()
        {
            float x = Random.Range(_gameManager.zoneSpawnFigureMin.x, _gameManager.zoneSpawnFigureMax.x);
            float y = Random.Range(_gameManager.zoneSpawnFigureMin.y, _gameManager.zoneSpawnFigureMax.y);
            float z = Random.Range(_gameManager.zoneSpawnFigureMin.z, _gameManager.zoneSpawnFigureMax.z);
            transform.position = new Vector3(x, y, z);
        }

        public void AddFigure(Figure figure)
        {
            figure.figureBox = this;
            figure.collider.enabled = true;
            figure.meshRenderer.material.color = _gameManager.colorsManager.GetRandomColor();
            figure.rigidbody.isKinematic = true;
            _figures.Add(figure);
        }

        [Button, DisableInEditorMode]
        public void DestroyFigureBox()
        {
            foreach (Figure item in _figures)
            {
                item.rigidbody.isKinematic = false;
                item.collider.enabled = false;

                float randTorque = Random.Range(-_torqueForce, _torqueForce);

                item.rigidbody.AddForce(Vector3.up * _upForce, ForceMode.Impulse);
                item.rigidbody.AddTorque(Vector3.right * randTorque + Vector3.forward * randTorque,
                    ForceMode.Impulse);
                item.rigidbody.velocity = Random.onUnitSphere * randTorque;
            }

            Invoke(nameof(DespawnFigures), 8);
        }

        private void DespawnFigures()
        {
            foreach (Figure item in _figures)
            {
                LeanPool.Despawn(item.gameObject);
            }

            Destroy(gameObject);
        }
    }
}