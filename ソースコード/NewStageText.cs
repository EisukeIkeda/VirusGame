using DG.Tweening;
using TMPro;
using UnityEngine;

public class NewStageText : MonoBehaviour
{
    private DOTweenTMPAnimator tmpAnimator;

    void Start()
    {
        var textMeshPro = this.gameObject.GetComponent<TextMeshProUGUI>();
        tmpAnimator = new DOTweenTMPAnimator(textMeshPro);
        Initialize();
        Play(2.5f);
    }

    private void Initialize()
    {
        for (var i = 0; i < tmpAnimator.textInfo.characterCount; i++)
        {
            tmpAnimator.DOOffsetChar(i, Vector3.zero, 0);

            // 偶数番目の文字は黄色、奇数番目の文字は青色
            var color = i % 2 == 0 ? new Color(1, 0.8f, 0.3f) : new Color(0.3f, 0.7f, 1);
            tmpAnimator.DOColorChar(i, color, 0);  // 秒数に0を指定することで瞬時に変更
        }  
    }

    private void Play(float duration)
    {
        for (var i = 0; i < tmpAnimator.textInfo.characterCount; i++)
        {
            // 偶数番目と奇数番目で方向を変える
            var sign = Mathf.Sign(i % 2 - 0.5f);
            DOTween.Sequence()
                .Append(tmpAnimator.DOOffsetChar(i, Vector3.up * 100 * sign, duration / 2).SetEase(Ease.OutFlash, 2))
                .Append(tmpAnimator.DOOffsetChar(i, Vector3.down * 100 * sign, duration / 2).SetEase(Ease.OutFlash, 2));
        }
    }
}