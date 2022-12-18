using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class MouseMove : MonoBehaviour
{
    Tweener tweener;
    Tweener tweener2;
    public GameObject Ase;
    public int aseFlag;
    public GameObject Mouse;
    // Start is called before the first frame update
    void Start()
    {
        Transform tran = this.gameObject.GetComponent<Transform>();
        CanvasGroup can = this.gameObject.GetComponent<CanvasGroup>();
        
        can.DOFade(1,1);
        tran.DOScale (
    　　　new Vector2(10f,10f),　　//終了時点のScale
    　　　3.0f )        
         .SetLink( gameObject );　　　　　//時間
        tweener2 = tran.DORotate(
        new Vector3(20,0f,0f), 0.5f)
        .SetLoops(-1, LoopType.Yoyo)
        .SetEase(Ease.Linear)
        .SetLink( gameObject , LinkBehaviour.KillOnDisable);
        tweener = tran.DOLocalMove(new Vector3(5000f,0f,0f),60f)
        .SetLink( gameObject , LinkBehaviour.KillOnDisable);
        StartCoroutine("MouseFalse");
    }

    IEnumerator MouseFalse(){
        yield return new WaitForSeconds(30f);
        Mouse.SetActive(false);
    }

    public void MousRun()
    {
        CanvasGroup can = this.gameObject.GetComponent<CanvasGroup>();
        can.blocksRaycasts = false;
        if(aseFlag == 0){
        Transform tran = this.gameObject.GetComponent<Transform>();
        CanvasGroup ase = Ase.GetComponent<CanvasGroup>();
        Transform asetran = Ase.GetComponent<Transform>();
       tweener.Pause();
       tweener2.Pause();
       ase.DOFade(1,0);
       asetran.DOScale (
    　　　new Vector2(1f,1f),　　//終了時点のScale
    　　　1.0f )        
         .SetLink( gameObject , LinkBehaviour.KillOnDisable);　
       tran.DOLocalMove(new Vector3(5000f,0f,0f),10f)
       .SetLink( gameObject , LinkBehaviour.KillOnDisable);
       tran.DORotate(new Vector3(50,0f,0f), 0.1f)
        .SetLoops(50, LoopType.Yoyo)
        .SetEase(Ease.Linear)
        .SetLink( gameObject , LinkBehaviour.KillOnDisable);
        aseFlag = 1;}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
