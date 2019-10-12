using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartController : MonoBehaviour
{
    private Vector3 velocity;                               // 移動方向
    [SerializeField] private float moveSpeed = 7.5f;        // 移動速度
    float initialMoveSpeed;
    [SerializeField] private GameObject Dartboard;          // ボード
    LineRenderer line ;
    float lineWidth ;


    private void Start()
    {
        line = GetComponent<LineRenderer>();
        lineWidth = 2f;
        initialMoveSpeed = moveSpeed;
    }

    void Update()
    {
        velocity = Vector3.zero; //初期化
        moveSpeed = initialMoveSpeed;

        if (Input.GetKey(KeyCode.W))
        {
            velocity.y += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity.z -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity.y -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity.z += 1;
        }
        if (Input.GetKey("left shift"))
        {
            moveSpeed = 4 * moveSpeed;
        }

        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        // WASDが入力されて移動が発生
        if (velocity.sqrMagnitude > 0)
        {
            transform.position += velocity;
        }

        line.SetPosition(0, transform.position); //Dartの先端が始点（１点目）
        line.SetPosition(1, new Vector3(Dartboard.transform.position.x , transform.position.y , transform.position.z)); //ボードにぶつかるとこが終点（２点目）

        line.startWidth = lineWidth;
        line.endWidth = lineWidth;

        //line.SetColors(Color.gray, Color.magenta);
    }
}
