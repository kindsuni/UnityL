using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_FadeIn : MonoBehaviour
{
	// 코루틴 적용 확인
	public Image enterKey;
	public GameObject isTitle;

	private void OnEnable()
	{
		Invoke("Active", 3.0f);
	}

	// Update is called once per frame
	void Update()
	{
		if (isTitle.activeSelf)
		{
			enterKey.color = new Color(255, 255, 255, -0.3f);
		}
	}

	void Active()
	{
		enterKey.color = new Color(255, 255, 255, 1.0f);
	}
}