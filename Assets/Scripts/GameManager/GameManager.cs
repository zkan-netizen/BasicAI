using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
  public static GameManager _gameManager;
  public bool isGameStart = false;
  public GameObject _floatingTextPrefab;
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
  }
  public void ShowDamage(string text,Transform other)
  {
    if (_floatingTextPrefab)
    {
      GameObject prefab =
          Instantiate(_floatingTextPrefab,
         other.transform.position,
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
