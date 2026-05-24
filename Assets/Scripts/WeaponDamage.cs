using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int damageAmount = 25;

    // Этот метод сработает, когда триггер меча войдет в коллайдер врага
    private void OnTriggerEnter(Collider other)
    {
        // Проверка в консоли: вообще хоть что-то коснулось меча?
        Debug.Log("Меч коснулся объекта: " + other.name);

        EnemyHealth health = other.GetComponent<EnemyHealth>();
        if (health != null)
        {
            health.TakeDamage(damageAmount);
        }
    }
}