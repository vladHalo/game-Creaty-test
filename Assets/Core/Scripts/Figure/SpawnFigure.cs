using Lean.Pool;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Scripts.Figure
{
    public abstract class SpawnFigure : MonoBehaviour
    {
        [SerializeField] protected GameObject _prefab;

        protected float _figureSize;
        protected int _size;

        [SerializeField] private string _name;
        [SerializeField] private int _sizeMin, _sizeMax;

        private FigureBox _figureBox;
        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = GameManager.instance;
        }

        [Button, DisableInEditorMode]
        public abstract void Spawn();

        protected void SetParameters()
        {
            _figureBox = new GameObject(_name).AddComponent<FigureBox>();
            _gameManager.figureBox = _figureBox;
            _figureBox.Init();

            _figureSize = Random.Range(.5f, 1);
            _prefab.transform.localScale = new Vector3(_figureSize, _figureSize, _figureSize);
            _size = Random.Range(_sizeMin, _sizeMax);
        }

        protected void Instance(Vector3 position)
        {
            var figure = LeanPool.Spawn(_prefab, position, Quaternion.identity, _figureBox.transform)
                .GetComponent<Figure>();
            _figureBox.AddFigure(figure);
        }

        protected void SetParentPostion() => _figureBox.SetPosition();
    }
}