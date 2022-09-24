using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Buttons : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{
    private Button button;
    Vector3 scaling = new Vector3(1.2f, 1.2f, 1.2f);
    Vector3 resetscaling = new Vector3(1f, 1f, 1f);
    [SerializeField]private Sprite selected;
    private Sprite mainSprite;
    private Image sprite;
    public void OnPointerDown(PointerEventData eventData)
    {
        sprite.sprite = selected;
        print("Se ha clicado");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        sprite.sprite = mainSprite;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, scaling, 0.20f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, resetscaling, 0.20f);
    }
    void Start()
    {
        button = GetComponent<Button>();
        mainSprite = GetComponent<Image>().sprite;
        sprite = GetComponent<Image>();
    }
}
