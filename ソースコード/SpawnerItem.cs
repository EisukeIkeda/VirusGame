using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerItem : MonoBehaviour
{
    public GameObject prefab;
   private Vector3 clickPosition;
   public Transform parentTran;
   private float time;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
      time -= Time.deltaTime;
    }
	



    public void SpawnerSpawn(){
        if(time <= 0.0f & PlayerPrefs.GetInt("TotalVirus") <= 200){
            time = 0.01f;
			// ここでの注意点は座標の引数にVector2を渡すのではなく、Vector3を渡すことである。
			// Vector3でマウスがクリックした位置座標を取得する
			
			// オブジェクト生成 : オブジェクト(GameObject), 位置(Vector3), 角度(Quaternion)
			// ScreenToWorldPoint(位置(Vector3))：スクリーン座標をワールド座標に変換する
            
            clickPosition = Input.mousePosition;
			// Z軸修正
			clickPosition.z = 10f;

           
            GameObject obj = Instantiate(prefab, Camera.main.ScreenToWorldPoint(clickPosition), prefab.transform.rotation);
            obj.transform.SetParent(parentTran);
            PlayerPrefs.SetInt("TotalVirus", PlayerPrefs.GetInt("TotalVirus") + 1);}
            
            }

            
           
            
	

    
	
            }
    
