using UnityEngine;
using System;
using System.Diagnostics.Tracing;
using System.Collections;
public class Puzzle : MonoBehaviour 
{
    [SerializeField]
    private MeshRenderer hovering;
    private GameObject Hover;
    Color NonHove;
    public ParticleSystem particle;

    public string targetLayerName = "TargetLayer"; // 검사할 Layer 이름
    public Material Diagram;
    private bool finish=false;
    [SerializeField]
    private float requiredTime = 1f; // 충돌 유지 시간 (초)

    private bool isColliding = false; // 충돌 상태 확인 변수
    private Coroutine collisionCoroutine = null;
    private void Start()
    {
       hovering.enabled = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        hovering.enabled = true;
        //Debug.Log("충돌");
    }
    private void OnTriggerEnter(Collider other)
    {
        Hover = other.gameObject;
        //Debug.Log("트릭");
        if (finish)
            return;
        if (!other.tag.Equals("Puzzle"))
        {
            return;
        }
        hovering.enabled = true;
        // 충돌한 오브젝트의 Layer가 지정된 Layer인지 확인
        if (other.gameObject.layer == LayerMask.NameToLayer(targetLayerName))
        {
            hovering.material.color = Color.blue;
            if (!isColliding)
            {
                isColliding = true;
                collisionCoroutine = StartCoroutine(CollisionCheckCoroutine());
            }
        }
        else
        {
            hovering.material.color = Color.red;

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (finish)
            return;
        else
        {
            Hover = null;
        if (other.gameObject.layer == LayerMask.NameToLayer(targetLayerName))
        {
            if (isColliding)
            {
                isColliding = false;

                // Coroutine 중단
                if (collisionCoroutine != null)
                {
                    StopCoroutine(collisionCoroutine);
                    collisionCoroutine = null;
                }
            }
        }
        hovering.enabled = false;
        }
    }
    private IEnumerator CollisionCheckCoroutine()
    {
        Debug.Log("충돌 유지 상태 시작");
        yield return new WaitForSeconds(requiredTime);

        // 충돌 상태가 유지되었으면 성공 처리
        if (isColliding)
        {
            HandleSuccess();
        }
    }

    private void HandleSuccess()
    {
        finish = true;
        Hover.gameObject.SetActive(false);
        particle.Play();
        hovering.material = Diagram;
        //"성공 동작 수행"
    }

}

