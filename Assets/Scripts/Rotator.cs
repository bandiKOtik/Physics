using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Transform objectTransform;

    private void Awake()
    {
        objectTransform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        objectTransform.Rotate(new Vector3(0, 0, 1));
    }
}
