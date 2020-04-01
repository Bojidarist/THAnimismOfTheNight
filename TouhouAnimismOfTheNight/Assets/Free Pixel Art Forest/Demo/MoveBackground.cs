using TH.Core;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public float speed;
    private float x;
    public float PontoDeDestino;
    public float PontoOriginal;
    private Vector3 position;

    // Use this for initialization
    void Start()
    {
        //PontoOriginal = transform.position.x;
        position = Vector3.zero;
    }

    void Update()
    {
        if (!GameManager.Instance.isPaused)
        {
            x = transform.position.x;
            x += speed * Time.deltaTime;
            position.x = x;
            position.y = transform.position.y;
            position.z = transform.position.z;
            transform.position = position;

            if (x <= PontoDeDestino)
            {
                x = PontoOriginal;
                position.x = x;
                transform.position = position;
            }
        }
    }
}
