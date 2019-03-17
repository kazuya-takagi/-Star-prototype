using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCurrentScript : MonoBehaviour
{
    [SerializeField]
    private float m_moveSpeed = 5.0f;

    void OnTriggerStay(Collider other) {
        var body = other.gameObject.GetComponent<Rigidbody>();

        if (body != null)
        {
            Vector3 add = transform.right * m_moveSpeed * Time.deltaTime;

            body.MovePosition(other.transform.position + add);
        }
    }
}
