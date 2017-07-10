using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectPool : MonoBehaviour {
    //풀링
    public GameObject prefab; //풀링할 프리팹

    private Stack<GameObject> inactiveInstances = new Stack<GameObject>(); //가장 최근에 쓴것을 먼저 쓰려고.-
    
    public GameObject GetObject()
    {
        GameObject spawnedGameObject; //새로 만들어서 돌려줄 오브젝트 
        if(inactiveInstances.Count > 0) //0보다 크면 있다는 얘기
        {
            spawnedGameObject = inactiveInstances.Pop(); //그 오브젝트를 넣어줌.
        }
        else//만약 없으면 생성함.
        {
            spawnedGameObject = (GameObject)GameObject.Instantiate(prefab); 
            PooledObject pooledObject = spawnedGameObject.AddComponent<PooledObject>(); //어떤 풀 오브젝트를 쓰는지
            pooledObject.pool = this; //범용성 있게 만듬.
        }
        spawnedGameObject.transform.SetParent(null); //만든 오브젝트 위치 초기화.(Shop 스크립트에서 알아서 하고 있음)만들기전에 초기화 
        //월드기준으로 감. ↑
        spawnedGameObject.SetActive(true); //실제로 액티브

        return spawnedGameObject; //최종 값 리턴.
    }

public void ReturnObject(GameObject toReturn) //풀링한 오브젝트를 쓰고나서 다시 돌려줌.
    {
        PooledObject pooledObject = toReturn.GetComponent<PooledObject>();
        if(pooledObject !=null && pooledObject.pool == this)
        {
            toReturn.transform.SetParent(transform);
            toReturn.SetActive(false);
            inactiveInstances.Push(toReturn);
        }
        else
        {
            print("You are not my Son!!!");
            Destroy(toReturn);
        }
    }
}

public class PooledObject : MonoBehaviour
{
    public SimpleObjectPool pool;
}
