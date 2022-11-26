using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource upSound;
    public AudioSource downSound;
    public AudioSource leftSound;
    public AudioSource rightSound;
    public bool startPlaying;
    public BeatScroller beatScroller;

    public static GameManager Instance;

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                beatScroller.hasStarted = true;

                musicSource.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            upSound.Play();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            downSound.Play();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftSound.Play();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightSound.Play();
        }
    }

    public void NoteHit()
    {

    }

    public void NoteMissed()
    {
        // Wrong note method can be a different method

    }
}
