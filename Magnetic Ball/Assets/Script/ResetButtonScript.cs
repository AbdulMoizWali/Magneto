using UnityEngine;
using UnityEngine.UI;

public class ResetButtonScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(GameManager.instance.ResetGame);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(GameManager.instance.ResetGame);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
