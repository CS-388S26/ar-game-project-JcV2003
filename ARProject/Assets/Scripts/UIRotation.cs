using UnityEngine;

public class BillboardY : MonoBehaviour
{

    [SerializeField] Camera cam;
    void LateUpdate()
    {
        cam = GameObject.Find("ARCamera").GetComponent<Camera>();

        Vector3 direction = cam.transform.position - transform.position;
        direction.y = 0;

        transform.rotation = Quaternion.LookRotation(direction);
        transform.Rotate(0, 180, 0);
    }
}