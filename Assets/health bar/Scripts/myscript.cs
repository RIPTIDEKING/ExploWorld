using UnityEngine;
using UnityEngine.UI;

public class myscript : MonoBehaviour
{
    public Image Bar;
    public float Fill;

    
    // Start is called before the first frame update
    void Start()
    {
        Fill = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Bar.fillAmount = Fill;
    }
}
