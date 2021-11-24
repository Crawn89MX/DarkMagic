using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//************** agregar para mover botones y texto
using TMPro; // ********* Esto para crear objetos tipo TextMeshPro

public class DialogueManager : MonoBehaviour
{

    #region Componentes dialogPnl
    [Header("Panel de diálogos")]
    #pragma warning disable 0649
    [SerializeField]
    private GameObject _dialoguePnl;
    #pragma warning restore 0649

    // Creamos los objetos de tipo TextMeshPro para luego trabajar con ellos
    private TextMeshProUGUI _dialogueTxt, _nameTxt, _continueTxt;
    // Creamos un objeto de tipo boton
    private Button _continueBtn;
    #endregion

    private string _name;
    private List<string> _dialogueList;
    private int _dialogueIdx;


    void Start()
    {
        #region Obteniendo los obejtos del panel
        if (_dialoguePnl == null)
        {
            Debug.LogWarning("Arrastrar el pánel de diálogos al dialogManager");
        }
        //Obteniendo primer hijo(TMP)
        //_dialogueTxt = _dialoguePnl.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _dialogueTxt = _dialoguePnl.GetComponentInChildren<TextMeshProUGUI>();
        if (_dialogueTxt != null)
        {
            _dialogueTxt.text = "El diálogo se inicializó correctamente";
        }
        else
        {
            Debug.LogWarning("No se encontró un TMP en el primer hijo del dialogPnl");
        }

        //Obteniendo el hijo del segundo hijo (TMP)
        //_nameTxt = _dialoguePnl.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        _nameTxt = _dialoguePnl.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
        if (_nameTxt != null)
        {
            _nameTxt.text = "Nombre inicial";
        }
        else
        {
            Debug.LogWarning("No se encontró un TMP como hijo del segundo hijo del dialogPnl");
        }


        //Obteniendo el tercer hijo (Btn)
        _continueBtn = _dialoguePnl.transform.GetChild(2).GetComponent<Button>();
        if (_continueBtn != null)
        {
            //agregar listener
            _continueTxt = _continueBtn.GetComponentInChildren<TextMeshProUGUI>();
            if (_continueTxt != null)
            {
                _continueTxt.text = "Continuar";
            }
            else
            {
                Debug.LogWarning("No se encontró un TMP como hijo del botón de continuar");
            }
        }
        else
        {
            Debug.LogWarning("No se encontró un Btn como hijo del tercer hijo del dialogPnl");
        }
        #endregion

        _dialoguePnl.SetActive(false);
        _continueBtn.onClick.AddListener(delegate { ContinueDialogue(); });
    }


    public void SetDialogue(string name, string[] dialogue)
    {
        Debug.Log("Obteniendo diálogo");
        _name = name;
        _dialogueList = new List<string>(dialogue.Length);
        _dialogueList.AddRange(dialogue);
        _dialogueIdx = 0;
        _nameTxt.text = _name;
        _continueTxt.text = "Continuar";

        ShowDialogue();
        _dialoguePnl.SetActive(true);
    }

    public void ShowDialogue()
    {
        Debug.Log(_dialogueIdx);
        _dialogueTxt.text = _dialogueList[_dialogueIdx];
    }

    public void ContinueDialogue()
    {
        if (_dialogueIdx == _dialogueList.Count - 1)//Se termina
        {
            Debug.Log("Se termina el diálogo");
            _dialoguePnl.SetActive(false);
        }
        else if (_dialogueIdx == _dialogueList.Count - 2)//Uno antes de terminar
        {
            _continueTxt.text = "Salir";
            _dialogueIdx++;
            ShowDialogue();
        }
        else
        {
            _dialogueIdx++;
            ShowDialogue();
        }

    }

}
