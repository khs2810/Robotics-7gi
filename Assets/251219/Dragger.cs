using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Conveyor 객체의 명령을 받아 특정 목적지 까지 특정 속도로 이동한다.
/// 속성: transform, 정방향목적지, 역방향목적지
/// </summary>
public class Dragger : MonoBehaviour
{
    [SerializeField] Transform cwDestination;
    [SerializeField] Transform ccwDestination;
    [SerializeField] Vector3 direction;

    private void Start()
    {
        direction = cwDestination.position;
    }
    public void Move(bool isCW, float speed)
    {
        float distance = direction.magnitude;
            
        if (isCW)
        {
            direction = cwDestination.localPosition - transform.localPosition;
            
            if(distance < 0.1f)
                transform.localPosition = ccwDestination.localPosition;
        }
        else
        {
            direction = ccwDestination.position - transform.position;
            
            if (distance < 0.1f)
                transform.position = cwDestination.position;
        }

        transform.localPosition += direction.normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "금속" || other.tag == "플라스틱")
        {
            other.transform.SetParent(this.transform);  //  부딫힌 물체를 자식으로 설정
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "금속" || other.tag == "플라스틱")
        {
            other.transform.SetParent(null);    //  부딫힌 물체를 자식으로부터 해방
        }
    }
}
