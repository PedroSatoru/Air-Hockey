using UnityEngine;

public class GoalDetector : MonoBehaviour {
    // Este método é chamado quando algo entra no Trigger
    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.CompareTag("Ball")) {

            string goalName = transform.name; // Pega o nome do objeto (GoalAI ou GoalPlayer) 
            GameManager.Score(goalName);
            // Envia uma mensagem para a bola reiniciar
            hitInfo.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
            
            // Aqui podes adicionar a lógica de somar pontos no futuro
            Debug.Log("Gol detetado em: " + gameObject.name);
        }
    }
}