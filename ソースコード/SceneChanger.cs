using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{
    public GameObject scenepanela;
    // Start is called before the first frame update
    void Start()
    {
    CanvasGroup scenepanel = scenepanela.GetComponent<CanvasGroup>();
    scenepanel.DOFade(1f,1f);
    StartCoroutine ("SceneStart");
    }

    　　　IEnumerator SceneStart()
　　　{
    CanvasGroup scenepanel = scenepanela.GetComponent<CanvasGroup>();
	yield return new WaitForSeconds(1f);
    scenepanel.blocksRaycasts = false;

                  Debug.Log("SceneChangerスタートの処理");

　　　}
}
