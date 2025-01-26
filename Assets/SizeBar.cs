using UnityEngine;
using UnityEngine.UI;

public class SizeBar : MonoBehaviour
{
    [SerializeField] GameObject player;
    public Slider levelSlider;
    public int maxLevel = 100;
    private int currentLevel;

    void Start()
    {
        //currentLevel = 0;
        //levelSlider.maxValue = maxLevel;
        //levelSlider.value = currentLevel;
    }

    void FixedUpdate()
    {
        //currentLevel = (player.size/proxMeta.size)*100
        //if (currentLevel > maxLevel)
        //{
        //    currentLevel = maxLevel;
        //}
        //levelSlider.value = currentLevel;
    }
}
