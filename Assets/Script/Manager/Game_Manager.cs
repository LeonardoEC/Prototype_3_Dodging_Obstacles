using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager _instance { get; private set; }

    public System.Action onGameOver;
    public System.Action<bool> onPause;
    public System.Action onRestart;

    void InitializedGameManager()
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
        InitializedGameManager();
    }

    public void TriggerGameOver() => onGameOver?.Invoke();
    public void TriggerPause()
    {
        bool isPausing = Time.timeScale == 1f;

        Time.timeScale = isPausing ? 0f : 1f;

        onPause?.Invoke(isPausing);
    }

    public void TriggerRestart() => onRestart?.Invoke();


}
