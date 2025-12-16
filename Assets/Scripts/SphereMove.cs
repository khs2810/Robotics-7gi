using UnityEngine;

public class SphereMove : MonoBehaviour
{
    public Transform pos3;
    public Transform pos4;
    public float speed = 0.01f;
    Vector3 originPos;
    float distanceToPos3, distanceToPos4;
    private Vector3 norDir;
    private Vector3 norDir3;
    private Vector3 norDir4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originPos = transform.position;

        Vector3 dirPos3 = pos3.position - transform.position;
        Vector3 norDirPos3 = dirPos3.normalized;    // 크기가 1인 벡터
        norDir = norDir3 = norDirPos3;

        Vector3 dirPos4 = pos4.position - pos3.position;
        Vector3 norDirPos4 = dirPos4.normalized;    // 크기가 1인 벡터
        norDir4 = norDirPos4;
    }

    // pos3까지 이동 후, pos4까지 이동 후, 원위치
    // Update is called once per frame
    void Update()
    {
        // pos3까지 이동 후
        Vector3 dirPos3 = pos3.position - transform.position;
        distanceToPos3 = dirPos3.magnitude;

        Vector3 dirPos4 = pos4.position - transform.position;
        distanceToPos4 = dirPos4.magnitude;

        // 만약 가까워 졌다면
        if (distanceToPos3 < 0.1f)
        {
            norDir = norDir4;
        }
        else if(distanceToPos4 < 0.1f)
        {
            transform.position = originPos; // 처음 위치로 이동
         
            norDir = norDir3;
        }

        transform.position = transform.position + (norDir * speed);
    }
}
