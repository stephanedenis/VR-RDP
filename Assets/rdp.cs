using UnityEngine;
using UnityEngine.UI;

public class rdp : MonoBehaviour
{

    public Image screen;
    public Sprite rdpScreen;

    void Update()
    {
        screen.sprite = rdpScreen;         
    }
}
