using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{
    void OnMouseDown()
    {
        gameObject.SetActive(false); // heart �����
        GameManager.Instance.PickItem(); // Pick Count ����
    }
}
