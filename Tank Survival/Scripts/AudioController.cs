using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource[] sounds;
    [SerializeField] private float soundVolume = .18f;

    private void Start()
    {
        for (int i = 0; i < sounds.Length; ++i)
        {
            sounds[i].volume = soundVolume;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (UIManager.instance.gameOver)
        {
            for (int i = 0; i < sounds.Length; ++i)
            {
                sounds[i].volume = 0;
            }
        }
    }
}
