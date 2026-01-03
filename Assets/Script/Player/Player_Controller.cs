using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [HideInInspector] public Rigidbody playerRigidbody;
    [HideInInspector] public Animator playerAnimator;
    [HideInInspector] public Player_FX_Controller playerFxController;
    [HideInInspector] public string groundTag;
    [HideInInspector] public Player_Song_Controller playerSounController;

    bool _isJumping = false;
    float _jumpForce = 7f;
    float _fallForce = 4.3f;
    bool _isGameOver = false;

    public void HanleInpunt()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isJumping == false && groundTag == "Ground")
        {
            _isJumping = true;
        }
    }

    public void PlayerParticleState()
    {
        if(groundTag == "Ground" && _isGameOver == false)
        {
            playerFxController.PlayPlayerParticle("FX_DirtSplatter");
        }
        else if(groundTag == "Untagged")
        {
            playerFxController.StopPlayerParticle("FX_DirtSplatter");
        }
    }

    public void PlayerJumop()
    {
        if (_isJumping == true && _isGameOver == false)
        {
            playerRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            playerAnimator.SetTrigger("Jump_trig");
            playerSounController.PlaySong("jump");
            _isJumping = false;
        }
    }

    public void PlayerFalling()
    {
        if (groundTag != "Ground" && playerRigidbody.velocity.y < 0)
        {
            playerRigidbody.AddForce(Vector3.down * _fallForce);
        }

    }

    public void GameOver()
    {
        playerSounController.PlaySong("crash");
        playerAnimator.SetBool("Death_b", true);
        playerFxController.StopPlayerParticle("FX_DirtSplatter");
        playerFxController.PlayPlayerParticle("FX_Explosion_Smoke");
        _isGameOver = true;
        Debug.Log("Game Over");
    }
}
