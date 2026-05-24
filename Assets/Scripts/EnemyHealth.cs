using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public float knockbackForce = 5f; // Сила откидывания
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Этот метод сработает, когда нож (Trigger) войдет в коллайдер врага
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что коснулся именно нож (по тегу или компоненту)
        if (other.CompareTag("Weapon"))
        {
            TakeDamage(25);
            ApplyKnockback(other.transform.position);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Враг получил урон! Осталось: " + health);

        if (health <= 0) Die();
    }

    void ApplyKnockback(Vector3 attackerPosition)
    {
        if (rb != null)
        {
            // Рассчитываем направление: от игрока к врагу
            Vector3 direction = (transform.position - attackerPosition).normalized;
            // Добавляем импульс (ForceMode.Impulse идеален для резких ударов)
            rb.AddForce(direction * knockbackForce, ForceMode.Impulse);
        }
    }

    void Die()
    {
        Debug.Log("Враг повержен!");
        // ОБЯЗАТЕЛЬНО выключаем агента, чтобы он не ходил после смерти
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        // Здесь можно запустить анимацию смерти или просто удалить объект
        Destroy(gameObject, 2f);
    }
}