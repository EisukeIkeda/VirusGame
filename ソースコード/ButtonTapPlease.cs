using DG.Tweening;
using TMPro;
using UnityEngine;

public class ButtonTapPlease : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro = this.gameObject.GetComponent<TextMeshProUGUI>();
        Initialize();
        Play(1.0f);
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