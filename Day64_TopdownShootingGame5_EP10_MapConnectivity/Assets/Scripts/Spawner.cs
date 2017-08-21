using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public Wave[] waves;
	public Enemy enemy;
    
    LivingEntity playerEntity;
    Transform playerT;

	Wave currentWave;
	int currentWaveNumber;

	int enemiesRemainingToSpawn;
	int enemiesRemainingAlive;
	float nextSpawnTime;

    MapGenerator map;

    float timeBetweenCampingChecks = 2; //캐릭터가 멈춰있는 시간이 2초가 되었는지.
    float campThresholdDistance = 1.5f; //2초안에 1.5거리만큼 이동하지 않으면 캠핑이라 판단함.
    float nextCampCheckTime;
    Vector3 campPositionOld;
    bool isCamping;
    bool isDisabled;

	void Start() {
        playerEntity = FindObjectOfType<Player>();
        playerT = playerEntity.transform;
        nextCampCheckTime = timeBetweenCampingChecks + Time.time;
        campPositionOld = playerT.position;
        playerEntity.OnDeath += OnPlayerDeath;
        map = FindObjectOfType<MapGenerator>();//글로벌하게 찾음. (한번만 호출) 비용이 비쌈.
		NextWave ();

	}

	void Update() {
        if (!isDisabled)
        {

            if (Time.time>nextCampCheckTime)
        {
            nextCampCheckTime = Time.time + timeBetweenCampingChecks;
            isCamping = (Vector3.Distance(playerT.position, campPositionOld) < campThresholdDistance); //플레이어 위치랑 이전위치의 거리가 정한거리보다 작으면
            campPositionOld = playerT.position;
        }
		if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime) {
			enemiesRemainingToSpawn--;
			nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;
            StartCoroutine(SpawnEnemy());
        }
	}
        }
    IEnumerator SpawnEnemy()
    {
        float spawnDelay = 1;
        float tileFlashSpeed = 4;

        Transform spawnTile = map.GetRandomOpenTile();

        if(isCamping)
        {
            spawnTile = map.GetTileFromPosition(playerT.position);
                
        }
        Material tilemat = spawnTile.GetComponent<Renderer>().material;
        Color initialColol = tilemat.color;
        Color flashColor = Color.red;

        float spawnTimer = 0;
        while(spawnTimer < spawnDelay)
        {
            tilemat.color = Color.Lerp(initialColol, flashColor, Mathf.PingPong(spawnTimer * tileFlashSpeed,1));
            spawnTimer += Time.deltaTime;
            yield return null;
        }

        Enemy spawnedEnemy = Instantiate(enemy, spawnTile.position, Quaternion.identity) as Enemy;
        spawnedEnemy.OnDeath += OnEnemyDeath;
        

    }
    void OnPlayerDeath()
    {
        isDisabled = true;
    }
    //void OnEnemy()
    //{
    //    print("OnEnemy()");
    //}

    void OnEnemyDeath() {
		enemiesRemainingAlive --;

		if (enemiesRemainingAlive == 0) {
			NextWave();
		}
	}
    void NextWave() {
		currentWaveNumber ++;
		print ("Wave: " + currentWaveNumber);
		if (currentWaveNumber - 1 < waves.Length) {
			currentWave = waves [currentWaveNumber - 1];

			enemiesRemainingToSpawn = currentWave.enemyCount;
			enemiesRemainingAlive = enemiesRemainingToSpawn;
		}
	}

    [System.Serializable]
    public class Wave {
		public int enemyCount;
		public float timeBetweenSpawns;
	}

}