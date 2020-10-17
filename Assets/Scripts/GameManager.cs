using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

sealed class GameManager : MonoBehaviour
{
    [Header("Timer to be set in seconds")]
    [SerializeField] float _timer;
    [SerializeField] Text _canvasTimer;
    [Space]
    [SerializeField] GameObject _gameOver;

    #region Singleton
    public static GameManager instance = null;
    GameManager() {}
    void Awake() => instance = (instance == null) ? this : instance; 
    #endregion

    void Start()
    {
        _gameOver.SetActive(false);
        FindObjectOfType<CameraController>().enabled = true;
        Time.timeScale = 1;
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        _canvasTimer.text = _timer > 0 ? $"Timer: {((int)_timer/60).ToString("D2")}:{((int)_timer%60).ToString("D2")}" : 
                                "Time is over";
        if (_timer <= 0) GameOver();
    }

    void GameOver()
    {
        _gameOver.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        FindObjectOfType<CameraController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Retry()
    {
        Time.timeScale = 0;
        Cursor.visible = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif 
        Application.Quit();
    }
}
