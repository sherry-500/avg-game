using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public List<AudioClip> audioList;
    private int next;
    // Start is called before the first frame update
    void Awake()
    {
        next = 0;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            AudioSource aud = this.GetComponent<AudioSource>();
            if (aud.isPlaying)
            {
                aud.Stop();
            }
            else aud.Play();
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            AudioSource aud = this.GetComponent<AudioSource>();
            if (aud.isPlaying)
            {
                aud.Stop();
                next++;
                if (next >= audioList.Count) next = 0;
                aud.clip = audioList[next];
                aud.Play();
            }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            AudioSource aud = this.GetComponent<AudioSource>();
            if (aud.isPlaying)
            {
                aud.Stop();
                next--;
                if (next < 0) next = audioList.Count - 1;
                aud.clip = audioList[next];
                aud.Play();
            }
        }
    }
}