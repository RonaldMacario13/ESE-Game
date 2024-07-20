using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int _health;
    public int _numOfHearts;

    public Image[] _hearts;
    public Sprite _fullHeart;
    public Sprite _emptyHeart;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (_health > _numOfHearts)
        {
            _health = _numOfHearts;
        }

        for (int i = 0; i < _hearts.Length; i++)
        {
            if (i < _health)
            {
                _hearts[i].sprite =_fullHeart;
            }
            else
            {
                _hearts[i].sprite = _emptyHeart;
            }

            if (i < _numOfHearts)
            {
                _hearts[i].enabled = true;
            }
            else
            {
                _hearts[i].enabled = false;
            }
        }
    }
}
