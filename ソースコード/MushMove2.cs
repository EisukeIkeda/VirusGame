using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MushMove2 : MonoBehaviour
{

    public float time;
    public AudioSource sound1;
    public int touch;
    // Update is called once per frame
    void Update()
    {
       time -= Time.deltaTime;

        if(time <= 0){
            Mush1();
            
        }
        
    }

    void Start()
    {
      sound1.Play();
    }

    public void Mush1()
    {
        Transform tran = this.gameObject.GetComponent<Transform>();
        tran.DOScale (
    　　　new Vector2(-10f,10f),　　//終了時点のScale
    　　　1.0f )        
         .SetLink( gameObject );　　　　　//時間
         
    }


    public void Mush1Touch()
    {
        if(touch == 0){
            touch = 1;
            time = 10f;
        Transform tran = this.gameObject.GetComponent<Transform>();
        tran.DOScale (
    　　　new Vector2(-5f,5f),　　//終了時点のScale
    　　　2.0f )        
         .SetLink( gameObject );　　　　　//時間
         tran.DOLocalMove(new Vector2(140f, -170f), 2f)
         .SetRelative();
         StartCoroutine("Coroutine");}
    }
    IEnumerator Coroutine () {
        for(int i=0;i<1;++i)
	　　　{
		   yield return cocoSub();
	　　　}
    yield return new WaitForSeconds(2f);
          touch = 0;}

      IEnumerator cocoSub(){
          Transform tran = this.gameObject.GetComponent<Transform>();
        yield return new WaitForSeconds(10.0f);
        tran.DOLocalMove(new Vector2(-140f, 170f), 2f)
         .SetRelative();
         sound1.Play();
      }
          
}

