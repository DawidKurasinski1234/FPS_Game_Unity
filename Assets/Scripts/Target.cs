using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount; // Odejmij obra¿enia od ¿ycia

        if (health <= 0f)
        {
            Die(); // Jeœli ¿ycie <= 0, umieraj
        }
    }

    void Die()
    {
        Destroy(gameObject); // Usuñ ten obiekt ze œwiata gry
    }
}