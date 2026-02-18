# 🏒 Air Hockey

Um jogo de Air Hockey 2D desenvolvido em Unity, onde você compete contra uma IA inteligente em um clássico jogo de mesa digital.

## 📋 Características

- **Jogabilidade Clássica**: Experimente a emoção do air hockey em ambiente digital
- **Controle por Mouse**: Movimento fluido e responsivo do seu malho controlado pelo mouse
- **IA Desafiadora**: Oponente controlado por IA que segue a bola e tenta defender
- **Sistema de Pontuação**: Placar dinâmico em tempo real com limite de vitória (10 pontos)
- **Física Realista**: Simulação de física 2D com limite de velocidade da bola
- **Efeitos Sonoros**: Áudio ao bater a bola
- **Interface Clara**: UI intuitiva mostrando pontuação de jogador e bot

## 🎮 Como Jogar

1. **Movimento**: Mova o seu malho (azul) usando o mouse
2. **Objetivo**: Tente acertar o disco para dentro do gol do oponente (topo da tela)
3. **Defesa**: Proteja seu próprio gol (base da tela)
4. **Vitória**: O primeiro a atingir 10 pontos vence a partida!

### Controles
- **Mouse**: Mover o malho do jogador
- A IA (malho vermelho) se move automaticamente seguindo a bola

## 🛠️ Requisitos

- **Unity**: Versão `6000.3.6f1` (LTS)
- **Plataforma**: Windows, macOS, Linux
- **.NET**: .NET Standard 2.1 ou superior

## 📦 Instalação e Configuração

### Pré-requisitos
1. Instale [Unity Hub](https://unity.com/download)
2. Instale a versão Unity `6000.3.6f1` através do Unity Hub

### Passos para Executar

1. **Clone ou Extraia o Projeto**
   ```bash
   # Se estiver em um repositório Git
   git clone <seu-repositorio>
   cd "Air Hockey"
   ```

2. **Abra o Projeto no Unity**
   - Abra o Unity Hub
   - Clique em "Open" e selecione a pasta do projeto
   - Aguarde o Unity processar os assets

3. **Abra a Cena Principal**
   - Na aba "Project", navegue até `Assets/Scenes/`
   - Selecione a cena principal e clique duas vezes para abrir

4. **Execute o Jogo**
   - Pressione `Play` (botão de play no centro superior da janela)
   - Ou use o atalho: `Ctrl + P`

## 🎯 Componentes do Projeto

### Scripts Principais

#### `GameManager.cs`
- Gerencia o placar do jogo
- Controla o fluxo do jogo (início, fim)
- Exibe UI com pontuação
- Define condição de vitória (10 pontos)

#### `BallControl.cs`
- Controla a física e movimento do disco
- Aplica força inicial aleatória ao disco
- Limita velocidade máxima para evitar velocidades excessivas
- Maneja colisões com paredes

#### `PaddleMouseControl.cs`
- Controla o malho do jogador
- Responsivo ao movimento do mouse
- Define limites do campo para evitar sair da área
- Velocidade configurável

#### `BasicAiControl.cs`
- Implementa a IA do oponente
- Segue a posição X da bola
- Ajusta movimento Y baseado na posição da bola
- Velocidade e limites de movimento configuráveis

#### `GoalDetector.cs`
- Detecta quando a bola entra em um gol
- Reseta a posição da bola após gol
- Notifica o GameManager para atualizar pontuação

### Assets

- **Sprites**: Malho azul, malho vermelho, disco (puck), fundo
- **Áudio**: Efeitos sonoros de colisão
- **Physics Material 2D**: Material físico do disco (PuckMaterial)
- **GUI Skin**: Interface visual do placar (ScoreSkin)
- **Input System**: Configuração de entrada (InputSystem_Actions)

## ⚙️ Configurações Recomendadas

### Dificuldade da IA
Para ajustar a dificuldade, edite os parâmetros em `BasicAiControl.cs`:
- **Speed**: Aumente para IA mais rápida
  ```csharp
  public float speed = 10.0f; // Aumentar para ~12-15 para mais dificuldade
  ```

### Velocidade do Jogador
Edite em `PaddleMouseControl.cs`:
```csharp
public float speed = 19.0f; // Edite este valor conforme sua preferência
```

### Condição de Vitória
Edite em `GameManager.cs`:
```csharp
public int winScore = 10; // Mude para qualquer número
```

## 🐛 Solução de Problemas

### O jogo não inicia
- Certifique-se que está usando Unity `6000.3.6f1`
- Verifique se todos os scripts estão sem erros (abra a janela de Console)
- Tente reimportar os assets: `Assets → Reimport All`

### Bola fica presa na parede
- O script `BallControl.cs` possui lógica para desgrudar a bola
- Se persistir, ajuste o `maxSpeed` para um valor menor

### IA não se move
- Verifique se o disco tem a tag "Ball"
- Certifique-se que `BasicAiControl.cs` está anexado ao malho vermelho

### Sem som
- Verifique se os áudios estão importados corretamente
- Confirme que o `AudioSource` está ativado nos objetos

## 📊 Estrutura de Diretórios

```
Assets/
├── Audio/                    # Arquivos de som e música
├── Scenes/                   # Cenas do jogo
├── Settings/                 # Configurações de volume e qualidade
├── *.cs                      # Scripts principais
├── *.png                      # Sprites (malho, disco, fundo)
├── *.asset                   # Configurações de renderização e física
└── *.guiskin                 # Tema visual da interface
```