using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float maxHp = 5f;
    private float currentHp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            Debug.Log("Kokeshi Dead!");
            Destroy(gameObject);
        }
    }
}
