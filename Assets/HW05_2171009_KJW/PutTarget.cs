using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutTarget : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Heart"))
        {
            Destroy(other.gameObject);  // heart ����
            GameManager.Instance.putCount++;  // count ó��
            Debug.Log("heart put �Ϸ�");
        }
    }
}
