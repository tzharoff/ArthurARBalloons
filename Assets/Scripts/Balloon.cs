using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [Header("Balloons")]
    [SerializeField] private Color[] balloonColors;
    [SerializeField] private float minFloatSpeed = 66f;
    [SerializeField] private float maxFloatSpeed = 80f;

    [Header("Letters")]
    [SerializeField] private Color[] letterColors;
    [SerializeField] private GameObject[] letters;
    [SerializeField] private Transform letterHolder;

    public static event System.Action<int> BalloonPopped;

    private int _balloonID;
    private MaterialPropertyBlock _propertyBlock;
    private float FloatSpeed;

    #region UnityMethods
    // Start is called before the first frame update
    void Start()
    {
        _propertyBlock = new MaterialPropertyBlock();
        FloatSpeed = Random.Range(minFloatSpeed, maxFloatSpeed);
        RandomBalloonColor();
        SpawnLetter();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * FloatSpeed * Time.deltaTime);
    }
    #endregion

    #region CustomMethods
    private void SpawnLetter()
    {
        _balloonID = Random.Range(0, letters.Length - 1);
        GameObject temp = Instantiate(letters[_balloonID],letterHolder);
        Renderer _renderer = temp.GetComponentInChildren<MeshRenderer>();
        _renderer.GetPropertyBlock(_propertyBlock);
        _propertyBlock.SetColor("_BaseColor", letterColors[Random.Range(0, letterColors.Length)]);
        _renderer.SetPropertyBlock(_propertyBlock);
    }

    private void RandomBalloonColor()
    {
        Renderer _renderer = GetComponentInChildren<MeshRenderer>();
        _renderer.GetPropertyBlock(_propertyBlock);
        _propertyBlock.SetColor("_BaseColor", new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f));
        _renderer.SetPropertyBlock(_propertyBlock);
    }

    public void PopBalloon()
    {
        BalloonPopped?.Invoke(_balloonID);
        Destroy(gameObject);
    }
    #endregion

}
