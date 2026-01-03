using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Movement : MonoBehaviour
{

    float _obstacleSpeed = 10f;
    Rigidbody _obstacleRb;
    Coroutine _livingTimeObstacle;
    bool _isGameOver = false;

    private void OnEnable()
    {
        _obstacleRb = GetComponent<Rigidbody>();
        _livingTimeObstacle = StartCoroutine(DeactivateObstacle());
        Game_Manager._instance.onGameOver += ObstacleGameOver;
    }
    private void OnDisable()
    {
        Game_Manager._instance.onGameOver -= ObstacleGameOver;
    }

    private void FixedUpdate()
    {
        ObstaculMovement();
    }

    void ObstaculMovement()
    {
        if(_isGameOver == false)
        {
            _obstacleRb.MovePosition(transform.position + Vector3.left * _obstacleSpeed * Time.fixedDeltaTime);
        }

    }


    IEnumerator DeactivateObstacle()
    {
        yield return new WaitForSeconds(3.5f);
        if (_isGameOver == false)
        {            
            gameObject.SetActive(false);
        }
    }

    void ObstacleGameOver()
    {
        _isGameOver = true;
        if(_livingTimeObstacle != null)
        {
            StopCoroutine(_livingTimeObstacle);
        }
    }
}
