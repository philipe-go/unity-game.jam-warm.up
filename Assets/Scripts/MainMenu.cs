using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject _startMenu;
    [SerializeField] Transform cameraPlaceHolder;
    [Range(2f, 1000)] public float RotSpeed = 4f; 
    AsyncOperation loadScene;

    void Start() 
    {
        loadScene = new AsyncOperation();
        loadScene = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        loadScene.allowSceneActivation = false;
        _startMenu.SetActive(true);
    }    

    void Update()
    {
        cameraPlaceHolder.transform.Rotate(new Vector3(0,1,0), RotSpeed*Time.deltaTime);
        Camera.main.transform.LookAt(cameraPlaceHolder);
    }

    public void Play()
    {
        loadScene.allowSceneActivation = true;
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif 
        Application.Quit();
    }
}
