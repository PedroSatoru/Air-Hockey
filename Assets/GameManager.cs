using UnityEngine;

public class GameManager : MonoBehaviour {
    public static int PlayerScore = 0; // Pontuação do Player 
    public static int BotScore = 0;    // Pontuação do Bot 
    
    public GUISkin layout;             // Referência à Skin que criamos 
    private GameObject puck;

    public int winScore = 10; // O primeiro a chegar em 10 vence 
    private bool isGameOver = false;

    void Start() {
        puck = GameObject.FindGameObjectWithTag("Ball"); // 
    }

    // Função estática para somar pontos [cite: 309]
    public static void Score(string goalName) {
        if (goalName == "Goal_AI") {
            PlayerScore++; // Se entrou no gol de cima, ponto para o Player 
        } else if (goalName == "Goal_Player") {
            BotScore++;    // Se entrou no gol de baixo, ponto para o Bot 
        }
        Debug.Log("Placar Atual - Player: " + PlayerScore + " | Bot: " + BotScore);
    }

    void OnGUI() {
        GUI.skin = layout; // Aplica o estilo 

        // --- LADO ESQUERDO (PLAYER) ---
        // Label "PLAYER"
        GUI.Label(new Rect(Screen.width / 4 - 50, 100, 200, 50), "PLAYER");
        // Valor da pontuação embaixo
        GUI.Label(new Rect(Screen.width / 4 - 20, 150, 100, 100), "" + PlayerScore);

        // --- LADO DIREITO (BOT) ---
        // Label "BOT"
        GUI.Label(new Rect(3 * Screen.width / 4 - 50, 100, 200, 50), "BOT");
        // Valor da pontuação embaixo
        GUI.Label(new Rect(3 * Screen.width / 4 - 20, 150, 100, 100), "" + BotScore);

        if (PlayerScore >= winScore || BotScore >= winScore) {
            EndGame(); // Trava o jogo 

            // Define o tamanho da caixa de mensagem
            float boxWidth = 300;
            float boxHeight = 200;
            Rect boxRect = new Rect(Screen.width / 2 - boxWidth / 2, Screen.height / 2 - boxHeight / 2, boxWidth, boxHeight);

            // Desenha a caixa centralizada
            GUI.Box(boxRect, ""); 

            // Define a mensagem de vencedor baseada na pontuação
            string winnerText = (PlayerScore >= winScore) ? "PLAYER WINS!" : "BOT WINS!";
            
            // Texto da vitória dentro da caixa
            GUI.Label(new Rect(boxRect.x, boxRect.y + 50, boxWidth, 50), winnerText);

            if (GUI.Button(new Rect(boxRect.x + boxWidth / 2 - 60, boxRect.y + 130, 120, 50), "RESTART")) {
                ResetMatch();
            }
        } 
        else {
            if (GUI.Button(new Rect(Screen.width - 250, Screen.height / 2 - 25, 120, 50), "RESTART")) {
                ResetMatch();
            }
        }
    }

    void EndGame() {
        if (!isGameOver) {
            isGameOver = true;
            Time.timeScale = 0; // CONGELA O JOGO 
            puck.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver); 
        }
    }

    void ResetMatch() {
        PlayerScore = 0;
        BotScore = 0;
        isGameOver = false;
        Time.timeScale = 1; // DESCONGELA O JOGO
        puck.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver); 
    }
}






