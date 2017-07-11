using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateWay : MonoBehaviour {

	public UiControl uicontorl;
    public GameObject[] ways;
    public int way;

	private string mapName;

	private void Awake()
    {
        mapName = GameObject.FindGameObjectWithTag("Map").name;
		uicontorl = GameObject.Find("UIController").GetComponent<UiControl>();
    }

    // Use this for initialization
    void Start () {
        GameControl.instance.canvas.SetActive(true);

        switch (mapName)
        {
            case "Map01":
                GameControl.limitTime = 75;

				uicontorl.limitTime.color = Color.white;

				way = UnityEngine.Random.Range(0, 2); // 0, 1
                switch (way)
                {
                    case 0:
                        Instantiate(ways[0], this.transform.position, Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(ways[1], this.transform.position, Quaternion.identity);
                        break;

                    default:
                        Instantiate(ways[0], this.transform.position, Quaternion.identity);
                        break;
                }
                
                break;
            case "Map02":
                GameControl.limitTime = 90;

				uicontorl.limitTime.color = Color.white;

				way = UnityEngine.Random.Range(0, 3); // 0, 1, 2
                switch (way)
                {
                    case 0:
                        Instantiate(ways[0], this.transform.position, Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(ways[1], this.transform.position, Quaternion.identity);
                        break;
                    default:
                        Instantiate(ways[2], this.transform.position, Quaternion.identity);
                        break;
                }
                break;
             case "Map03":
                GameControl.limitTime = 160;

				uicontorl.limitTime.color = Color.white;

				way = UnityEngine.Random.Range(0, 2); // 0, 1, 2
                switch (way)
                {
                    case 0:
                        Instantiate(ways[0], this.transform.position, Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(ways[1], this.transform.position, Quaternion.identity);
                        break;
                    default:
                        Instantiate(ways[2], this.transform.position, Quaternion.identity);
                        break;
                }
                break;
            default:
                break;
        }
    }
}

