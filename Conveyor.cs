using UnityEngine;

/// <summary>
/// PLC의 Y00(정방향회전), Y01(역방향회전) 신호를 받아, Dragger를 특정 위치로 특정 속도로 이동시킨다.
/// 속성: Dragger들, 속도
/// </summary>
public class Conveyor : MonoBehaviour
{
    [SerializeField] Dragger dragger1;
    [SerializeField] float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dragger1.Move(true, speed);
    }
}
