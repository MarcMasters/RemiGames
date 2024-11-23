using UnityEngine;

public class InfiniteScrollingBG : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f;
    [SerializeField] private GameObject[] bgParts;    // Array de sprites (tantos sprites como quiera añadir)
    private float spriteLen;

    void Start()
    {
        spriteLen = bgParts[0].GetComponent<SpriteRenderer>().bounds.size.x;
        //Debug.Log(spriteLen);
    }
   
    void Update()
    {
        // Desplazamiento de cada sprite a la izquierda
        foreach (GameObject part in bgParts) 
        {
            // Movimiento por igual de las partes
            part.transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

            // Sprite fuera de vista
            if (part.transform.position.x < -spriteLen)
            {
                // Teleport al final de la secuencia (izq) (con la parte que se ha salido)
                RepositionBG(part);
            }

        }
    }

    void RepositionBG(GameObject part)
    {
        // Se asigna un 1r sprite de referencia y se itera para detectar el más a la dcha.
        GameObject mostRightPart = bgParts[0];

        foreach (GameObject bgPart in bgParts)
        {
            // Si cualquiera de las partes está más a la dcha que 'mostRightPart' se sustituye esta variable
            if (bgPart.transform.position.x > mostRightPart.transform.position.x)
            {
                mostRightPart = bgPart;
            }
        }

        // Reposicionamiento de 'part' (parte que se ha salido) al final de la secuencia
        Vector3 newPos = mostRightPart.transform.position;
        newPos.x += spriteLen;
        // Se coloca la 'part' que se habia salido a la dcha del todo
        part.transform.position = newPos;

    }
}
