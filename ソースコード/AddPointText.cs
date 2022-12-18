using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class AddPointText : MonoBehaviour
{
      private DOTweenTMPAnimator tmpAnimator;
    　 public TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
           textMeshPro = textMeshPro.GetComponent<TextMeshProUGUI>();
           tmpAnimator = new DOTweenTMPAnimator(textMeshPro);
           CanvasGroup can = this.gameObject.GetComponent<CanvasGroup>();
           Transform tran = this.gameObject.GetComponent<Transform>();


        if(PlayerPrefs.GetInt("AddPoint") <= 3)
            {
            textMeshPro.text = "+" + PlayerPrefs.GetInt("AddPoint");
            tran.DOScale (
    　　   　new Vector2(1f,1f),　　//終了時点のScale
    　　　   0f );
             can.DOFade(0,2);       　　　　//時間
            }if(PlayerPrefs.GetInt("AddPoint") <= 50){
               tran.DOScale (
    　　   　new Vector2(5f,5f),0f );
              textMeshPro.text = "+" + PlayerPrefs.GetInt("AddPoint");
              Initialize();
              Play1(2.5f);
              }if(PlayerPrefs.GetInt("AddPoint") > 50){
               tran.DOScale (
    　　   　new Vector2(6f,6f),0f );
              textMeshPro.text = "+" + PlayerPrefs.GetInt("AddPoint");
              Initialize();
              Play(3.5f);
              }
           PlayerPrefs.SetInt("AddPoint" , 0);

            ;
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




            private void Play1(float duration)
    {
        // 文字間隔を開ける
        DOTween.To(() => textMeshPro.characterSpacing, value => textMeshPro.characterSpacing = value, 3, duration)
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
