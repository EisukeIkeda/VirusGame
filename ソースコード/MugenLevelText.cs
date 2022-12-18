using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class MugenLevelText : MonoBehaviour
{
     private DOTweenTMPAnimator tmpAnimator;
    　 public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro.text = "Level" + PlayerPrefs.GetInt("MugenLevel");
        Initialize();
        Play(3.5f);
    }

    private void Initialize()
    {
        textMeshPro.characterSpacing = -50;
    }

    private void Play(float duration)
    {
        // 文字間隔を開ける
        DOTween.To(() => textMeshPro.characterSpacing, value => textMeshPro.characterSpacing = value, 6, duration)
            .SetEase(Ease.OutQuart);

        // フェード
        DOTween.Sequence()
            .Append(textMeshPro.DOFade(1, duration / 4))
            .AppendInterval(duration / 2)
            .Append(textMeshPro.DOFade(0, duration / 4));
    }

    // Update is called once per frame
    void Update()
    {   

        
    }
}

