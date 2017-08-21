using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour {
    public GameObject flashHolder;
    public Sprite[] flashSprites;
    public SpriteRenderer[] spriteRenderers;

    public float flashTime;

	// Use this for initialization
	void Start () {
        Deactivate(); //시작시 끔.
	}
	public void Activate()
    {
        flashHolder.SetActive(true);

        int flashSpriteindex = Random.Range(0, flashSprites.Length); //스프라이트 랜덤하게 뽑음.
        for(int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].sprite = flashSprites[flashSpriteindex];
        }
        Invoke("Deactivate", flashTime);
    }
    public void Deactivate()
    {
        flashHolder.SetActive(false);
    }
	
}
