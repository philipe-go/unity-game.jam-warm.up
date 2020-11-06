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
    [SerializeField] GameObject _PlayerWinUI;

    public Slider fearMeter;
    public float fearCollected = 0f;
    public const float MAX_FEAR_ORBS = 30f;

    #region Singleton
    public static GameManager instance = null;
    GameManager() {}
    void Awake() => instance = (instance == null) ? this : instance; 
    #endregion

    void Start() {
        _gameOver.SetActive(false);
        _PlayerWinUI.SetActive(false);
        FindObjectOfType<CameraController>().enabled = true;
        Time.timeScale = 1;
        SetMeter();
    }

    void Update() {
        _timer -= Time.deltaTime;
        _canvasTimer.text = _timer > 0 ? $"Timer: {((int)_timer/60).ToString("D2")}:{((int)_timer%60).ToString("D2")}" : 
                                "Time is over";
        if (_timer <= 0) GameOver();
    }

    // ~~ Temporary fucntions
    private void SetMeter() {
        fearMeter.maxValue = MAX_FEAR_ORBS;
        fearMeter.value = fearCollected;
    }

    private void UpdateMeter(float fearValue) {
        fearMeter.value = fearValue;
    }

    public void OrbCollected(float fearOrbValue) {
        fearCollected += fearOrbValue;
        UpdateMeter(fearCollected);
        CheckIfPlayerWon();
    }

    void CheckIfPlayerWon()
    {
        if (fearCollected>=MAX_FEAR_ORBS)
        {
            //Player Won
            Debug.Log("Player Won");
            _PlayerWinUI.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            FindObjectOfType<CameraController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    // ~~end
    void GameOver() {
        _gameOver.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        FindObjectOfType<CameraController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Retry() {
        Time.timeScale = 0;
        Cursor.visible = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif 
        Application.Quit();
    }
}
