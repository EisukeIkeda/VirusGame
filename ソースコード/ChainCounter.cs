using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainCounter : MonoBehaviour
{
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = PlayerPrefs.GetFloat("chain");
        time -= Time.deltaTime;
        PlayerPrefs.SetFloat("chain", time);

    }
}
