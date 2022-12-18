using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BirdMove2 : MonoBehaviour
{
 public AudioClip sound1;
 public AudioClip sound2;
 public GameObject Bird;

    void Start()
    {
        AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();

        audioSource.PlayOneShot(sound2);
        audioSource.PlayOneShot(sound1);

		Transform tran = this.gameObject.GetComponent<Transform>();
        tran.DOLocalMove(new Vector2(-5000f, 0f), 2f)
        .SetLink( gameObject , LinkBehaviour.KillOnDisable)
         .SetRelative();
         StartCoroutine("Coroutine");}
    

    IEnumerator Coroutine () {
        for(int i=0;i<1;++i)
	　　　{
		   yield return cocoSub();
	　　　}
      yield return new WaitForSeconds(2f);
          Transform tran = this.gameObject.GetComponent<Transform>();
          Bird.SetActive(false);
          }	　　
          　
          IEnumerator cocoSub(){
          Transform tran = this.gameObject.GetComponent<Transform>();
        yield return new WaitForSeconds(0.5f);
        tran.DOLocalMove(new Vector2(0f, 2000f), 2f)
        .SetLink( gameObject , LinkBehaviour.KillOnDisable)
         .SetRelative();}
    
}
