using UnityEngine;

public class BasicAiControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    
    // Declaração das variáveis que estavam faltando 
    private GameObject puck; 
    
    [Header("Configurações de Movimento")]
    public float speed = 10.0f; 
    
    [Header("Limites do Campo IA")]
    public float xMin = -3.72f; // [cite: 166]
    public float xMax = 3.51f;
    public float yMin = 1.07f;  // Limite inferior da IA (próximo à rede)
    public float yMax = 6.49f;  // Limite superior da IA (fundo do campo)

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
        
        // Busca o disco pela Tag que você criou 
        puck = GameObject.FindGameObjectWithTag("Ball"); 
    }

    void Update()
    {
    if (puck != null) 
    {
        // 1. Calcula o alvo (seguindo o X do disco)
        float targetX = Mathf.Clamp(puck.transform.position.x, xMin, xMax);
        
        // Mantemos o Y da IA fixo ou levemente ajustável
        float targetY = Mathf.Clamp(puck.transform.position.y, yMin, yMax);
        Vector2 targetPosition = new Vector2(targetX, targetY);
        
        // 2. Calcula a direção e distância
        Vector2 currentPos = rb2d.position;
        float distance = Vector2.Distance(currentPos, targetPosition);

        // 3. Move usando velocidade física (evita o "teleporte" que causa o travamento)
        if (distance > 0.1f) {
            Vector2 dir = (targetPosition - currentPos).normalized;
            rb2d.linearVelocity = dir * speed;
        } else {
            rb2d.linearVelocity = Vector2.zero;
        }
    }

    // Mantém a trava de segurança (Clamp)
    float clampedX = Mathf.Clamp(transform.position.x, xMin, xMax);
    float clampedY = Mathf.Clamp(transform.position.y, yMin, yMax);
    transform.position = new Vector3(clampedX, clampedY, 0);
}
    }
