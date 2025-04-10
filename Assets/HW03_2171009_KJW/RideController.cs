using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideController : MonoBehaviour
{


    //public Animator Animator;
    public VehicleAnimatorController vehicle;
    public GameObject player;

    // ridestat=1 -> room1->room2 ���� ��
    // ridestat=2 -> room2->room1 ���� ��
    // ridestat=3 -> room2���� ��������
    // ridestat=4 -> room1���� ��������
    // ridestat=5 -> room2�� ���� ����
    // ridestat=6 -> room1���� ���� ����
    // �߰��� ������ ridestat=5 or 6���� ����

    private bool isRiding = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Vehicle" && !isRiding)
        {
            print("ride");
            isRiding = true;

            transform.SetParent(other.transform);
            transform.position = other.transform.position + Vector3.up * 2f;

            int state = vehicle.animator.GetInteger("ridestat");
            // ���� ������ ��� �ݴ� �������� ���
            if (state == 3) // Room2�� ������ �� Room1��
            {
                vehicle.PlayToRoom1();
            }
            else if (state == 4) // Room1�� ������ �� Room2��
            {
                vehicle.PlayToRoom2();
            }

            // �̵� �� ���� ���¿����� �� �ٽ� �̾
            else if (state == 5 || state == 6)
            {
                vehicle.Resume();
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Vehicle" && isRiding)
        {
            isRiding = false;
            transform.SetParent(null);

            vehicle.Pause(); // �ִϸ��̼� ���� + ���� ����
        }
    }

}
