# MeteGol — Choque de Esferas: Liga de Energia

<img width="1024" height="408" alt="image" src="https://github.com/user-attachments/assets/da2f205b-5bdd-4388-9fcd-7f7b6b93bb03" />

<img width="235" height="221" alt="{48221C78-9F31-49CE-87EE-3EF45A1ECD50}" src="https://github.com/user-attachments/assets/08f18f11-043f-4a82-a1d5-0552d6aa2ce7" />


## Descripcion

MeteGol es un juego de futbolin 3D para dos jugadores en modo local, desarrollado en Unity 6. Dos esferas controladas por cada jugador empujan una pelota central hacia el arco rival. El primer jugador en anotar tres goles gana la partida.

El proyecto fue construido como ejercicio academico reutilizando y adaptando la logica de movimiento, deteccion de colisiones y gestion de escenas del proyecto base proporcionado en clase (Ejercicio-1-Clase-EVM-2026-1).

## Proyecto base utilizado

El presente juego reutiliza los siguientes elementos del proyecto original Ejercicio-1-Clase-EVM-2026-1:

- **Esfera.cs**: la logica de movimiento por fisica (`rb.linearVelocity`) y normalizacion de direccion fueron adaptadas directamente en `PlayerOne.cs` y `PlayerTwo.cs`.
- **GameManager.cs**: el patron Singleton (`public static Instance { get; set; }`), el uso de `TMP_Text` para la interfaz de usuario y el metodo `ResetGame()` con `SceneManager.LoadScene` fueron reutilizados en `FutbolinGameManager.cs`.
- **Esfera.cs (OnTriggerEnter)**: la logica de deteccion por trigger con `CompareTag` fue adaptada en `GoalTrigger.cs`, reemplazando la zona Dead por una zona de gol.
- **MainMenu.cs**: reutilizado de forma exacta para la navegacion entre escenas.

## Mecanica del juego

- Dos jugadores controlan una esfera cada uno en un campo plano con paredes laterales.
- Una tercera esfera actua como pelota, sin input del jugador, impulsada unicamente por fisica.
- Cuando la pelota entra en la zona de gol (trigger) del arco rival, se anota un punto.
- El juego termina cuando un jugador alcanza tres goles. La escena regresa automaticamente al menu principal.

## Controles

| Jugador | Adelante | Atras | Izquierda | Derecha |
|---------|----------|-------|-----------|---------|
| Jugador 1 | W | S | A | D |
| Jugador 2 | I | K | J | L |

## Requisitos

- Unity 6 (version 6000.3.x o superior)
- Input System Package (instalado via Package Manager)
- TextMeshPro (incluido en el proyecto)
- Universal Render Pipeline (URP)

## Estructura del proyecto

```
Assets/
├── Images/          # Imagenes de interfaz (fondo del menu)
├── Materials/       # Materiales URP de los objetos
├── PhysicsMaterials/ # Physics Materials para rebote
├── Scenes/
│   ├── MainMenu     # Escena del menu principal
│   └── GameScene    # Escena del juego
└── Scripts/
    ├── PlayerOne.cs         # Movimiento del Jugador 1 (WASD)
    ├── PlayerTwo.cs         # Movimiento del Jugador 2 (IJKL)
    ├── GoalTrigger.cs       # Deteccion de gol por trigger
    ├── FutbolinGameManager.cs # Logica de marcador y gestion de partida
    └── MainMenu.cs          # Navegacion entre escenas
```

## Instrucciones de ejecucion

1. Abrir el proyecto en Unity 6.
2. Verificar que en **File → Build Profiles** las escenas esten en el orden: `MainMenu` (0), `GameScene` (1).
3. Abrir la escena `MainMenu`.
4. Presionar **Play** para ejecutar en el editor, o **Build And Run** para compilar.

Ariana Cordero - 2026
