using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ShitSpawn : MonoBehaviour
{
    

    public GameObject obstacle;


    ///virusの出現アニメーション
    void Start()
    {
        DG.Tweening.DOTween.SetTweensCapacity(tweenersCapacity:800, sequencesCapacity:200);///DOTweenで許容するTween数とSequence数を調整
        Transform tran = this.gameObject.GetComponent<Transform>();

         tran.DOScale (
    　　　new Vector2(3f,3f),　　//終了時点のScale
    　　　1f )        
         .SetLink( gameObject );


    }

    // Update is called once per frame
    public void ShitTap()
    {
        Transform obs = obstacle.GetComponent<Transform>();
        CanvasGroup can = this.gameObject.GetComponent<CanvasGroup>();
        can.blocksRaycasts = false;
        can.DOFade(0,1);
        Transform tran = this.gameObject.GetComponent<Transform>();
        /// tran.DOScale (new Vector2(0.1f,0.1f),0f ).SetLink( gameObject );
        obs.DOScale (
    　　　new Vector3(10f,10f,100f),0.3f ) 
         ///.SetEase(Ease.Linear)       
         .SetLink( gameObject );　
         StartCoroutine ("ShitCoroutine");
         }

    IEnumerator ShitCoroutine () 
    {
  	 　　　yield return new WaitForSecondsRealtime(4.0f);
        Transform tran = this.gameObject.GetComponent<Transform>();
        tran.DOMove(new Vector3(0, -5, 100f), 5f).SetEase(Ease.Linear);
        CanvasGroup cana = obstacle.GetComponent<CanvasGroup>();
        cana.DOFade(0,1);
        Destroy(gameObject,2f);

    }
}