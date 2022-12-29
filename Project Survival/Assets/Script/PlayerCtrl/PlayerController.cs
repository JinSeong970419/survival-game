using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("인풋 시스템")]
    [SerializeField] private InputReader _inputReader;

    private Vector3 _InputVector;
    private Vector3 _moveVector;

    private Rigidbody _Rigid;
    private Transform _CarmeraObject;

    [Header("플레이어 값")]
    public float player_speed = 6.0f;         // 캐릭터 걷는 속도
    public float player_run_speed = 9.0f;     // 캐릭터 달리는 속도
    public float player_jump_power = 10.0f;    // 캐릭터 점프력
    public float rotationspeed = 10f;    // 캐릭터 점프력

    private bool isRunable;

    private void OnEnable()
    {
        _inputReader._Movement += OnMove;
    }

    private void Awake()
    {
        _Rigid = GetComponent<Rigidbody>();
        _CarmeraObject = Camera.main.transform;

        // 카메라 잠금
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        _moveVector = transform.forward * _InputVector.y + transform.right * _InputVector.x;
        _moveVector.Normalize();
        _Rigid.velocity = _moveVector * (isRunable ? player_run_speed : player_speed);

        Quaternion targetrotation = Quaternion.Euler(0, _CarmeraObject.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetrotation, rotationspeed * Time.deltaTime);
    }

    #region Input 이벤트
    private void OnMove(Vector2 movement) 
    {
        _InputVector = movement;
    }

    #endregion
}
