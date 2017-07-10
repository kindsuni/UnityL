using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable] //구조체 데이터를 어레이 데이터로 만들어서 전송 할 수 있게 데이터를 시리얼 라이즈 하게 함.ㄴ
public class Item
{
    public string ItemName;
    public Sprite icon;
    public float price = 1;
    
}

public class ShopScrollList : MonoBehaviour {
    public List<Item> itemList; //아이템 리스트.
    public Transform contentPannel;
    public ShopScrollList otherShop;
    public Text myGoldDIsplay;


    //풀링
    public SimpleObjectPool buttonObjectPool; //

    public float gold = 20f;

  //직접생성  public GameObject ButtonPrefab;

	// Use this for initialization
	void Start () {
        RefreshDisplay();

    }
	public void RefreshDisplay()
    {
        myGoldDIsplay.text = "Gold: " + gold.ToString();
        RemoveButtons();
        AddButton();
    }
    //아이템을 직접 생성.
    private void AddButton()
    { //아이템 받아서 버튼 생성
        for (int i = 0; i<itemList.Count; i++)
        {
            Item item = itemList[i];
            //풀링
            GameObject newButton = buttonObjectPool.GetObject();
            //직접 생성함.
            //GameObject newButton = (GameObject)GameObject.Instantiate(ButtonPrefab); 
            newButton.transform.SetParent(contentPannel, false); //생성된 버튼의 위치를 부모의 기준으로 크기를 맞춤.
           // newButton.transform.SetParent(contentPannel);//버튼의 부모를 ContentPannel로 바꿈
            newButton.transform.localScale = Vector3.one;//스케일 값을 일반화 시켜줌. (부모 관점으로 크기를 고정)

            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
            sampleButton.Setup(item, this);
        }
    }
   private void RemoveButtons()
    {//중요
        while (contentPannel.childCount> 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }
    void AddItem(Item itemToAdd, ShopScrollList shop) //샵에 아이템 추가.
    {
        shop.itemList.Add(itemToAdd);
    }

    private void RemoveItem(Item itemToRemove, ShopScrollList shop) //샵 아이템 삭제.
    {
        for (int i = shop.itemList.Count - 1; i >= 0; i--)
        {
            if(shop.itemList[i] == itemToRemove)
            {
                shop.itemList.RemoveAt(i);
            }
        }
    }
    public void TryTransferItemToOtherShop(Item item) //클릭한 해당 아이템이 들어오면.
    {
        if(otherShop.gold >= item.price) //샵의 골드가 아이템 가격보다 크면
        {
            gold += item.price; //골드에 아이템 가격을 더하고
            otherShop.gold -= item.price; //샵의 골드가 아이템 가격만큼 빠짐.

            AddItem(item, otherShop); //다른쪽에 해당아이템 추가하고
            RemoveItem(item, this); //현재 샵은 제거.

            RefreshDisplay(); //현재샵 다시 그리기
            otherShop.RefreshDisplay(); //다른샵 다시 그리기
            print("Enotgh Gold"); //디버그
        }
        else
        { //부족하면 
            print("Not enough Gold");
        }
        print("attempted");
    }
}
