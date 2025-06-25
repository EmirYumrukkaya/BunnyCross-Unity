using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject _goScene;
    Canvas _canvas;
    public bool waitScreen;
    bool _gameOverStarted;
    private void Start()
    {
        waitScreen = false;
        _gameOverStarted = false;
    }
    public IEnumerator GameOver()
    {
       if (_gameOverStarted) yield break;

        Time.timeScale = 0.0f;
        _gameOverStarted =true;
        _goScene.SetActive(true);
        _canvas=_goScene.GetComponent<Canvas>();
        _canvas.enabled=true;
        waitScreen=true;
        yield return new WaitForSecondsRealtime(1);
        waitScreen=false;
       
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
    }
}
