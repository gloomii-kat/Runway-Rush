using UnityEngine;

public class Clickandswap : MonoBehaviour
{
    private Transform firstSelected = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                Transform clicked = hit.transform;

                if (firstSelected == null)
                {
                    firstSelected = clicked;
                    Debug.Log("First selected: " + clicked.name);
                }
                else
                {
                    // Swap positions
                    Vector3 tempPos = firstSelected.position;
                    firstSelected.position = clicked.position;
                    clicked.position = tempPos;

                    Debug.Log($"Swapped {firstSelected.name} with {clicked.name}");

                    // Reset selection
                    firstSelected = null;
                }
            }
            else
            {
                Debug.Log("Clicked, but no object was hit.");
            }
        }
    }
}