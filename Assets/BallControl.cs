using UnityEngine;

public class BallControl : MonoBehaviour {
    private Rigidbody2D rb2d;
    private AudioSource audioSource;

    public float initialForceX = 10f; 
    public float initialForceY = 8f;
    
    // Nova variável para limitar a velocidade máxima
    public float maxSpeed = 20f; 

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();  
        audioSource = GetComponent<AudioSource>(); 
        Invoke("GoBall", 2.0f);  
    }

    // Executado em intervalos fixos de tempo (ideal para física)
    void FixedUpdate() {
        // Verifica se a magnitude da velocidade atual é maior que o limite
        if (rb2d.linearVelocity.magnitude > maxSpeed) {
            // Normaliza o vetor e multiplica pelo limite para manter a direção, mas reduzir a força
            rb2d.linearVelocity = rb2d.linearVelocity.normalized * maxSpeed;
        }
    }

    void GoBall() {
        float rand = Random.Range(0, 2);  
        if (rand < 1) {
            rb2d.AddForce(new Vector2(initialForceX, -initialForceY));
        } else {
            rb2d.AddForce(new Vector2(-initialForceX, -initialForceY));
        }
    }

    // No script BallControl.cs
    void OnCollisionStay2D(Collision2D coll) {
        if (coll.gameObject.CompareTag("Wall")) {
        // Se o disco estiver quase parado lateralmente enquanto bate na parede
            if (Mathf.Abs(rb2d.linearVelocity.x) < 0.5f) {
                float pushDirection = transform.position.x > 0 ? -1f : 1f;
                // Dá um pequeno "toque" para o centro (eixo X)
                rb2d.AddForce(new Vector2(pushDirection * 2f, 0), ForceMode2D.Impulse);
        }
    }
}

    public void ResetBall() {
        rb2d.linearVelocity = Vector2.zero; 
        transform.position = Vector2.zero; 
    }

    public void RestartGame() {
        ResetBall(); 
        Invoke("GoBall", 1.0f); 
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (audioSource != null) {
            audioSource.Play(); 
        }
    }
    
}
