using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Main : MonoBehaviour
{

    Player_Controller _playerController;
    Animator _playerAnimator;
    Rigidbody _playerRigidbody;
    Plyer_Ground_Detector _playerGroundDetector;
    Player_FX_Controller _playerFXController;
    Player_Song_Controller _playerSongController;
    void LoadComponentes()
    {
        if (_playerRigidbody == null)
        {
            _playerRigidbody = GetComponent<Rigidbody>();
        }
        if (_playerController == null)
        {
            _playerController = GetComponentInChildren<Player_Controller>();
        }
        if (_playerGroundDetector == null)
        {
            _playerGroundDetector = GetComponentInChildren<Plyer_Ground_Detector>();
        }
        if(_playerAnimator == null)
        {
            _playerAnimator = GetComponentInChildren<Animator>();
        }
        if(_playerFXController == null)
        {
            _playerFXController = GetComponentInChildren<Player_FX_Controller>();
        }
        if(_playerSongController == null)
        {
            _playerSongController = GetComponentInChildren<Player_Song_Controller>();
        }
    }

    void SuscriptionExplicit()
    {
        if (_playerController != null)
        {
            _playerController.playerRigidbody = _playerRigidbody;
            _playerController.playerAnimator = _playerAnimator;
            _playerController.playerFxController = _playerFXController;
            _playerController.playerSounController = _playerSongController;
        }


    }

    void SuscriptionBySignal()
    {
        if (_playerGroundDetector != null)
        {
            _playerGroundDetector.onGroundByTag = (string tag) =>
            {
                _playerController.groundTag = tag;
                _playerController.PlayerParticleState();
            };
            _playerGroundDetector.onGameOver = () =>
            {
                Game_Manager._instance.TriggerGameOver();
            };
        }
    }

    void SuscriptionManager()
    {
        Game_Manager._instance.onGameOver += _playerController.GameOver;
    }

    void UnSuscriptionManager()
    {
        Game_Manager._instance.onGameOver -= _playerController.GameOver;
    }

    private void OnEnable()
    {
        LoadComponentes();
        SuscriptionExplicit();
        SuscriptionManager();
        SuscriptionBySignal();
    }
    private void OnDisable()
    {
        UnSuscriptionManager();
    }
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _playerController.HanleInpunt();
        Debug.Log(_playerController.groundTag);
    }

    private void FixedUpdate()
    {
        _playerController.PlayerJumop();
        _playerController.PlayerFalling();
    }

    private void LateUpdate()
    {
        
    }

    private void OnDestroy()
    {
        
    }
}
