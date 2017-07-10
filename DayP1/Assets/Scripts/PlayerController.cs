using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {
    public float RotationSpeed = 150.0f;
    public float MoveSpeed = 3.0f;
    GameObject bullet;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 6.0f;
    public float bulletDthtime = 2.0f;
	// Update is called once per frame
	void Update () {
        if(!isLocalPlayer)
        {
            return;
        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * RotationSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * MoveSpeed;
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
       
        if (Input.GetKey(KeyCode.Space))
        {
            Fire();
        }
	}
   void Fire()
    {
        bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

     
            Destroy(bullet, bulletDthtime);
        
    }
    
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
