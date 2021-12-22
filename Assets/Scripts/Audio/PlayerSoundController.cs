using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    private AudioSource _audio;
    private PlayerController playercontroller;

    private void Awake()
    {
        _audio = gameObject.GetComponent<AudioSource>();
        playercontroller = gameObject.GetComponent<PlayerController>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0 && playercontroller.IsGrounded())
        {
            Debug.Log("Player audio");
            if (!_audio.isPlaying)
                SoundManager.Instance.PlayPlayerSound(_audio, Sounds.PlayerMove);
        }

    }

}
