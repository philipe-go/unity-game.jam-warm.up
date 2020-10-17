using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject _startMenu;
    [SerializeField] Transform cameraPlaceHolder;
    [Range(2f, 20)] public float RotSpeed = 4f;

    void Start()
    {
        _startMenu.SetActive(true);
    }

    void Update()
    {
        cameraPlaceHolder.transform.Rotate(new Vector3(0, 1, 0), RotSpeed * Time.deltaTime);
        Camera.main.transform.LookAt(cameraPlaceHolder);
    }

    public void Play()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
