using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSoundManager : MonoBehaviour
{
    public static CoinSoundManager instance;
    public AudioSource coins_source;
    public AudioClip coin_sound;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        coins_source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
