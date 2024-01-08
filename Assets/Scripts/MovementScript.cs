using UnityEngine;

public class MovementScript : MonoBehaviour
{

    [SerializeField] private float _speed;   

    [SerializeField] private float _sinLength;
    [SerializeField] private float _cosLength;

    private float _angle = 0;

    private void Start()
    {
        _speed = Random.Range(1, 6);

        RandomizeLength();
    }

    private void Update()
    {
        _angle += Time.deltaTime * _speed;

        OrbitMovement();
    }

    private void RandomizeLength()
    {
        _sinLength = Random.Range(1, 20) * RandomizeSign();
        _cosLength = Random.Range(1, 20) * RandomizeSign();
    }

    private int RandomizeSign()
    {
        return (Random.Range(0, 2) * 2) - 1;
    }

    private void OrbitMovement()
    {
        float _posX = Mathf.Sin(_angle) * _sinLength + transform.parent.position.x;
        float _posY = Mathf.Cos(_angle) * _cosLength + transform.parent.position.y;
        float _posZ = Mathf.Cos(_angle) * _sinLength + transform.parent.position.z;

        transform.position = new Vector3(_posX, _posY, _posZ);
    }
}
