using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LevelupImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform tran = this.gameObject.GetComponent<Transform>();
        CanvasGroup can = this.gameObject.GetComponent<CanvasGroup>();
        can.alpha = 0f;
        can.DOFade(1f,0.5f);
        tran.DOLocalMove(new Vector2(0f, 5f), 1f)
         .SetRelative();
         StartCoroutine("Coroutine");
    }

    IEnumerator Coroutine () {
        CanvasGroup can = this.gameObject.GetComponent<CanvasGroup>();
    yield return new WaitForSeconds(0.5f);
          can.DOFade(0f,0.5f);
          }	　　　
        
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
