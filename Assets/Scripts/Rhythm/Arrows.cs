using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public string arrowType;
    public GameObject[] arrows;
    public bool isUp;
    public bool isRight;
    public bool isDown;
    public bool isLeft;
    public int currentLength;

    public GameObject musicSource;
    public AudioClip[] soundClips;
    public AudioClip wrongClip;
    public ArrowManager arrowManager;
    
    // Start is called before the first frame update
    void Start()
    {
        arrowManager = FindObjectOfType<ArrowManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InstantiateVisuals()
    {
        currentLength = arrowType.Length;
        for (int i = 0; i < arrowType.Length; i++)
        {
            Instantiate(arrows[int.Parse(arrowType[i].ToString())], transform);
            switch(int.Parse(arrowType[i].ToString()))
            {
                case 0:
                    isUp = true;
                    break;
                case 1:
                    isRight = true;
                    break;
                case 2:
                    isDown = true;
                    break;
                case 3:
                    isLeft = true;
                    break;
            }
        }
    }
    public void CheckArrow(KeyCode keyCode)
    {
        if(keyCode==KeyCode.UpArrow)
        {
            if(isUp==true)
            {
                isUp = false;
                CorrectArrow();
            }
            else
            {
                WrongArrow(true);
            }
        }
        else if (keyCode == KeyCode.RightArrow)
        {
            if (isRight == true)
            {
                isRight = false;
                CorrectArrow();
            }
            else
            {
                WrongArrow(true);
            }
        }
        else if (keyCode == KeyCode.DownArrow)
        {
            if (isDown == true)
            {
                isDown = false;
                CorrectArrow();
            }
            else
            {
                WrongArrow(true);
            }
        }
        else if (keyCode == KeyCode.LeftArrow)
        {
            if (isLeft == true)
            {
                isLeft = false;
                CorrectArrow();
            }
            else
            {
                WrongArrow(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HitArea"))
        {
            if (currentLength>0)
            WrongArrow(false);
        }
    }
    public void CorrectArrow()
    {
        currentLength--;
        if(currentLength==0)
        {
            for(int i =0;i<arrowType.Length;i++)
            {
                GameObject musicGO= Instantiate(musicSource, transform.position, Quaternion.identity);
                musicGO.GetComponent<AudioSource>().clip = soundClips[int.Parse(arrowType[i].ToString())];
                musicGO.GetComponent<AudioSource>().Play();
            }
                arrowManager.Correct();
            Destroy(gameObject);
        }
    }
    public void WrongArrow(bool isDestroy)
    {
                arrowManager.Wrong();
        GameObject musicGO = Instantiate(musicSource, transform.position, Quaternion.identity);
        musicGO.GetComponent<AudioSource>().clip = wrongClip;
        musicGO.GetComponent<AudioSource>().Play();
        if(isDestroy)
        {
            foreach (SpriteRenderer spriteRenderer in GetComponentsInChildren<SpriteRenderer>())
                spriteRenderer.enabled = false;
            FindObjectOfType<HitArea>().arrowInArea = null;
        }
    }
}
