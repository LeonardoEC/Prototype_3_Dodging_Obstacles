using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Movement : MonoBehaviour
{
    float _scrollSpeed = 0.1f;
    Material _backgroundMaterial;
    Vector2 _offset;
    bool _isGameOver = false;

    private void OnEnable()
    {
        _backgroundMaterial = GetComponent<Renderer>().material;
        Game_Manager._instance.onGameOver += BackgroundGameOver;
    }

    private void OnDisable()
    {
        Game_Manager._instance.onGameOver -= BackgroundGameOver;
    }

    private void Update()
    {
        BackgroundMovement();
    }



    void BackgroundMovement()
    {
        if(_isGameOver == false)
        {
            _offset.x += _scrollSpeed * Time.deltaTime;
            _backgroundMaterial.mainTextureOffset = _offset;
        }
    }


    void BackgroundGameOver()
    {
        _isGameOver = true;
    }
}
