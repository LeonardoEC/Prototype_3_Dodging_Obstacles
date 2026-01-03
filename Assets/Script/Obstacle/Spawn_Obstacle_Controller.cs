using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Obstacle_Controller : MonoBehaviour
{
    [SerializeField]GameObject _obstaclePrefab;
    float _maxObstacle = 5f;

    List<GameObject> _obstacleList = new List<GameObject>();

    private void OnEnable()
    {
        Game_Manager._instance.onGameOver += SpawnObstacleGameOver;
    }

    private void OnDisable()
    {
        Game_Manager._instance.onGameOver -= SpawnObstacleGameOver;
    }

    private void Start()
    {
        createPoolObstacles();
        InvokeRepeating("SpawnObstacle", 1f, Random.Range(2f, 3f));
    }

    void createPoolObstacles()
    {
        for(int i = 0; i < _maxObstacle; i++)
        {
            GameObject _objObstacle = Instantiate(_obstaclePrefab);
            _objObstacle.SetActive(false);
            _obstacleList.Add(_objObstacle);
        }
    }

    GameObject GetObstacle()
    {
        foreach(GameObject _objObstacle in _obstacleList)
        {
            if(!_objObstacle.activeInHierarchy)
            {
                return _objObstacle;
            }
        }
        return null;
    }

    void SpawnObstacle()
    {
        GameObject obstacle = GetObstacle();
        if(obstacle != null)
        {
            obstacle.transform.position = new Vector3(transform.position.x, transform.position.y, Random.Range(-1f, 1f));
            obstacle.SetActive(true);
        }
    }

    void SpawnObstacleGameOver()
    {
        CancelInvoke("SpawnObstacle");
        this.gameObject.SetActive(false);
    }
}
