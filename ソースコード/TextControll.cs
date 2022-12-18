using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TextControll : MonoBehaviour
{
        
    // Start is called before the first frame update
    void Start()
    {
        
        Transform tran = this.gameObject.GetComponent<Transform>();
        tran.DOLocalMove(new Vector2(0, 500), 0.5f)
         .SetLink( gameObject );　　//時間
         tran.DOScale(new Vector2(2f,2f),0.5f).SetLink( gameObject );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
