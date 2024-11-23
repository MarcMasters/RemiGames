using UnityEngine;
using UnityEngine.UI;

public class PlayAgainButton : MonoBehaviour
{
    public Button playAgainButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playAgainButton.onClick.Invoke();
        }
    }
}
