using TH.Core;
using TH.Utilities;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 position;
    private int sineShotOffset = 1;

    public Vector2 direction;
    [HideInInspector]
    public EnemyType enemyType;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!GameManager.Instance.isPaused)
        {
            switch (enemyType)
            {
                case EnemyType.Nigawarai:
                    SpreadShot();
                    break;
                case EnemyType.ShiroUneri:
                    NormalShot();
                    break;
                case EnemyType.SoriNoKanmushi:
                    NormalShot();
                    break;
                default:
                    return;
            }
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            transform.position = position;
        }
    }

    private void NormalShot()
    {
        rb.velocity = direction * Config.GenericBulletSpeedMultiplier * Time.deltaTime;
        position = transform.position;
    }

    private void SpreadShot()
    {
        direction.x -= sineShotOffset;
        direction.y += sineShotOffset;
        rb.velocity = direction * Config.GenericBulletSpeedMultiplier * 0.2f * Time.deltaTime;
        position = transform.position;
    }
}
