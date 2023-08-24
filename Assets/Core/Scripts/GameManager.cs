using Core.Scripts.Colors;
using Core.Scripts.Figure;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] private SpawnFigure[] _spawnFigures;
    
    public ColorsManager colorsManager;
    public Vector3 zoneSpawnFigureMin,zoneSpawnFigureMax; 
    
    private void Start()
    {
        SpawnRandomFullFigure();
    }

    [Button, DisableInEditorMode]
    private void SpawnRandomFullFigure()
    {
        _spawnFigures[Random.Range(0, _spawnFigures.Length)].Spawn();
    }
}