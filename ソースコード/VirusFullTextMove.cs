using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VirusFullTextMove : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro = this.gameObject.GetComponent<TextMeshProUGUI>();
        Initialize();
        Play(1.0f);
    }

    void Update()
    {
        CanvasGroup can = this.gameObject.GetComponent<CanvasGroup>();
        if(can.alpha == 1f){can.DOFade(0,3);}
    }

    private void Initialize()
    {
        textMeshPro.DOFade(0, 0);
        textMeshPro.characterSpacing = -10;
    }

    private void Play(float duration)
    {
        // 文字間隔を開ける
        DOTween.To(() => textMeshPro.characterSpacing, value => textMeshPro.characterSpacing = value, 1, duration)
            .SetLoops(-1,LoopType.Yoyo);

        // フェード
        DOTween.Sequence()
            .Append(textMeshPro.DOFade(1, duration / 4))
            .AppendInterval(duration / 2);
    }
}