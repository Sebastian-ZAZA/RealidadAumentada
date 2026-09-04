using UnityEngine;

public class EventManager : MonoBehaviour
{
    [Header("Referencias de Objetos")]
    [Tooltip("Objeto que se encenderá/apagará mediante el evento de animación")]
    public GameObject targetToggleObject;

    [Tooltip("Objeto que cambiará de posición y reproducirá la animación")]
    public GameObject targetMoveObject;

    [Tooltip("Componente Animator del objeto a animar (opcional si está en el mismo objeto)")]
    public Animator objectAnimator;

    private void Start()
    {
        if (objectAnimator == null && targetMoveObject != null)
        {
            objectAnimator = targetMoveObject.GetComponent<Animator>();
        }
    }
    public void ToggleObjectState()
    {
        if (targetToggleObject != null)
        {
            bool currentState = targetToggleObject.activeSelf;
            targetToggleObject.SetActive(!currentState);
        }
    }
    public void OnButtonClick()
    {
        if (targetMoveObject != null)
        {
            float randomX = Random.Range(0f, 20f);
            float randomY = Random.Range(0f, 20f);
            float randomZ = Random.Range(0f, 20f);

            targetMoveObject.transform.position = new Vector3(randomX, randomY, randomZ);
        }

        if (objectAnimator != null)
        {
            objectAnimator.SetTrigger("Activador");
        }
    }
}
