using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public Transform tilePrefab; //타일 프리팹
    public Transform obstaclePrefab; //장애물 프리팹
    public Vector2 mapSize; //맵의 크기 x,z축으로 지정.

    [Range(0, 1)] //스크롤바 생성
    public float outlinePersent; //스케일값을 퍼센트로움직임(스크롤바 이용)

    List<Coord> allTileCoords; //리트스하나 만듦
    Queue<Coord> shuffledTileCoords; //First in First Out

    [Range(0,100000)]
    public int seed; //seed값마다 섞인 리스트가 다름. 
    public int obstacleCount;
    //예를들어 seed 1은 1 3 4 5 6 7 으로 섞여있고 seed 2는 2 3 5 7 6 1 로 섞여있다면 seed값만 기억해두면 항상 섞여있는 상태가 같음.

	// Use this for initialization
	void Start () {
        GenerateMap();	 //맵 생성 메소드를 시작하면 바로 불러옴.
	}
    Vector3 CoordToPosition(int x, int y) //생성된 맵의 중앙이 월드의 0,0,0을 기준과 같게 하기위한 위치를 담는 메소드.
    {//임의로 지정된 맵 사이즈의 x의 절반,y의 절반을 알면 그 맵의 중앙위치를 알 수 있음. 0.5f는 보정값.
       
        return new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + 0.5f + y);
    }
	public void GenerateMap() //맵 생성 메소드
    {
        allTileCoords = new List<Coord>(); //새로 리스트를 만듦
        for(int x = 0; x< mapSize.x; x++)
        {
            for(int y = 0; y<mapSize.y; y++)
            {
                allTileCoords.Add(new Coord(x, y)); //각 타일마다 x,y의 좌표값을 넣어줌.(인덱스)
            }
        }
        shuffledTileCoords = new Queue<Coord>(Utility.ShuffleArray(allTileCoords.ToArray(), seed));//ToArry() = 리스트allTileCoords를 배열로 변환.
        //유틸리티 클래스의 메소드 실행. 리스트를 배열로 변환하고 시드와 같이 넘겨서  리턴받음.
        string holderName = "Generated Map"; // 이 오브젝트 밑으로 맵생성. 스트링으로 Generated Map을 저장.

        if (transform.FindChild(holderName)) //맵의 자식중에 Generated Map을 찾아 있다면.
        {
            DestroyImmediate(transform.FindChild(holderName).gameObject);//즉시 삭제 시킴.
        }

        Transform mapHolder = new GameObject(holderName).transform; //맵 고정위치는 Generated Map의 포지션
        mapHolder.parent = transform; //Generated Map의 부모는  스크립트가 바인딩된 오브젝트.


        for (int x = 0; x < mapSize.x; x++) //x의 사이즈만큼 for문을 돎
        {
            for(int y= 0; y<mapSize.y; y++) //x의 사이즈 만큼 제일 낮은 수부터 y의 사이즈만큼 for문을 돌고 마지막까지 각각 y문이 실행. x가 2고 y가 3이라면
                //(0,0)(0,1)(0,2) ,(1,0),(1,1)(1,2)
            {
                //Vector3 tilePosition = new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + 0.5f + y);
                Vector3 tilePosition = CoordToPosition(x, y);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right*90));
                //타일프리팹을 생성,지정위치에,쿼터니언으로 x축90도회전(월드기준)
             // newTile.transform.localScale = new Vector3(tileSize.x, tileSize.y, tileSize.z);
                newTile.localScale = Vector3.one * (1 - outlinePersent);
                newTile.parent = mapHolder; //타일의 부모를 맵홀더(Generated Map)로 바꿈
                //Transform newTile2 = Instantiate(tilePrefab, tilePosition, tilePrefab.transform.rotation); 
            }
        }
        //장애물 개수
        for(int i=0; i<obstacleCount; i++) //장애물 개수만큼 for문을 돎
        {
            Coord randomCoord = GetRandomCoord(); //GetRandomCoord메소드를 실행해서 나온 값을 저장.
            Vector3 obstaclePosition = CoordToPosition(randomCoord.x, randomCoord.y);//장애물 위치를 정해진 시드에 맞게 랜덤하게 배치하게함.
            Transform newObstacle = Instantiate(obstaclePrefab, obstaclePosition + Vector3.up * 0.5f, Quaternion.identity);//실제 랜덤하게 배치된 위치에 각 장애물프리팹을 생성.
            newObstacle.parent = mapHolder; //장애물의 부모를 Generated Map으로 함.
        }
        
    }
    public Coord GetRandomCoord()
    {
        Coord randomCoord = shuffledTileCoords.Dequeue(); //큐에 처음것을 빼서 randomCoord에 저장.
        shuffledTileCoords.Enqueue(randomCoord); //뺀놈을 다시 마지막에 넣어둠.
        return randomCoord; //처음에 뺀놈을 리턴.
    }
    public struct Coord //구조체 
    { 
        public int x;
        public int y;

        public Coord(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }
}
