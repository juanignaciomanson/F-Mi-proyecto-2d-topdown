using Unity.Cinemachine;
using UnityEngine;

public class MapTransitions : MonoBehaviour
{
    //serialize field deja editarlo en el editor de unity sin entrar al texto
    [SerializeField] PolygonCollider2D mapBoundry;
    CinemachineConfiner2D confiner;
    [SerializeField] Direction direction;
    [SerializeField] float additivePos = 2f;


    enum Direction { Up, Down, Left, Right}

    private void Awake()
    {
        confiner = FindFirstObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            confiner.BoundingShape2D = mapBoundry;
            // despues de cambiar el boundry update al player
            UpdatePlayerPosition(collision.gameObject);
        }
    }
    //parte de como forzar al jugador adelante de la transicion
    private void UpdatePlayerPosition(GameObject player)
    {
        Vector3 newPos = player.transform.position;
        switch (direction)
        {
            case Direction.Up:
                newPos.y += additivePos;
                break;
            case Direction.Down:
                newPos.y -= additivePos;
                break;
            case Direction.Right:
                newPos.x += additivePos;
                break;
            case Direction.Left:
                newPos.x -= additivePos;
                break;
        }
        player.transform.position = newPos;

    }
}
