using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileSpawnPoint : MonoBehaviour, IGameStateListener
{
    [SerializeField] private float bpm = 100f;
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private AudioSource music;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Image line;
    [SerializeField] private DecorEffect decor;
    [SerializeField] private float posY = -2;
    private float nextBeatTime;

    private bool isTimeOn = false;

    float currentY = 0;

    private void Awake()
    {
        Tile.onTapCallBack += MyButton_onTap;
    }

    private void OnDestroy()
    {
        Tile.onTapCallBack -= MyButton_onTap;
    }

    private void OnEnable()
    {
        music.Play();
        nextBeatTime = 60f / bpm;
        isTimeOn = true;

        currentY = posY;
        line.transform.position = new Vector2(line.transform.position.x, currentY);
    }

    private void Update()
    {
        if (!isTimeOn) return;
        if (music.time >= nextBeatTime)
        {
            SpawnTile();
            nextBeatTime += 60f / bpm;
        }

        if (!music.isPlaying && transform.childCount <= 0)
        {
            GameManager.Instance.SetGameState(GameState.STAGECOMPLETE);
        }


    }

    public void GameStateChangeCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.GAMEOVER:
                isTimeOn = false;
                music.Stop();
                foreach (Transform trans in transform)
                {
                    Destroy(trans.gameObject);
                }
                break;
        }
    }

    private void MyButton_onTap(float value)
    {
        float distance = Mathf.Abs(currentY - value);

        ScoreManager.Instance.AddScore(distance);
        decor.PlayAnim();

        if (distance < 1)
        {
            EffectSpawner.Instance.ShowTextEffectPerfect();
            return;
        }

        if (distance < 2)
        {
            EffectSpawner.Instance.ShowTextEffectGreat();
            return;
        }

        if (distance < 3)
        {
            EffectSpawner.Instance.ShowTextEffectGood();
            return;
        }

        currentY = value;
        line.transform.position = new Vector2(line.transform.position.x, currentY);
        EffectSpawner.Instance.ShowTextEffectCool();

    }

    private void SpawnTile()
    {
        Transform lane = SpawnPoint.GetChild(Random.Range(0, SpawnPoint.childCount));
        Vector3 tilePosition = new Vector3(lane.position.x, transform.position.y, 0);
        Tile newTile = Instantiate(tilePrefab, tilePosition, Quaternion.identity, transform);
        newTile.SetEndPoint(endPoint);
    }


}
