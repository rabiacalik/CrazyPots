using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 10f;
    private float dashSpeed = 60f; // Dash sırasında hızlanma miktarı
    private float dashDuration = 0.3f; // Dash süresi
    private bool isDashing = false; // Dash yapılıp yapılmadığını kontrol için
    public GameObject bulletPrefab; // Mermi prefab'ı

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (!isDashing) // Eğer şu an dash yapılmıyorsa normal hareket
        {
            rb.velocity = new Vector3(0, rb.velocity.y, horizontalInput * moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && horizontalInput != 0) // Dash yapma kontrolü
        {
            StartCoroutine(Dash(horizontalInput));
        }

        if (Input.GetMouseButtonDown(0)) // 0 = Sol fare tuşu
        {
            ShootBullet();
        }
    }

    public void ShootBullet()
    {
        if (bulletPrefab != null)
        {
            Vector3 spawnPosition = transform.position + new Vector3(0, 4.7f, 0); // Mermiyi biraz yukarıda spawn et
            Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private IEnumerator Dash(float direction)
    {
        isDashing = true;

        // Dash sırasında hızlanma
        rb.velocity = new Vector3(0, rb.velocity.y, direction * dashSpeed);

        // Dash süresini bekle
        yield return new WaitForSeconds(dashDuration);

        // Hızın eski haline dönmesi
        rb.velocity = new Vector3(0, rb.velocity.y, direction * moveSpeed);

        isDashing = false;
    }

}
