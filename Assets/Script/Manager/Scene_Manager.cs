using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public static Scene_Manager _instance { get; private set; }

    void InitializedSceneManager()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Awake()
    {
        InitializedSceneManager();
        StartScene();
    }

    void StartScene()
    {
        if(SceneManager.GetActiveScene().name == "ManagersScene")
        {
            SceneManager.LoadScene("Prototype 3");
        }
    }
}
