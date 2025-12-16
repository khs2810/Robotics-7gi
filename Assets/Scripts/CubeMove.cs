using UnityEngine;

// MonoBehaviour class: 씬에 있는 게임오브젝트(GO)를 움직일 수 있도록
// 활성화시켜주는 부모 클래스
// -> GO에 붙어있는 <컴포넌트>들에 접근가능
// -> <Life Cycle 함수>를 이용하여 GO를 이동, 회전, 크기조절 등이 가능하게 함

/// <summary>
/// pos1 까지 1초 동안 이동 후, pos2 까지 1초 동안 이동
/// 다시 원래 위치로 이동해서 위 과정을 반복
/// 속성: pos1, pos2의 정보, 처음위치, 이동시간
/// </summary>
public class CubeMove : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public Vector3 originPos;
    public float duration = 1;
    public float speed = 0.01f;
    Vector3 direction = Vector3.forward;
    public float distanceToPos1;
    public float distanceToPos2;

    // 런타임 시 한번만 실행
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originPos = transform.position;
    }

    // 프레임 당 한번씩 무한히 반복
    // Update is called once per frame
    void Update()
    {
        // pos1 까지 1초 동안 이동 후,

        // pos1까지 벡터의 크기(거리)
        distanceToPos1 = (pos1.position - transform.position).magnitude;
        distanceToPos2 = (pos2.position - transform.position).magnitude;

        Vector3 vectorToPos = pos1.position - transform.position; // pos1까지의 벡터(크기와 방향)
        Vector3 normalizedToPos = Vector3.Normalize(vectorToPos); // pos1까지 크기가 1인 벡터

        // 물체까지 가까워지면 방향 전환
        if (distanceToPos1 < 0.01f)
        {
            direction = Vector3.right;
        }
        else if(distanceToPos2 < 0.01f)
        {
            // 다시 원래 위치로 이동해서 위 과정을 반복
            transform.position = originPos;

            direction = Vector3.forward;
        }

        // pos1, pos2 까지 1초 동안 이동
        transform.position = transform.position + (direction * speed);
    }
}
