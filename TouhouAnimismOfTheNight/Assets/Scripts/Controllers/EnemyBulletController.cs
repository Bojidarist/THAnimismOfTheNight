using TH.Core;
using TH.Utilities;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 position;
    private int sineShotOffset = 1;
    private ScreenBorderDetector borderDetector;

    public Vector2 direction;
    [HideInInspector]
    public EnemyType enemyType;


    private void Start()
    {
        borderDetector = FindObjectOfType<ScreenBorderDetector>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!GameManager.Instance.isPaused)
        {
            float x = transform.position.x;
            float y = transform.position.y;
            float xl = borderDetector.leftBorder - 2f;
            float xr = borderDetector.rightBorder + 2f;
            float yu = borderDetector.upperBorder + 2f;
            float yb = borderDetector.bottomBorder - 2f;
            if (x > xr || x < xl || y < yb || y > yu)
            {
                Destroy(this.gameObject);
            }
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
