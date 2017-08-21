using UnityEngine;
using System.Collections;

public class BlockManager : MonoBehaviour {

	public Texture[] cracks; //크렉 이미지 배열.
	int numHits = 0; //처음 상태
	float lastHitTime; //마지막 클릭 타임
	float hitTimeThreshold = 0.5f; 

	public void RegisterHit()
	{
		//if short enough time between hits then register as another hit
		if((lastHitTime + hitTimeThreshold) > Time.time)  
		{
			numHits++; //배열에 저장된 이미지의 변환
			CancelInvoke(); //모든 인보크를 캔슬
			if(numHits < cracks.Length) //크랙이미지 배열의 크기보다 현재 이미지상태의 숫자가 작으면.
				this.GetComponent<Renderer>().material.SetTexture("_DetailMask", cracks[numHits]); //그 오브젝트의 렌더러의 DetailMask에 해당 이미지를 씌움.
            //DetailMask는 첫번째 이미지에 두번째 이미지가 알파값으로 씌어진다. 기본배경에 덮어준다는 개념.
            //원래 이미지가 돌이면 두번째 이미지를 알파값이 들어간 크랙이미지이면 돌 위에 크랙이미지가 덮어지면서 돌이 부서지는것 처럼 보임.
			else
				Destroy(this.gameObject); //배열의 크기보다 크게 되면 그 오브젝트를 삭제 (실제로 부서져서 사라지는것 처럼 보이게.)

			Invoke("Heal",2f); // 클릭이 멈추면 2초뒤에 Heal 메소드 실행.
		}

		lastHitTime = Time.time;
	}

	void Heal()
	{
		numHits = 0; //현재 배열을0으로 초기화.
		this.GetComponent<Renderer>().material.SetTexture("_DetailMask", cracks[0]); //이미지가 원래대로 바뀌면서 크랙이 나지않았던 상태로 다시 변화.
	}
}
