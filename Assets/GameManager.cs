using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] RoadManager _roadManager;
    [SerializeField] CharBehaviour _charBehaviour;
    [SerializeField] GameOverManager _gameOverScreen;
    [SerializeField] CarSpawn _carSpawn;
    [SerializeField] CarMove _carMove;

    GameObject _goScene;
    Canvas _canvas;
    void Start()
    {
        SetDifficulty();
        
        _goScene = GameObject.Find("GameOverMenu");
        _goScene.SetActive(false);
        _canvas=_goScene.GetComponent<Canvas>();
        _canvas.enabled = false;
        _roadManager.SetInitialRoads();
    }

    private void Update()
    {
        SetDifficulty();
        
        if (_charBehaviour.gameover) StartCoroutine(_gameOverScreen.GameOver()) ;

        if (Input.GetKeyDown(KeyCode.Space) && _charBehaviour.gameover && !_gameOverScreen.waitScreen) _gameOverScreen.Restart();
    }
    
    void SetDifficulty()
    {

        switch (_charBehaviour.score)
        {
            case 0:
                _carMove.carSpeed = 20f;
                _carSpawn.minSpawnTime = 2;
                _carSpawn.maxSpawnTime = 4;
                break;
            case 30:
                _carMove.carSpeed = 25f;
                _carSpawn.minSpawnTime = 1;
                _carSpawn.maxSpawnTime = 4;
                break;
            case 60:
                _carMove.carSpeed = 30f;
                _carSpawn.minSpawnTime = 1;
                _carSpawn.maxSpawnTime = 3;
                break;
            case 90:
                _carMove.carSpeed = 35f;
                _carSpawn.minSpawnTime = 0;
                _carSpawn.maxSpawnTime = 3;
                break;
            case 120:
                _carMove.carSpeed = 35f;
                _carSpawn.minSpawnTime = 1;
                _carSpawn.maxSpawnTime = 2;
                break;
            case 160:
                _carMove.carSpeed = 40f;
                _carSpawn.minSpawnTime = 1;
                _carSpawn.maxSpawnTime = 2;
                break;
        }

    }
}   
