using DG.Tweening;
using TMPro;
using UnityEngine;

public class CharSpaceAnimationText : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        textMeshPro = this.gameObject.GetComponent<TextMeshProUGUI>();
        Initialize();
        Play(2.5f);
    }

    private void Initialize()
    {
        textMeshPro.DOFade(0, 0);
        textMeshPro.characterSpacing = -50;
    }

    private void Play(float duration)
    {
        // 文字間隔を開ける
        DOTween.To(() => textMeshPro.characterSpacing, value => textMeshPro.characterSpacing = value, 10, duration)
            .SetEase(Ease.OutQuart);

        // フェード
        DOTween.Sequence()
            .Append(textMeshPro.DOFade(1, duration / 4))
            .AppendInterval(duration / 2)
            .Append(textMeshPro.DOFade(0, duration / 4));
    }
}