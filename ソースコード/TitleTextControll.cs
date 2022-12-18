using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleTextControll : MonoBehaviour
{
    public GameObject hiScoreText;
    public GameObject MoneyText;
    // Start is called before the first frame update
    void Start()
    {
         Text hi_text = hiScoreText.GetComponent<Text> ();
         hi_text.text = PlayerPrefs.GetInt("HiScore") + "点";
    }

    // Update is called once per frame
    void Update()
    {
        Text money_text = MoneyText.GetComponent<Text> ();
         money_text.text = PlayerPrefs.GetInt("Money") + "G";
    }
}
