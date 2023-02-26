using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public static GameManager _gameManager;

    public bool isGameStart = false;

    public GameObject _floatingTextPrefab;

    //-----
    public GameObject _HealthTextPrefab;

    public GameObject TextSpawn;

    public Text StartText;

    public void Awake()
    {
        if (_gameManager == null)
        {
            _gameManager = this;
        }
    }

    void Start()
    {
        _floatingTextPrefab = GameObject.Find("FloatingTextParent");
        _HealthTextPrefab = GameObject.Find("HealthTextParent");
        TextSpawn = GameObject.Find("Player");
    }

    public void ShowDamage(string DamageText, Transform other)
    {
        other.transform.SetParent(other.transform);
        if (_floatingTextPrefab )//&&other.gameObject.name!="Player"
        {
           _floatingTextPrefab.GetComponentInChildren<TextMesh>().color =
                Color.yellow;
            GameObject prefab =
                Instantiate(_floatingTextPrefab,
                new Vector3(Random
                        .Range(other.transform.position.x - .5f,
                        other.transform.position.x + 1f),
                    other.transform.position.y,
                    Random
                        .Range(other.transform.position.z - .5f,
                        other.transform.position.z + 1f)),
                Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = DamageText;
        }
    }

    public void ShowHeal(string text, Transform other)
    {
        other.transform.SetParent(other.transform);
        if (_HealthTextPrefab)
        {
            _HealthTextPrefab.GetComponentInChildren<TextMesh>().color =
                Color.green;
            GameObject prefab =
                Instantiate(_HealthTextPrefab,
                new Vector3(Random
                        .Range(other.transform.position.x - .5f,
                        other.transform.position.x + .5f),
                    other.transform.position.y,
                    other.transform.position.z), //this part for random location of text
                Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
        }
    }


#region Top To Start
    public void TopToStart()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            if (Input.GetMouseButton(0))
            {
                isGameStart = true;

                StartText.gameObject.SetActive(false);
                return;
            }
        }
    }
#endregion

}
