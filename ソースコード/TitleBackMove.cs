using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleBackMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform tran = this.gameObject.GetComponent<Transform>();
        transform.DOLocalMove(new Vector3(0, 835.5f, 1f), 3f)
        .SetLoops(-1,LoopType.Restart)
        .SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
