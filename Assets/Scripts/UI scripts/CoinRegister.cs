using TMPro;
using UnityEngine;

public class CoinRegister : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        GameManagerEnd.endmanager.RegisterCoin(textMesh);
        textMesh.text = "Coins: 0";
    }
}