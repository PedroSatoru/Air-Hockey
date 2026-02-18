using UnityEngine;

public class PaddleMouseControl : MonoBehaviour {
    public float speed = 19.0f;
    private Rigidbody2D rb2d;

    // Variáveis para os limites do campo
    [Header("Limites do Campo")]
    public float xMin = -3.72f;
    public float xMax = 3.51f;
    public float yMin = -6.68f;
    public float yMax = -1.07f;


    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 playerPos = transform.position;

        float distance = Vector2.Distance(playerPos, mousePos);

        if (distance > 0.1f) {
            Vector3 dir = mousePos - playerPos;
            dir.Normalize();
            rb2d.linearVelocity = dir * speed;
        } else {
            rb2d.linearVelocity = Vector2.zero;
        }

        // --- APLICAÇÃO DAS TRAVAS (CLAMP) ---
        // Pegamos a posição atual após o movimento
        float clampedX = Mathf.Clamp(transform.position.x, xMin, xMax);
        float clampedY = Mathf.Clamp(transform.position.y, yMin, yMax);

        // Aplicamos a posição restrita de volta ao objeto
        transform.position = new Vector3(clampedX, clampedY, 0);
    }
}