using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SampleButton : MonoBehaviour {
    //UI관련
    public Button buttonComponet;
    public Text nameLabel;
    public Image iconImage;
    public Text priceText;
    //데이터 관련

    private Item item;
    private ShopScrollList scrollList;

	// Use this for initialization
	void Start () {
        //현재 버튼의 온클릭에 대해 리스너를 추가. 클릭이있으면 해당 메소드를 호출.
        buttonComponet.onClick.AddListener(HandleClick);
	}
	
	public void Setup(Item currentItem, ShopScrollList Shop)//아이템 받음,소속어딘지.
    {
        item = currentItem; 
        nameLabel.text = item.ItemName;
        iconImage.sprite = item.icon;
        priceText.text = item.price.ToString();
        scrollList = Shop;
    }

    public void HandleClick()
    {
        print("Onclick");
        scrollList.TryTransferItemToOtherShop(item);
    }
}
