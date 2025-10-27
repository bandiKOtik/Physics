using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private GameObject _mainTarget;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _translateSpeed = 10f;
    private Transform _objectTransform;

    private void Awake()
    {
        _objectTransform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        Vector3 targetTranslatePoint = _mainTarget.transform.position + _offset - _objectTransform.position;
        _objectTransform.Translate(targetTranslatePoint * Time.deltaTime * _translateSpeed);
        _objectTransform.LookAt(_mainTarget.transform.position);
    }
}
