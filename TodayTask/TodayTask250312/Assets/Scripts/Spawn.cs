using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // 몬스터 스폰 위치 (최소/최대)
    public float minX = -2f;
    public float maxX = 2f;
    // 몬스터 스폰 시간 (시작/중지)
    public float start = 1f;
    public float stop = 10f;
    // 몬스터 생성 여부
    bool swi = true;
    bool swi2 = true;

    public GameObject monster;
    public GameObject monster2;

    void Start()
    {
        // 코루틴 시작
        StartCoroutine(RandomSpawn());
        // 10초 뒤 몬스터 스폰 중지
        Invoke("Stop", stop);
    }

    // 코루틴
    IEnumerator RandomSpawn()
    {
        while (swi)
        {
            // 1초 마다
            yield return new WaitForSeconds(start);
            // 랜덤 x값
            float x = Random.Range(minX, maxX);

            Vector2 r = new Vector2(x, transform.position.y);

            // 몬스터 생성
            Instantiate(monster, r, Quaternion.identity);
        }
    }

    IEnumerator RandomSpawn2()
    {
        while (swi2)
        {
            // 1초 마다
            yield return new WaitForSeconds(start + 2);
            // 랜덤 x값
            float x = Random.Range(minX, maxX);

            Vector2 r = new Vector2(x, transform.position.y);

            // 몬스터 생성
            Instantiate(monster2, r, Quaternion.identity);
        }
    }

    void Stop()
    {
        swi = false;
        StopCoroutine(RandomSpawn());

        // 두번째 코루틴
        StartCoroutine(RandomSpawn2());

        // 30초 뒤 몬스터2 스폰 중지
        Invoke("Stop2", stop + 20);
    }

    void Stop2()
    {
        swi2 = false;
        StopCoroutine(RandomSpawn2());

        // 보스
    }

    void Update()
    {

    }
}
