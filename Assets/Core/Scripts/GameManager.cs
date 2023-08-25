using Core.Scripts.Colors;
using Core.Scripts.Figure;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] private SpawnFigure[] _spawnFigures;

    [HideInInspector] public FigureBox figureBox;

    public ColorsManager colorsManager;
    public Vector3 zoneSpawnFigureMin, zoneSpawnFigureMax;
    public StatusGame statusGame;

    private void Start()
    {
        SpawnRandomFullFigure();
    }

    [Button, DisableInEditorMode]
    public void SpawnRandomFullFigure()
    {
        if (figureBox != null) figureBox.DestroyFigureBox();
        _spawnFigures[Random.Range(0, _spawnFigures.Length)].Spawn();
        statusGame = StatusGame.MoveCamera;
        Invoke(nameof(ChangeCameraStatus), 3);
    }

    private void ChangeCameraStatus() => statusGame = StatusGame.ReadyGun;
}