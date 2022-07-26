using UnityEngine;

public class TowersNumberController : MonoBehaviour
{
    public TextMesh text;
    
    void Update()
    {
        text.text = "Towers: " + TurrentController.currentTurrentCount;
    }
}
