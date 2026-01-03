using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("設定")]
    [SerializeField] private float damage = 1f;
    [SerializeField] private float range = 100f;
    [SerializeField] private Transform playerCamera;

    private PlayerControls inputActions;

    private void Awake()
    {
        inputActions = new PlayerControls();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    // Update is called once per frame
    private void Update()
    {
        if (inputActions.Player.Fire.triggered)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);

            Debug.DrawLine(playerCamera.position, hit.point, Color.red, 0.5f);

            EnemyController enemy = hit.transform.GetComponent<EnemyController>();

            if (enemy != null)
            {
                enemy.OnHit(damage);
            }
        }
    }
}
