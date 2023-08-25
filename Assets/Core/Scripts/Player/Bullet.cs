using Core.Scripts.Figure;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.instance;
        GetComponent<MeshRenderer>().material.color = _gameManager.colorsManager.GetRandomColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Figure figure))
        {
            _gameManager.SpawnRandomFullFigure();
            Destroy(gameObject);
        }
    }
}