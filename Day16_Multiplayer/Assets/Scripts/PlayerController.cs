using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
                                //네트웍 메니저컴포넌트 는 하나만 생성되야함.
public class PlayerController : NetworkBehaviour {
    public GameObject bulletPrefab;
    public Transform bulletSpawn;//총알생성 지점.

	// Update is called once per frame
	void Update () {
        if(!isLocalPlayer) //로컬이 아니면 종료.(없으면 전부 연결되서 행동함)
        {
            return;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3f;
        if( Input.GetKeyDown (KeyCode.Space ))
        {
            CmdFire();
        }

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
	}

    [Command] //클라이언트에서 호출은 되지만 서버에서 실행됨.
    void CmdFire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
        //호출된 메소드를 서버가 실행하면서 총알의 정보를 받아서 ↑
        NetworkServer.Spawn(bullet); //서버가 로컬로 뿌림.
        Destroy(bullet, 10f);
    }
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
        gameObject.AddComponent<Camera>();
    }
}
