using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("設定")]
    public float range = 100f;
    public Transform playerCamera;

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
    void Update()
    {
        if (inputActions.Player.Fire.triggered)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);

            Debug.DrawLine(playerCamera.position, hit.point, Color.red, 0.5f);
        }
    }
}
