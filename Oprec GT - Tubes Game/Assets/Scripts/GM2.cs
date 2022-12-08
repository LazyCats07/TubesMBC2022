using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM2 : MonoBehaviour
{
    [SerializeField]
    GameObject Party;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    
      public void PartyClicked()
    {
        Party.SetActive(true);
        Time.timeScale = 0f;
    }  
    
}
